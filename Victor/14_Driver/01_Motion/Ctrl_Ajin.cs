using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Victor.HardWare
{
    public class Ctrl_Ajin
    {
        protected bool IsConnect = false;
        private string sMotionDataPath;
        private string sFolderPath;
        private string sFileName;

        public static string[,] csvData;
        static int nMotorCnt = 0;

        public Ctrl_Ajin(string sPathName)
        {
            sMotionDataPath = sPathName;
            Init_View_Set();
        }

        private void Init_View_Set()
        {
            int i = 0;
            int FindDot = sMotionDataPath.LastIndexOf(".");
            int Lastsp = sMotionDataPath.LastIndexOf("\\");

            sFileName = sMotionDataPath.Substring(Lastsp + 1, FindDot - Lastsp - 1);
            sFolderPath = sMotionDataPath.Replace(sFileName + ".csv", "");
            ReadFile_MotorList();
            Init_Motor();
        }

        public int ReadFile_MotorList()
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

        private int DataTransfer_MotorList()
        {
            nMotorCnt = 0;
            int nArrayCnt = 0;
            foreach (string str in csvData)
            {
                if (string.IsNullOrEmpty(csvData[nArrayCnt + 1, (int)eMotor.swAxis]))
                {
                    return -1;
                }
                else if (nArrayCnt >= (nMotorCnt - 1))
                {
                    break;
                }
                else
                {
                    CData.tMotor[nArrayCnt].swAxis = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.swAxis]);
                    CData.tMotor[nArrayCnt].hwAxis = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.hwAxis]);
                    CData.tMotor[nArrayCnt].sName = csvData[nArrayCnt + 1, (int)eMotor.Name];
                    CData.tMotor[nArrayCnt].sUse = csvData[nArrayCnt + 1, (int)eMotor.Use];
                    CData.tMotor[nArrayCnt].sMode = csvData[nArrayCnt + 1, (int)eMotor.Servo];
                    CData.tMotor[nArrayCnt].nLead_Pitch = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.Lead_Pitch]);
                    CData.tMotor[nArrayCnt].sMv_Dir = csvData[nArrayCnt + 1, (int)eMotor.Mv_Dir];
                    CData.tMotor[nArrayCnt].nInPosWidth = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.InPosWidth]);
                    CData.tMotor[nArrayCnt].nPP1 = int.Parse(csvData[nArrayCnt + 1, (int)eMotor.PP1]);
                    CData.tMotor[nArrayCnt].sHomeLogic = csvData[nArrayCnt + 1, (int)eMotor.HomeLogic];
                    CData.tMotor[nArrayCnt].sHome_Coil = csvData[nArrayCnt + 1, (int)eMotor.Home_Coil];
                    CData.tMotor[nArrayCnt].sLimit_Coil = csvData[nArrayCnt + 1, (int)eMotor.Limit_Coil];
                    CData.tMotor[nArrayCnt].sAlarm_Coil = csvData[nArrayCnt + 1, (int)eMotor.Alarm_Coil];
                    CData.tMotor[nArrayCnt].sZ_Phase = csvData[nArrayCnt + 1, (int)eMotor.Z_Phase];

                    nArrayCnt++;
                }
            }
            return 1;
        }

        protected bool Init_Motor()
        {
            int nRet = 0;
            int nAxis = 0;
            double dGearNumerator = 1000.0;
            uint uInt32Temp;

            //var a = Victor.vwMotorList.csvData[0, (int)eMotor.swAxis];
            try
            {
                nRet = CAXL.AxlIsOpened();  // 라이브러리가 Open 되어있는가 ?
                if (nRet == 0)              // 라이브러리가 초기화 되어있지 않음
                {
                    nRet = (int)CAXL.AxlOpen(0);            // AXL 라이브러리Open

                    if (nRet == (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)         // 라이브러리 Open 성공
                    {
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
                //Debug.WriteLine($"! AJin deivice is simulator device");
            }

            return (nRet == 0);         // Open 성공여부
        }

        // 장치 사용을 종료시켜준다.
        protected int _Close()
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

            return 0;
        }

        // Servo On/Off를 수행한다.
        public bool SetServo(int[] axes, bool val)
        {
            bool ret = true;
            int nRet = 0;
            uint Flag = val ? (uint)0x01 : (uint)0x00;

            foreach (int axis in axes)
            {
                if (IsSim)
                {
                    if (_SimConfig.ContainsKey(axis))
                    {
                        THwMotConfig Data = _SimConfig[axis];
                        Data.servo = val;                          // Servo On 출력여부를 지정
                        Data.inPos = val;

                        _SimConfig[axis] = Data;
                    }

                    continue;
                }


                nRet = (int)CAXM.AxmSignalServoOn(axis, Flag);   // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoOn({Flag}) return fail, Axis:{axis}, {nRet}");
                }
            }

            return ret;
        }


        // Servo Alarm을 Clear 한다. Alarm clear 시그널을 On 시켜주므로 추후에 Off를 시켜줘야 한다.
        // 이 함수내에서 Sleep을 사용하면 Blocking이 될 수 있으므로 상위 시퀀스에서 delay time을 주고 Off 시켜주는 SetClearOff() 함수를 호출시켜줘야한다.
        public bool SetClear(int[] axes)
        {
            bool ret = true;
            int nRet = 0;

            foreach (int axis in axes)
            {
                if (IsSim)
                {
                    if (_SimConfig.ContainsKey(axis))
                    {
                        THwMotConfig Data = _SimConfig[axis];
                        Data.alarm = false;                          // Servo On 출력여부를 지정

                        _SimConfig[axis] = Data;
                    }

                    continue;
                }

                nRet = (int)CAXM.AxmSignalServoAlarmReset(axis, 0x01);   // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoAlarmReset(ON) return fail, Axis:{axis}, {nRet}");
                }
            }

            Thread.Sleep(250);              // Alarm Reset On 시켜준 뒤에는 반드시 Off 시켜줘야하는데, 상위에서 Off 시켜주는 루틴이 따로없어서 이곳에서 굳이 시간을 지연시켜준 뒤 Off 시켜준다.

            // Alarm Reset signal Clear
            foreach (int axis in axes)
            {
                if (!IsSim)
                {
                    nRet = (int)CAXM.AxmSignalServoAlarmReset(axis, 0x00);   // 0x00 : Off,  0x01 : On
                    if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                    {
                        ret = false;            // 수행 실패
                        Debug.WriteLine($"* CAXM.AxmSignalServoAlarmReset(ON) return fail, Axis:{axis}, {nRet}");
                    }
                }
            }

            return ret;
        }


        // Servo Alarm을 Clear 하기위한 AlarmReset 한다. Alarm clear 시그널을 On 시켜주므로 추후에 Off를 시켜줘야 한다.
        // 이 함수내에서 Sleep을 사용하면 Blocking이 될 수 있으므로 상위 시퀀스에서 delay time을 주고 Off 시켜주는 SetClearOff() 함수를 호출시켜줘야한다.
        public bool SetClearOff(int[] axes)
        {
            bool ret = true;
            int nRet = 0;

            foreach (int axis in axes)
            {
                if (IsSim) continue;

                nRet = (int)CAXM.AxmSignalServoAlarmReset(axis, 0x00);  // 0x00 : Off,  0x01 : On
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmSignalServoAlarmReset(OFF) return fail, Axis:{axis}, {nRet}");
                }
            }

            return ret;
        }


        // 원점찾기 완료 flag을 지정한다.
        // bool val :
        //			true : 검색 완료로 지정
        //			false : 검색 진행중 (미완료)로 지정
        public bool SetHomeDone(int[] axes, bool val)
        {
            bool ret = true;
            int nRet = 0;
            uint Flag = val ? (uint)AXT_MOTION_HOME_RESULT.HOME_SUCCESS : (uint)AXT_MOTION_HOME_RESULT.HOME_SEARCHING;

            foreach (int axis in axes)
            {
                if (IsSim)
                {
                    if (_SimConfig.ContainsKey(axis))
                    {
                        THwMotConfig Data = _SimConfig[axis];
                        Data.hDone = val;                          // Home Done 값을 지정

                        _SimConfig[axis] = Data;
                    }
                    continue;
                }


                // 아래 함수를 실행하면 원점찾기 명령이 이미 수행중이라며 오류를 리턴한다.
                // 아진 제어기에서는 H/W적인 HomeDone flag를 Reset해줄 수 없다.
                // nRet = (int)CAXM.AxmHomeSetResult(axis, Flag);
                if (nRet != (int)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                {
                    ret = false;            // 수행 실패
                    Debug.WriteLine($"* CAXM.AxmHomeSetResult({val}) return fail, Axis:{axis}, {nRet}");
                }
            }

            return ret;
        }


        // Command position 값을 지정한다.
        public bool SetCommand(int nAxisNo, double dbNewPos)
        {
            if (IsSim)
            {
                if (_SimConfig.ContainsKey(nAxisNo))
                {
                    THwMotConfig Data = _SimConfig[nAxisNo];
                    Data.cmd = dbNewPos;                          // 지령 위치 갱신

                    _SimConfig[nAxisNo] = Data;
                }
                return true;
            }


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
            if (IsSim)
            {
                if (_SimConfig.ContainsKey(nAxisNo))
                {
                    THwMotConfig Data = _SimConfig[nAxisNo];
                    Data.enc = dbNewPos;                          // feedback 위치 갱신

                    _SimConfig[nAxisNo] = Data;
                }
                return true;
            }


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
            if (IsSim)      // 가상 모드일 경우 지정 위치로 이동을 완료하였다고 지정한다.
            {
                for (int i = 0; i < axes.Length; i++)
                {
                    if (_SimConfig.ContainsKey(axes[i]))
                    {
                        THwMotConfig Data = _SimConfig[axes[i]];
                        Data.cmd = pos[i];                          // 현재 위치를 목표 위치로 지정
                        Data.enc = pos[i];

                        _SimConfig[axes[i]] = Data;
                    }
                }

                return true;
            }


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
            if (IsSim)      // 가상 모드일 경우 지정 위치로 이동을 완료하였다고 지정한다.
            {
                for (int i = 0; i < axes.Length; i++)
                {
                    if (_SimConfig.ContainsKey(axes[i]))
                    {
                        THwMotConfig Data = _SimConfig[axes[i]];
                        Data.cmd += step[i];                          // 현재 위치를 목표 위치로 지정
                        Data.enc += step[i];

                        _SimConfig[axes[i]] = Data;
                    }
                }

                return true;
            }



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
            if (IsSim) return true;

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
            return true;
        }

        public bool OvrPosition(int axis, double pos)
        {
            return true;
        }


        // 원점찾기를 지령한다.
        public bool Home(int[] axes)
        {
            if (IsSim)      // 가상 모드일 경우 지정 위치로 이동을 완료하였다고 지정한다.
            {
                for (int i = 0; i < axes.Length; i++)
                {
                    if (_SimConfig.ContainsKey(axes[i]))
                    {
                        THwMotConfig Data = _SimConfig[axes[i]];
                        Data.cmd = 0;                          // 현재 위치는 원점이다.
                        Data.enc = 0;
                        Data.hDone = true;                      // 원점찾기를 완료하였다.

                        _SimConfig[axes[i]] = Data;
                    }
                }

                return true;
            }



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


            // 원점찾기를 초기화 한다.
            //d SetHomeDone(axes, false);

            for (int i = 0; i < axes.Length; i++)
            {
                axis = axes[i];
                // 지정한 축에 원점검색을 진행합니다.

                //				if (axis == 0)
                {
                    CAXM.AxmHomeGetMethod(axis, ref nTemp, ref nHomeSignal, ref uTemp, ref dTemp, ref dTemp);

                    CAXM.AxmSignalGetLimit(axis, ref nLimitStopMode, ref uPosLimit, ref uNegLimit);

                    // 2022.03.21 AJIN HOME Bug
                    // SMC-2V04 제품 사용 시 POS Limit 감지 중  원점 검색 하면 오동작
                    // 원점 검색을 Home Sensor로 사용할 경우 Limit Sensor 를 Disable 로 변경
                    if (nHomeSignal == 4)
                    {
                        CAXM.AxmSignalSetLimit(axis, 0, 2, 2);
                    }

                    // 원점 검색 시작 
                    nRet = (int)CAXM.AxmHomeSetStart(axis); // axes[i]);

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
                //else
                //            {
                //	nRet = (int)CAXM.AxmHomeSetStart(axis); // axes[i]);
                //}
            }


            return bRet;
        }

        // 원점찾기를 취소한다.
        // 아진은 이동을 중지시킨다.
        public bool HomeCancel(int[] axes)
        {
            return Stop(axes);
        }


        // 아진보드에서는 지원 불가, 상위레벨에서 구현해줘야한다.
        public bool Pause(int[] axes)
        {
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
            if (IsSim) return true;             // 가상 모드일 경우 

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

        // 지정 축들을 비상정지 시킨다.
        public bool EStop(int[] axes)
        {
            if (IsSim) return true;             // 가상 모드일 경우 

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

    }
}
