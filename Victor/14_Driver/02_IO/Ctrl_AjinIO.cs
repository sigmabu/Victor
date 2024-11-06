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
    public class Ctrl_AjinIo
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

        public Ctrl_AjinIo(string sPathName)
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
            Init_ReadFile_IoList();
            Init_Io();
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

        public int Init_ReadFile_IoList()
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

        protected bool Init_Io()
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


                    } //of if ATL open
                    else
                    {
                        Debug.WriteLine($"* AXL LibraryOpen() FAIL ! , {sFileName} : {nRet}");
                    }

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
                    //Read_MotionStatus();
                }
         
                Thread.Sleep(1);
            }
            Debug.WriteLine("! Read_MotionStatus Thread end !");
        }

        // 지정된 1개 비트의 값을 취득한다.
        /// <summary>
        /// uint a = (uint)eIn.EMO_SWITCH_X000;
        ///  bool bbb = HW.mIo.ReadInBit(a);
        /// </summary>
        /// <param name="nIn_No"></param>
        /// <returns></returns>
        public bool ReadInBit(uint nIn_No)
        {
            if (!IsOpen) return false;
            uint uValue = 1;

            Int32 uUnitNo = (Int32)(nIn_No >> 8);
            Int32 nOffset = (Int32)(nIn_No & 0xff);
            if (CAXD.AxdiReadInportBit(uUnitNo, nOffset, ref uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                return (uValue == 1) ? true : false;
            }
            else return false;                
        }

        public bool ReadInBit(int nUnitNo, int nOffset, ref uint uValue)
        {
            if (!IsOpen) return false;
            {
                return CAXD.AxdiReadInportBit(nUnitNo, nOffset, ref uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }


        // 지정된 1개 바이트의 값을 취득한다.
        public bool ReadInByte(int nUnitNo, int nOffset, ref uint uValue)
        {
            if (IsOpen)
            {
                return CAXD.AxdiReadInportByte(nUnitNo, nOffset, ref uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }

        // 지정된 1개 출력 비트의 값을 읽는다.
        public bool ReadOutBit(int nUnitNo, int nOffset, ref uint uValue)
        {
            if (IsOpen)
            {
                return CAXD.AxdoReadOutportBit(nUnitNo, nOffset, ref uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }

        // 지정된 1개 비트의 값을 내보낸다.
        public bool WriteOutBit(uint nOut_No, uint uValue)
        {
            if (!IsOpen) return false;

            Int32 uUnitNo = (Int32)(nOut_No >> 8);
            Int32 nOffset = (Int32)(nOut_No & 0xff);
            if (CAXD.AxdoWriteOutportBit(uUnitNo, nOffset, uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                return true ;
            }
            else return false;
        }

        public bool WriteOutBit(int nUnitNo, int nOffset, uint uValue)
        {
            if (IsOpen)
            {
                return CAXD.AxdoWriteOutportBit(nUnitNo, nOffset, uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }

        // 지정된 1개 바이트의 값을 취득한다.
        public bool WriteOutByte(int nUnitNo, int nOffset, uint uValue)
        {
            if (IsOpen)
            {
                return CAXD.AxdoWriteOutportByte(nUnitNo, nOffset, uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }



        // 지정된 1개 바이트의 값을 취득한다.
        public bool ReadOutByte(int nUnitNo, int nOffset, ref uint uValue)
        {
            if (IsOpen)
            {
                return CAXD.AxdoReadOutportByte(nUnitNo, nOffset, ref uValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }


        #region Analog process
        /// <summary>
        ///  Anaolg 입력 범위를 설정한다.
        /// </summary>
        /// <param name="nUnitNo">Module Unit 번호</param>
        /// <param name="nCh">채널</param>
        /// <param name="dbMin">범위 최소값</param>
        /// <param name="dbMax">범위 최대값</param>
        /// <returns></returns>
        public bool SetAInputRange(int nUnitNo, int nCh, double dbMin, double dbMax)
        {
            if (IsOpen)
            {
                return CAXA.AxaiSetRange(nCh, dbMin, dbMax) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }

        /// <summary>
        /// 지정한 입력 채널에 입력된 값을 조회한다.
        /// </summary>
        /// <param name="nUnitNo">Module Unit 번호</param>
        /// <param name="nCh">채널</param>
        /// <param name="dbValue">입력된 Analog 값</param>
        /// <returns></returns>
        public bool ReadInAnalog(int nUnitNo, int nCh, ref double dbValue)
        {
            if (IsOpen)
            {
                return CAXA.AxaiSwReadVoltage(nCh, ref dbValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }

        /// <summary>
        ///  Anaolg 출력 범위를 설정한다.
        /// </summary>
        /// <param name="nUnitNo">Module Unit 번호</param>
        /// <param name="nCh">채널</param>
        /// <param name="dbMin">범위 최소값</param>
        /// <param name="dbMax">범위 최대값</param>
        /// <returns></returns>
        public bool SetAOutputRange(int nUnitNo, int nCh, double dbMin, double dbMax)
        {
            if (IsOpen)
            {
                return CAXA.AxaoSetRange(nCh, dbMin, dbMax) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }


        /// <summary>
        /// 지정한 출력 채널에 입력한 값을 전압으로 출력한다.
        /// </summary>
        /// <param name="nUnitNo">Module Unit 번호</param>
        /// <param name="nCh">채널</param>
        /// <param name="dbValue">출력 Analog 값</param>
        /// <returns></returns>
        public bool WriteOutAnalog(int nUnitNo, int nCh, double dbValue)
        {
            if (IsOpen)
            {
                return CAXA.AxaoWriteVoltage(nCh, dbValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }

        /// <summary>
        ///  현재 출력중인 Analog Output 값을 조회한다.
        /// </summary>
        /// <param name="nUnitNo">Module Unit 번호</param>
        /// <param name="nCh">채널</param>
        /// <param name="dbValue">출력중인 Analog 값</param>
        /// <returns></returns>
        public bool ReadOutAnalog(int nUintNo, int nCh, ref double dbValue)
        {
            if (IsOpen)
            {
                return CAXA.AxaoReadVoltage(nCh, ref dbValue) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS;
            }

            return false;
        }


        #endregion // of #region Analog process
    }
}
