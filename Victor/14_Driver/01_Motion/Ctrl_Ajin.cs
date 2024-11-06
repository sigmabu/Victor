using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Victor.HardWare
{
    public class Ctrl_Ajin
    {
        private object _lockObj = new object();
        public bool IsOpen { get; private set; } = false;
        public bool IsLoop = true;

        private string sMotionDataPath;
        private string sFolderPath;
        private string sFileName;

        public static string[,] csvData;
        static int nMotorCnt = 0;
        protected uint _uStateValue = 0; // 각종 상태값 조회용 임시변수
        protected const double MSToSEC = 0.001;                     // Mili-Second -> Second로 변환, 가/감속 지정에 사용된다.

        protected MOTION_INFO tAxis_Info = new MOTION_INFO();         // Motion 정보를 가져오는 임시변수, ReadData()에서 사용
        public struct mSTATUS {
            public bool bBusy { get; set; }
            public bool bDone { get; set; }
            public bool bAlarm { get; set; }
            public uint uHDone { get; set; }
            public bool bHDon { get; set; }
            public bool bServo_On { get; set; }
            public bool bInpos { get; set; }
            public bool bHSen { get; set; }
            public bool bPLSen { get; set; }
            public bool bNLSen { get; set; }


            public double dCmdPulse;
            public double dCmdPos;
            public double dCmdVel;
            public double dFbPulse;
            public double dFbPos;
            public double dFbVel;
        }
        public static mSTATUS[] mSts = new mSTATUS[(int)eMOT.END];

        /// <summary>
        /// 데이터 갱신용 스레드
        /// </summary>
        private Thread Thread = null;

        public Ctrl_Ajin(string sPathName)
        {
            sMotionDataPath = sPathName;
            for (int i = 0; i < mSts.Length; i++)
            {
                mSts[i].bBusy = true;
                mSts[i].bDone = true;
                mSts[i].bAlarm = true;
                mSts[i].uHDone = 0x00;
                mSts[i].bHDon = true;

                mSts[i].dCmdPulse = 0.0;
                mSts[i].dCmdPos = 0.0;
                mSts[i].dFbPulse = 0.0;
                mSts[i].dFbPos = 0.0;

            }
            Init_FilePath();
            Init_ReadFile_MotorList();
            Init_Motor();
            IsLoop = true;
            Thread_Start();
        }

        private void Init_FilePath()
        {
            int i = 0;
            int FindDot = sMotionDataPath.LastIndexOf(".");
            int Lastsp = sMotionDataPath.LastIndexOf("\\");

            sFileName = sMotionDataPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sMotionDataPath.Replace(sFileName + ".csv", "");
        }

        public int Init_ReadFile_MotorList()
        {
            nMotorCnt = 0;
            csvData = CSV.OpenMotorCSVFile(sMotionDataPath, out nMotorCnt);
            if (csvData == null)
            {
                MessageBox.Show("Read_File_MotorList Error", " MotorList.csv 화일 Abnormal!!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return 1;
        }

        protected bool Init_Motor()
        {
            int nRet = 0;
            int nAxis = 0;
            double dGearNumerator = 1000.0;
            uint uInt32Temp;

            try
            {
                nRet = CAXL.AxlIsOpened();  // 라이브러리가 Open 되어있는가 ?
                if (nRet == 0)              // 라이브러리가 초기화 되어있지 않음
                {
                    // AXL 라이브러리Open
                    nRet = (int)CAXL.AxlOpen(0);
                    
                    // 라이브러리 Open 성공
                    if (nRet == (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)         
                    {
                        IsOpen = true;
                        Debug.WriteLine($". AXL LibraryOpen() OK, {sFileName} : {nRet}");

                        for (int i = 0; i < nMotorCnt; i++)
                        {
                            nAxis = Convert.ToInt32(CData.tMotor[i].sName);
                            // 초기 Servo off 
                            nRet = (int)CAXM.AxmSignalServoOn(nAxis, 0x00);   // 0x00 : Off,  0x01 : On
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmSignalServoOn(OFF) return fail, Axis:{nAxis}, {nRet}");
                            }

                            // 기어비 설정, 아래 기어비를 설정하면 pp1은 1로 고정 해야 한다.
                            // Unit : 1 회전당 이동 거리
                            // Pulse : 1 회전에 필요한 펄스 수
                            // 기어비 = Unit / Pulse
                            dGearNumerator = Convert.ToDouble(CData.tMotor[i].nPP1);
                            nRet = (int)CAXM.AxmMotSetMoveUnitPerPulse(nAxis, dGearNumerator, CData.tMotor[i].nLead_Pitch);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmMotSetMoveUnitPerPulse() return fail, Axis:{nAxis}, {nRet}");
                            }
                            // NOT/POT 센서 설정 적용
                            uInt32Temp = Convert.ToUInt32(CData.tMotor[i].sLimit_Coil);
                            nRet = (int)CAXM.AxmSignalSetLimit(nAxis, 0x00, uInt32Temp, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmSignalSetLimit() return fail, Axis:{nAxis}, {nRet}");
                            }
                            // Servo Alarm Logic 설정
                            uInt32Temp = Convert.ToUInt32(CData.tMotor[i].sAlarm_Coil);
                            nRet = (int)CAXM.AxmSignalSetServoAlarm(nAxis, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmSignalSetServoAlarm() return fail, Axis:{nAxis}, {nRet}");
                            }

                            // Z상 레벨 지정
                            uInt32Temp = Convert.ToUInt32(CData.tMotor[i].sZ_Phase);
                            nRet = (int)CAXM.AxmSignalSetZphaseLevel(nAxis, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmSignalSetZphaseLevel() return fail, Axis:{nAxis}, {nRet}");
                            }

                            // Inpos 신호 레벨 지정
                            uInt32Temp = 1;
                            nRet = (int)CAXM.AxmSignalSetInpos(nAxis, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmSignalSetInpos() return fail, Axis:{nAxis}, {nRet}");
                            }

                            // Home sensor 신호 레벨 지정
                            uInt32Temp = Convert.ToUInt32(CData.tMotor[i].sHomeLogic);
                            nRet = (int)CAXM.AxmHomeSetSignalLevel(nAxis, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmHomeSetSignalLevel() return fail, Axis:{nAxis}, {nRet}");
                            }

                            // Encoder Input
                            uInt32Temp = 0x3;
                            nRet = (int)CAXM.AxmMotSetEncInputMethod(nAxis, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmMotSetEncInputMethod() return fail, Axis:{nAxis}, Mode:{uInt32Temp}, {nRet}");
                            }

                            // Pulse Output\
                            uInt32Temp = 0x4;
                            nRet = (int)CAXM.AxmMotSetPulseOutMethod(nAxis, uInt32Temp);
                            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                            {
                                Debug.WriteLine($"* CAXM.AxmMotSetPulseOutMethod() return fail, Axis:{nAxis}, Mode:{uInt32Temp}, {nRet}");
                            }

                        }

                    } //of if ATL open
                    else
                    {
                        Debug.WriteLine($"* AXL LibraryOpen() FAIL ! , {sFileName} : {nRet}");
                    }

                    //for (i = 0; i < m_ChannelInfo.Count; i++)
                    //{
                    //    uRet = 0; // xChannelOpen(m_hDriver, m_ChannelInfo[i].sBoardID, (uint)m_ChannelInfo[i].nChannel, ref m_ChannelInfo[i].hHandle);
                    //    Debug.WriteLine($".Open() Channel_{i} -> Handle : {m_ChannelInfo[i].hHandle}, {uRet}");
                    //    if (uRet != 0)        // if the function fails, a nonzero error code.
                    //    {
                    //        Debug.WriteLine($"*Open() fail, Channel_{i} : {uRet}");
                    //        //? return false;
                    //    }

                    //    m_ChannelInfo[i].bIsOpen = (uRet == 0);
                    //}//of for i

                } //of if ATL is opened
                else
                {
                    // 이미 라이브러리가 Open 되어있다.
                    Debug.WriteLine($". AXL LibraryOpen() OK, ({sFileName} Already opened) : {nRet}");
                    nRet = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"* AJin deivice DLL call exception error, {sFileName} : {ex.Message}");
            }

            return (nRet == 0);         // Open 성공여부
        }

        void Thread_Start()
        {
            Thread = new Thread(new ThreadStart(Read_Loop));
            Thread.Start();
        }


        private int DataTransfer_MotorList()
        {
            nMotorCnt = 0;
            int nArrayCnt = 0;
            foreach (string str in csvData)
            {
                if (string.IsNullOrEmpty(csvData[nArrayCnt + 1, (int)eMotorConfig.swAxis]))
                {
                    return -1;
                }
                else if (nArrayCnt >= (nMotorCnt - 1))
                {
                    break;
                }
                else
                {
                    CData.tMotor[nArrayCnt].swAxis = int.Parse(csvData[nArrayCnt + 1, (int)eMotorConfig.swAxis]);
                    CData.tMotor[nArrayCnt].hwAxis = int.Parse(csvData[nArrayCnt + 1, (int)eMotorConfig.hwAxis]);
                    CData.tMotor[nArrayCnt].sName = csvData[nArrayCnt + 1, (int)eMotorConfig.Name];
                    CData.tMotor[nArrayCnt].sUse = csvData[nArrayCnt + 1, (int)eMotorConfig.Use];
                    CData.tMotor[nArrayCnt].sMode = csvData[nArrayCnt + 1, (int)eMotorConfig.Servo];
                    CData.tMotor[nArrayCnt].nLead_Pitch = int.Parse(csvData[nArrayCnt + 1, (int)eMotorConfig.Lead_Pitch]);
                    CData.tMotor[nArrayCnt].sMv_Dir = csvData[nArrayCnt + 1, (int)eMotorConfig.Mv_Dir];
                    CData.tMotor[nArrayCnt].nInPosWidth = int.Parse(csvData[nArrayCnt + 1, (int)eMotorConfig.InPosWidth]);
                    CData.tMotor[nArrayCnt].nPP1 = int.Parse(csvData[nArrayCnt + 1, (int)eMotorConfig.PP1]);
                    CData.tMotor[nArrayCnt].sHomeLogic = csvData[nArrayCnt + 1, (int)eMotorConfig.HomeLogic];
                    CData.tMotor[nArrayCnt].sHome_Coil = csvData[nArrayCnt + 1, (int)eMotorConfig.Home_Coil];
                    CData.tMotor[nArrayCnt].sLimit_Coil = csvData[nArrayCnt + 1, (int)eMotorConfig.Limit_Coil];
                    CData.tMotor[nArrayCnt].sAlarm_Coil = csvData[nArrayCnt + 1, (int)eMotorConfig.Alarm_Coil];
                    CData.tMotor[nArrayCnt].sZ_Phase = csvData[nArrayCnt + 1, (int)eMotorConfig.Z_Phase];

                    nArrayCnt++;
                }
            }
            return 1;
        }

        // 장치 사용을 종료시켜준다.
        public int Close()
        {

            if (Thread != null)
            {
                Thread.Abort();
                Thread = null;
            }

            if ((IsOpen))
            {

                try
                {


                    if (CAXL.AxlIsOpened() != 0)  // 라이브러리가 Open 되어있는가 ?)
                    {
                        // I/O와 Motion은 동일한 AXL 라이브러리를 사용하므로 Motion 쪽에서 종료하도록 하고 이곳에서는 종료하지 않게 한다.
                        //
                        //  CAXL.AxlClose();            // 라이브러리를 닫아준다.
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"* AJin deivice DLL call exception error : {ex.Message}");
                }
            }
            return 0;
        }

        private void Read_Loop()
        {
            while (IsLoop) // true)
            {
                if (IsOpen)
                {
                    Read_MotionStatus();
                }
         
                Thread.Sleep(1);
            }

            Debug.WriteLine("! Read_MotionStatus Thread end !");
        }


        // Motion 상태를 읽어온다. (loop로 상위에서 모니터링용으로 읽는다)
        public void Read_MotionStatus()
        {

            lock (_lockObj)
            {
                int naxis = 0;
                int nRet = 0;
                uint uState = 0;
                try
                {
                    for (int i = 0; i < (int)eMOT.END; i++)
                    {
                        naxis = i;
                        uState = 0;

                        // Servo On 여부
                        if (CAXM.AxmSignalIsServoOn(naxis, ref _uStateValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                        {
                            mSts[naxis].bServo_On = _uStateValue > 0;                          // Servo On 출력여부
                        }

                        // 원점찾기 성공적 종료 여부
                        if (CAXM.AxmHomeGetResult(naxis, ref _uStateValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                        {
                            mSts[naxis].bHDon = _uStateValue == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS;
                        }

                        // 지정 축의 상태를 읽어온다.
                        nRet = (int)CAXM.AxmStatusReadMotionInfo(naxis, ref tAxis_Info);
                        if (nRet == (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                        {
                            mSts[naxis].bAlarm = (tAxis_Info.uMechSig & 0x10) > 0;  // Alarm
                            mSts[naxis].bInpos = (tAxis_Info.uMechSig & 0x20) > 0;  // Inpos
                            mSts[naxis].bHSen = (tAxis_Info.uMechSig & 0x80) > 0;   // Origin sensor
                            mSts[naxis].bPLSen = (tAxis_Info.uMechSig & 0x01) > 0;  // POT sensor
                            mSts[naxis].bNLSen = (tAxis_Info.uMechSig & 0x02) > 0;  // NOT sensor
                        }
                        // 대체 함수 : AxmStatusReadInMotion()
                        if ((int)CAXM.AxmStatusReadInMotion(naxis, ref uState) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                        {
                            mSts[naxis].bBusy = uState != 0;                 // Busy, In Motion
                            mSts[naxis].dCmdPos = tAxis_Info.dCmdPos;
                            mSts[naxis].dFbPos = tAxis_Info.dActPos;
                        }
                        else
                            mSts[naxis].bBusy = (tAxis_Info.uDrvStat & 0x01) > 0;   // Busy, In Motion

                        // 나머지 상태는 개별 조회 함수를 이용해서 검출한다.
                        CAXM.AxmStatusReadVel(naxis, ref mSts[naxis].dFbVel);   // current velocity
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Read_MotionStatus() Exception error : {ex.Message}");
                }
            }
        }
        // Servo On/Off를 수행한다.
        public bool SetServo(int[] axes, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            int nRet = 0;
            uint Flag = val ? (uint)0x01 : (uint)0x00;

            foreach (int axis in axes)
            {
                nRet = (int)CAXM.AxmSignalServoOn(axis, Flag);   // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoOn({Flag}) return fail, Axis:{axis}, {nRet}");
                }
            }

            return ret;
        }
        public bool GetServoOn(int axis, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            bool bRet = false;
            uint Flag = val ? (uint)0x01 : (uint)0x00;
            bRet = (mSts[axis].bServo_On == val) ? true : false;

            return bRet;
        }

        public bool GetInposition(int axis, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            bool bRet = false;
            uint Flag = val ? (uint)0x01 : (uint)0x00;
            bRet = (mSts[axis].bInpos == val) ? true : false;

            return bRet;
        }

        public bool Getalarm(int axis, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            bool bRet = false;
            uint Flag = val ? (uint)0x01 : (uint)0x00;
            bRet = (mSts[axis].bAlarm == val) ? true : false;

            return bRet;
        }

        public bool GetPLimit(int axis, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            bool bRet = false;
            uint Flag = val ? (uint)0x01 : (uint)0x00;
            bRet = (mSts[axis].bPLSen == val) ? true : false;

            return bRet;
        }
        public bool GetNLimit(int axis, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            bool bRet = false;
            uint Flag = val ? (uint)0x01 : (uint)0x00;
            bRet = (mSts[axis].bNLSen == val) ? true : false;

            return bRet;
        }
        public bool GetHomeSensor(int axis, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            bool bRet = false;
            uint Flag = val ? (uint)0x01 : (uint)0x00;
            bRet = (mSts[axis].bHSen == val) ? true : false;

            return bRet;
        }

        // Servo Alarm을 Clear 한다. Alarm clear 시그널을 On 시켜주므로 추후에 Off를 시켜줘야 한다.
        // 이 함수내에서 Sleep을 사용하면 Blocking이 될 수 있으므로 상위 시퀀스에서 delay time을 주고 Off 시켜주는 SetClearOff() 함수를 호출시켜줘야한다.
        public bool SetClear(int[] axes)
        {
            if (!IsOpen) return false;
            bool ret = true;
            int nRet = 0;

            foreach (int axis in axes)
            {
                nRet = (int)CAXM.AxmSignalServoAlarmReset(axis, 0x01);   // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoAlarmReset(ON) return fail, Axis:{axis}, {nRet}");
                }
            }
            // Alarm Reset On 시켜준 뒤에는 반드시 Off 
            Thread.Sleep(250);

            // Alarm Reset signal Clear
            foreach (int axis in axes)
            {
                nRet = (int)CAXM.AxmSignalServoAlarmReset(axis, 0x00);   // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoAlarmReset(ON) return fail, Axis:{axis}, {nRet}");
                }
            }
            return ret;
        }

        // Servo Alarm을 Clear 하기위한 AlarmReset 한다.
        // Alarm clear 시그널을 On 시켜주므로 추후에 Off를 시켜줘야 한다.
        // 이 함수내에서 Sleep을 사용하면 Blocking이 될 수 있으므로 상위 시퀀스에서 delay time을 주고 Off 시켜주는 SetClearOff() 함수를 호출시켜줘야한다.
        public bool SetClearOff(int[] axes)
        {
            if (!IsOpen) return false;
            bool ret = true;
            int nRet = 0;

            foreach (int axis in axes)
            {
                nRet = (int)CAXM.AxmSignalServoAlarmReset(axis, 0x00);  // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoAlarmReset(OFF) return fail, Axis:{axis}, {nRet}");
                }
            }
            return ret;
        }

        #region 원점 검색
        // 원점찾기를 지령한다.
        public bool Home(int[] axes)
        {
            if (!IsOpen) return false;
            bool bRet = true;
            int nRet = 0;
            int axis = 0;
            uint nHomeSignal = 0;
            int nTemp = 0;
            uint uTemp = 0;
            double dTemp = 0.0;
            uint nLimitStopMode = 0;
            uint uPosLimit = 0;
            uint uNegLimit = 0;


            for (int i = 0; i < axes.Length; i++)
            {
                // 원점찾기를 초기화 한다.
                mSts[i].uHDone = 0x00;

                axis = axes[i];
                // 지정한 축에 원점검색을 진행합니다.
                CAXM.AxmHomeGetMethod(axis, ref nTemp, ref nHomeSignal, ref uTemp, ref dTemp, ref dTemp);
                CAXM.AxmSignalGetLimit(axis, ref nLimitStopMode, ref uPosLimit, ref uNegLimit);
                // 원점 검색을 Home Sensor로 사용할 경우 Limit Sensor 를 Disable 로 변경
                if (nHomeSignal == 4)
                {
                    CAXM.AxmSignalSetLimit(axis, 0, 2, 2);
                }
                // 원점 검색 시작 
                nRet = (int)CAXM.AxmHomeSetStart(axis);

                // Limit Sensor 를 Disable 에서 사용자가 초기화 때 설정한 파라메터로 원복
                if (nHomeSignal == 4)
                {
                    CAXM.AxmSignalSetLimit(axis, nLimitStopMode, uPosLimit, uNegLimit);
                }

                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    Debug.WriteLine($"* CAXM.AxmHomeSetStart({axes[i]}) return fail : {nRet}");
                    bRet = false;
                }
            }
            return bRet;
        }

        // 원점찾기를 취소한다.
        // 아진은 이동을 중지시킨다.
        public bool HomeCancel(int[] axes)
        {
            if (!IsOpen) return false;
            return Stop(axes);
        }

        // 원점찾기 완료 flag을 지정한다.
        // bool val :
        //			true : 검색 완료로 지정
        //			false : 검색 진행중 (미완료)로 지정
        public bool SetHomeDone(int[] axes, bool val)
        {
            if (!IsOpen) return false;
            bool ret = true;
            int nRet = 0;
            uint uTemp_Flag = 0;
            uint Flag = val ? (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS : (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING;

            foreach (int axis in axes)
            {
                uTemp_Flag = CAXM.AxmHomeGetResult(axis, ref _uStateValue);
                if (uTemp_Flag > (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING)
                {
                    mSts[axis].uHDone = uTemp_Flag;
                }
                else if (uTemp_Flag == (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING)
                {
                    mSts[axis].uHDone = uTemp_Flag;
                }
                else if (uTemp_Flag == (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS)
                {// 원점찾기 성공적 종료 여부
                    // 원점찾기를 set 한다.
                    mSts[axis].uHDone = 1;
                    SetEncPosition(axis, 0);
                    Debug.WriteLine($"* CAXM.AxmHomeGetetResult({val}) return sucess, Axis:{axis}, {nRet}");
                }
                else
                {
                    // 원점찾기를 reset 한다.
                    mSts[axis].uHDone = 0;
                }
                //if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                //{
                //    ret = false;            // 수행 실패
                //    Debug.WriteLine($"* CAXM.AxmHomeSetResult({val}) return fail, Axis:{axis}, {nRet}");
                //}
            }
            return ret;
        }
        #endregion

        // Command position 값을 지정한다.
        public bool SetCommand(int nAxisNo, double dbNewPos)
        {
            if (!IsOpen) return false;
            int nRet = (int)CAXM.AxmStatusSetCmdPos(nAxisNo, dbNewPos);
            if (nRet == (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)                    // 함수 수행 결과
            {
                return true;
            }
            else Debug.WriteLine($"* CAXM.AxmStatusSetCmdPos return fail : {nRet}");

            return false;
        }


        // Encoder position 값을 지정한다.
        public bool SetEncPosition(int nAxisNo, double dbNewPos)
        {
            if (!IsOpen) return false;
            int nRet = (int)CAXM.AxmStatusSetActPos(nAxisNo, dbNewPos);
            if (nRet == (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                return true;
            }
            else Debug.WriteLine($"* CAXM.AxmStatusSetActPos return fail : {nRet}");

            return false;
        }


        // 현재 위치를 0으로 지정한다.
        public bool SetZero(int[] axes)
        {
            if (!IsOpen) return false;
            bool ret = true;
            foreach (int axis in axes)
            {
                // Command position to zero
                ret = SetCommand(axis, 0);

                // Encoder feedback position to zero
                ret = ret && SetEncPosition(axis, 0);
            }

            return ret;
        }

        // 지정위치로 이동하도록 지령한다.
        // (각 파라메터의 배열 크기는 상위에서 책임지고 문제가 없도록 지정하여 호출해야한다)
        public bool MovePos(int[] axes, double[] pos, double[] vel, double[] acc, double[] dec)
        {
            if (!IsOpen) return false;
            bool ret = true;
            int nRet = 0;
            uint nProfile = 0;

            // 이동 모드를 설정하고
            for (int i = 0; i < axes.Length; i++)
            {
                //[00h] 펄스 출력 방식:AXT_MOTION_ABSREL_MODE_DEF
                //    - [00h] 위치 구동 절대 모드
                //    - [01h] 위치 구동 상대 모드
                nRet = (int)CAXM.AxmMotSetAbsRelMode(axes[i], 0x00);   // 절대위치 이동 지정
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;
                    Debug.WriteLine($"* CAXM.AxmMotSetAbsRelMode({axes[i]}) return fail : {nRet}");
                }

                // 속도 프로파일 지정
                nProfile = (acc[i] == dec[i]) ? (uint)0x00 : (uint)0x01;           // 대칭/비대칭 사다리꼴 지정

                nRet = (int)CAXM.AxmMotSetProfileMode(axes[i], (uint)nProfile);   // 속도 profile 지정
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    Debug.WriteLine($"* MoveAbs() CAXM.AxmMotSetProfileMode({axes[i]}) return fail : {nRet}");
                    ret = false;
                }

                // 가/감속 단위를 밀리초 -> 초 단위로 변경
                acc[i] *= MSToSEC;
                dec[i] *= MSToSEC;
            }

            // 이동 모드가 정상적으로 설정되었다면 이동 지령을 내린다.
            if (ret)
            {

                //// 다축 동시 이동 명령
                //nRet = (int)CAXM.AxmMoveStartMultiPos(axes.Length, axes, pos, vel, acc, dec);   // 이동 지정
                //if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                //{
                //	ret = false;
                //	Debug.WriteLine($"* CAXM.AxmMoveStartMultiPos() return fail : {nRet}");
                //}

                // 단축으로 나누어서 차례로 지령

                for (int i = 0; i < axes.Length; i++)
                {
                    nRet = (int)CAXM.AxmMoveStartPos(axes[i], pos[i], vel[i], acc[i], dec[i]);   // 이동 지정
                    if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    {
                        ret = false;
                        Debug.WriteLine($"* CAXM.AxmMoveStartPos({i}) return fail : {nRet}");
                    }
                }
            }

            return ret;
        }


        // 지정한 거리만큼 상대이동을 수행한다.
        public bool MoveStep(int[] axes, double[] step, double[] vel, double[] acc, double[] dec)
        {
            if (!IsOpen) return false;
            bool ret = true;
            int nRet = 0;
            uint nProfile = 0;

            // 이동 모드를 설정하고
            for (int i = 0; i < axes.Length; i++)
            {
                //[00h] 펄스 출력 방식:AXT_MOTION_ABSREL_MODE_DEF
                //    - [00h] 위치 구동 절대 모드
                //    - [01h] 위치 구동 상대 모드
                nRet = (int)CAXM.AxmMotSetAbsRelMode(axes[i], 0x01);   // 상대위치 이동 지정
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;
                    Debug.WriteLine($"* CAXM.AxmMotSetAbsRelMode({axes[i]}) return fail : {nRet}");
                }

                // 속도 프로파일 지정
                nProfile = (acc[i] == dec[i]) ? (uint)0x00 : (uint)0x01;           // 대칭/비대칭 사다리꼴 지정

                nRet = (int)CAXM.AxmMotSetProfileMode(axes[i], (uint)nProfile);   // 속도 profile 지정
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    Debug.WriteLine($"* MoveAbs() CAXM.AxmMotSetProfileMode({axes[i]}) return fail : {nRet}");
                    ret = false;
                }

                // 가/감속 단위를 밀리초 -> 초 단위로 변경
                acc[i] *= MSToSEC;
                dec[i] *= MSToSEC;
            }

            // 이동 모드가 정상적으로 설정되었다면 이동 지령을 내린다.
            if (ret)
            {

                // 다축 동시 이동 명령
                //nRet = (int)CAXM.AxmMoveStartMultiPos(axes.Length, axes, step, vel, acc, dec);   // 이동 지정
                //if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                //{
                //	ret = false;
                //	Debug.WriteLine($"* CAXM.AxmMoveStartMultiPos() return fail : {nRet}");
                //}

                // 2022-01-20, jhLee,  Multi move 명령의 아진 라이브러리 버그로 인하여 Single 축 이동명령으로 변경
                //
                for (int i = 0; i < axes.Length; i++)
                {
                    nRet = (int)CAXM.AxmMoveStartPos(axes[i], step[i], vel[i], acc[i], dec[i]);   // 이동 지정
                    if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    {
                        ret = false;
                        Debug.WriteLine($"* CAXM.AxmMoveStartPos({i}) return fail : {nRet}");
                    }
                }
            }

            return ret;
        }


        // JOG 이동을 지령한다.
        public bool Jog(int axis, double vel, double acc)
        {
            if (!IsOpen) return false;
            int nRet = (int)CAXM.AxmMoveVel(axis, vel, (acc * MSToSEC), (acc * MSToSEC));   // JOG 이동 지정
            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                Debug.WriteLine($"* CAXM.AxmMoveVel({axis}) return fail : {nRet}");
                return false;
            }

            return true;
        }

        public bool OvrVelocity(int axis, double vel)
        {
            if (!IsOpen) return false;
            return true;
        }

        public bool OvrPosition(int axis, double pos)
        {
            if (!IsOpen) return false;
            return true;
        }


        // 아진보드에서는 지원 불가, 상위레벨에서 구현해줘야한다.
        public bool Pause(int[] axes)
        {
            if (!IsOpen) return false;
            return true;
        }

        // 아진 보드에서는 지원 불가,  상위레벨에서 구현해줘야한다.
        public bool Resume(int[] axes)
        {
            return true;
        }

        // 지정 축들을 정지 시킨다.
        public bool Stop(int[] axes)
        {
            if (!IsOpen) return false;
            bool bRet = true;
            int nRet = 0;

            for (int i = 0; i < axes.Length; i++)
            {
                nRet = (int)CAXM.AxmMoveSStop(axes[i]);        // 감속 정지 지령
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    Debug.WriteLine($"* CAXM.AxmMoveSStop({axes[i]}) return fail : {nRet}");
                    bRet = false;
                }
            }

            return bRet;
        }
        public bool Stop(int axis)
        {
            if (!IsOpen) return false;
            bool bRet = true;
            int nRet = 0;

            nRet = (int)CAXM.AxmMoveSStop(axis);        // 감속 정지 지령
            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                Debug.WriteLine($"* CAXM.AxmMoveSStop({axis}) return fail : {nRet}");
                bRet = false;
            }

            return bRet;
        }

        // 지정 축들을 비상정지 시킨다.
        //Stop(new int[1] { nSelMotorNo });
        public bool EStop(int[] axes)
        {
            if (!IsOpen) return false;
            bool bRet = true;
            int nRet = 0;

            for (int i = 0; i < axes.Length; i++)
            {
                nRet = (int)CAXM.AxmMoveEStop(axes[i]);        // 감속 정지 지령
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    Debug.WriteLine($"* CAXM.AxmMoveEStop({axes[i]}) return fail : {nRet}");
                    bRet = false;
                }
            }

            return bRet;
        }
        public bool EStop(int axis)
        {
            if (!IsOpen) return false;
            bool bRet = true;
            int nRet = 0;

            nRet = (int)CAXM.AxmMoveEStop(axis);        // 감속 정지 지령
            if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                Debug.WriteLine($"* CAXM.AxmMoveEStop({axis}) return fail : {nRet}");
                bRet = false;
            }

            return bRet;
        }

    }
}
