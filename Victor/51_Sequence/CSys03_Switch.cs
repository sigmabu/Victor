using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Text;

namespace Victor
{
    public class CSys03_Switch : SingleTone<CSys03_Switch>
    {
        delegate void pDelegateFun();
        static pDelegateFun NextFun = null;
        DateTime Now = DateTime.Now;
        private int PowerOnFlag;
        //
        private CTim[] delay = new CTim[50];

        private int nCnt = 0;
        private string sData;
        private int Prg_cnt = 0;
        private static int cnt = 0;
        //private ETowerStatus m_TWState = ETowerStatus.Idle;         // Towerlamp의 상태를 결정
        //private EBuzz m_TWBuzzer = EBuzz.Off;                       // 마지막으로 On 되었던 Buzzer 기억
        protected ELog eLogType;
        private enum nTm
        {
            bz2_time,
            bz5_time
        }

        private CSys03_Switch()
        {
            PowerOnFlag = 0;
            //m_Time = new CTim[50];
            delay[(int)nTm.bz2_time] = new CTim();
            delay[(int)nTm.bz5_time] = new CTim();

            GVar.mKeyGui.bOutput_Halt = false;

            delay[(int)nTm.bz2_time].Start(5000);
            delay[(int)nTm.bz5_time].Start(5000);

            //eLogType = ELog.SWITCH;

        }

        ~CSys03_Switch()
        {
            PowerOnFlag = 0;
            NextFun = null;
        }

        /// <summary>
        /// Error 해제 Function
        /// </summary>
        private void Error_clear_fun()
        {
            int i = 0;
        }
        /// <summary>
        /// Error Occur 진행시 function
        /// </summary>
        private void Error_occur_fun()
        {
            int i = 0;
            GVar.mKeyCmd.bError_flag = true;
            GConst.EqStatus = EQStatus.Err_Status;
        }

        /// <summary>
        /// Push Button 또는 GUI Command 처리 함수
        /// </summary>
        private void Push_button_Key_fun()
        {
            Prg_cnt = 5;

            //if ((GVar.mKeyGui.bStop_flag == true) || (GVar.mKeyBtn.bStop_flag == true))
            //{// Stop Key Fun
            //    CSy21_Base.It.Stop_Key_Fun();
            //}
            //else if ((GVar.mKeyGui.bReset_key == true) || (GVar.mKeyBtn.bReset_key == true))
            //{// reset Key
            //    CSy21_Base.It.Reset_Key_Fun();
            //}
            //else if ((GVar.mKeyGui.bAuto_key == true) || (GVar.mKeyBtn.bAuto_key == true))
            //{// Auto start key
            //    CSy21_Base.It.Auto_Start_Key_Fun();
            //}

            GVar.mKeyCmd.bStop_flag = false;

            NextFun = null;
        }

        /// <summary>
        /// Switch Lamp On/Off 부분
        /// </summary>
        private void SwitchLamp_fun()
        {
            //Prg_cnt = 4;
            //bool bTest_Falg = true;

            //// start lamp
            //if ((START_Switch(ESWITCH.Check, ESWITCH.Lamp_On) == ESWITCH.Push_On) 
            //    )
            //{
            //    START_Switch(ESWITCH.Set, ESWITCH.Lamp_On);
            //    GVar.mKeyBtn.bAuto_key = true;
            //}
            //else
            //{
            //    START_Switch(ESWITCH.Set, ESWITCH.Lamp_Off);
            //    GVar.mKeyBtn.bAuto_key = false;
            //}

            //// stop lamp
            //if ((STOP_Switch(ESWITCH.Check, ESWITCH.Lamp_On) == ESWITCH.Push_On) 
            //    )

            //{
            //    SwitchStop_Lamp(1);// Switch 눌리면 Lamp On
            //    GVar.mKeyBtn.bStop_flag = true;
            //}
            //else
            //{
            //    if (CVar.bAuto_Some_Active) SwitchStop_Lamp(2);// Switch Lamp Flicker
            //    else SwitchStop_Lamp(0);// Switch Lamp Off

            //    GVar.mKeyBtn.bStop_flag = false;
            //}

            //// reset lamp
            //if (RESET_Switch(ESWITCH.Check, ESWITCH.Lamp_On) == ESWITCH.Push_On)
            //{
            //    SwitchReset_Lamp(1);// Switch 눌리면 Lamp On
            //    if ((GConst.EqStatus_00 == EQStatus.Stop_Status) ||
            //        (GConst.EqStatus_00 == EQStatus.Err_Status) || (GConst.EqStatus_01 == EQStatus.Alarm_Status))
            //    { // 가동중이 아니고, 메뉴얼 동이 아니고, Initial 동작이 아닐때 Error 이며 Switch 눌렸을때 Lamp On
            //        GVar.mKeyBtn.bReset_key = true;
            //    }
            //}
            //else
            //{
            //    if ((GConst.EqStatus_01 == EQStatus.Err_Status) || (GConst.EqStatus_01 == EQStatus.Alarm_Status))
            //    {
            //        SwitchReset_Lamp(2);// Error 일때 Flicker
            //    }
            //    else SwitchReset_Lamp(0);// Switch 눌리면 Lamp Off
            //    GVar.mKeyBtn.bReset_key = false;
            //}
            //NextFun = Push_button_Key_fun;
        }

        /// <summary>
        /// 설비의 Tower_Lamp_Check 발생시 Alarm 처리 하는 함수
        /// </summary>
        ///         

        private void TowerLamp_fun()
        {
            //Prg_cnt = 3;
                       

            ////
            //// 설비의 각 상태를 Signal Tower의 표현 상태로 mapping 한다.
            ////
            //if (GConst.EqStatus_00 == EQStatus.Err_Status)
            //{
            //    if ((GConst.EqStatus == EQStatus.Run_Status) ||
            //        (GConst.EqStatus == EQStatus.Manual_Status) ||
            //        (GConst.EqStatus == EQStatus.All_Initial_Status))
            //    {// 가동중에는 Flicker
            //        m_TWState = ETowerStatus.ToStop;            // 중지로 전환하기위한 과정
            //    }
            //    else
            //    {
            //        m_TWState = ETowerStatus.Error;            // Error 상태
            //    }
            //}
            //else if (GConst.EqStatus_01 == EQStatus.Alarm_Status)
            //{
            //    if ((GConst.EqStatus == EQStatus.Run_Status) ||
            //        (GConst.EqStatus == EQStatus.Manual_Status) ||
            //        (GConst.EqStatus == EQStatus.All_Initial_Status))
            //    {// 가동중에는 Flicker
            //        m_TWState = ETowerStatus.ToStop;            // 중지로 전환하기위한 과정
            //    }
            //    else
            //    {
            //        m_TWState = ETowerStatus.Warring;
            //    }

            //}
            //else if (GConst.EqStatus == EQStatus.Run_Status)
            //{
            //    m_TWState = ETowerStatus.Run;

            //    // 설비내 제품이 없는 경우 ?
            //    // 다른 조건과 조합하여 표시해야하는 상태
            //    // ETowerStatus.Idle
            //}
            //else if (GConst.EqStatus == EQStatus.Manual_Status)
            //{
            //    m_TWState = ETowerStatus.Manual;
            //}
            //else if (GConst.EqStatus == EQStatus.All_Initial_Status)
            //{
            //    m_TWState = ETowerStatus.Init;
            //}
            //else if (GConst.EqStatus == EQStatus.Stop_Status)
            //{
            //    m_TWState = ETowerStatus.Stop;
            //}
            //else if (GConst.EqStatus == EQStatus.EMG_Status)
            //{
            //    m_TWState = ETowerStatus.Error;            // Error 상태
            //}
            //else
            //{
            //    // 그 외는 일단 Idle 상태라고 지정한다.
            //    m_TWState = ETowerStatus.Idle;
            //}

            ////// 우선적으로 처리할 상태
            ////ETowerStatus.LotEnd

            //// 지정 상태에 대해 정의된 Lamp 조작을 지시한다.
            //CSy21_Base.It.Tower_Lamp_RED((int)CData.m_TowerInfo[(int)m_TWState].Red);
            //CSy21_Base.It.Tower_Lamp_YEL((int)CData.m_TowerInfo[(int)m_TWState].Yel);
            //CSy21_Base.It.Tower_Lamp_GRN((int)CData.m_TowerInfo[(int)m_TWState].Grn);

            //// 상태에 따른 버저를 지정하여 On, off를 지정한다.
            //if (CData.m_TowerInfo[(int)m_TWState].Buzz == EBuzz.Buzz1)
            //{
            //    CSy21_Base.It.BZ00_OnOff(1);
            //    m_TWBuzzer = EBuzz.Buzz1;                       // 마지막으로 On 되었던 Buzzer 기억
            //}
            ////else
            ////    CSy21_Base.It.BZ00_OnOff(0);
            //else if (CData.m_TowerInfo[(int)m_TWState].Buzz == EBuzz.Buzz2)
            //{
            //    CSy21_Base.It.BZ01_OnOff(1);
            //    m_TWBuzzer = EBuzz.Buzz2;                       // 마지막으로 On 되었던 Buzzer 기억
            //}
            ////else
            ////    CSy21_Base.It.BZ01_OnOff(0);
            //else if (CData.m_TowerInfo[(int)m_TWState].Buzz == EBuzz.Buzz3)
            //{
            //    CSy21_Base.It.BZ02_OnOff(1);
            //    m_TWBuzzer = EBuzz.Buzz3;                       // 마지막으로 On 되었던 Buzzer 기억
            //}
            //else // 그 밖에는 off로 본다.
            //{
            //    if (m_TWBuzzer != EBuzz.Off)
            //    {
            //        if (m_TWBuzzer == EBuzz.Buzz1)
            //        {
            //            CSy21_Base.It.BZ00_OnOff(0);
            //        }
            //        else if (m_TWBuzzer == EBuzz.Buzz2)
            //        {
            //            CSy21_Base.It.BZ01_OnOff(0);
            //        }
            //        else if (m_TWBuzzer == EBuzz.Buzz3)
            //        {
            //            CSy21_Base.It.BZ02_OnOff(0);
            //        }

            //        m_TWBuzzer = EBuzz.Off;                     // 이제 Buzzer는 Off로 지정되었다.
            //    }
            //    else if (CData.BuzzOn)                          // 특정한 상황에 버저를 울리도록 요청하였다면
            //    {
            //        if (CData.BuzzOff)                          // Buzz를 끄도록 지정하면 
            //        {
            //            CData.BuzzOn = false;
            //            CSy21_Base.It.BZ00_OnOff(0);                // Buzzer를 꺼준다.
            //        }
            //        else
            //            CSy21_Base.It.BZ00_OnOff(1);                // Buzzer를 울려준다.
            //    }
            //}

            //NextFun = SwitchLamp_fun;
        }

        /// <summary>
        /// Buzzer function
        /// </summary>
        private void Buzzer_fun()
        {
            //Prg_cnt = 2;
            //if (delay[(int)nTm.bz2_time].End())
            //{
            //    if (CVar.m_BZ2_Flag == true)
            //    {// Buzzer 을 켜자
            //    }
            //    delay[(int)nTm.bz2_time].Start(5000);
            //}
            //if (delay[(int)nTm.bz5_time].End())
            //{
            //    if (CVar.m_BZ5_Flag == true)
            //    {// Buzzer 을 켜자
            //    }
            //    delay[(int)nTm.bz5_time].Start(5000);
            //}
            //NextFun = TowerLamp_fun;
        }

        private void _INITIAL_FUN()
        {
            //Prg_cnt = 1;

            //DTrace_Message();

            //CSy21_Base.It.EMG_Key_check();

            //// 2022-03-07, 
            //// 비상정지 버튼을 눌렀다고 Signal Tower 및 버저가 동작하지 않는다면 설비 상태를 알려줄 수 없다.

            //if (GConst.EqStatus == EQStatus.EMG_Status) NextFun = null;
            //else NextFun = Buzzer_fun;

            ////CSy21_Base.It.Error_Stop_Set
            //CSy21_Base.It.EqStatus_Gui_Display();
            //CSy21_Base.It.Machine_status_check();
            //// GUI 에서 Status 는 CVAR.m_EQSTATUS 변수 호출하여 사용

            ////public bool bEMG_stop_flag;
            ////public bool bError_flag;
            ////public bool bStop_flag;
            ////public bool bInit_flag;
            ////public bool bManual_flag;
            ////public bool bRun_flag;            
        }

        #region Switch 메인 함수
        public void Main_Process()
        {
            if (GVar.mKeyGui.bOutput_Halt == true)
            {
                NextFun = null;
                return;
            }
            else if (NextFun == null)
            {
                NextFun = _INITIAL_FUN;
                return;
            }
            NextFun();
            Display_mode();
        }
        #endregion
        private int old_key;
        string sData0;

        private void Display_mode()
        {
            nCnt++;
            if (nCnt > 999) nCnt = 0;
            if (NextFun == null)
            {
                sData0 = "null";
            }
            else sData0 = NextFun.Method.ToString();
            MethodBase ctxMethod = MethodBase.GetCurrentMethod();

            sData = DateTime.Now.ToString("[yyyyMMdd:HHmmss.fff] : ") + this.GetType().Name + "." + sData0 + ">> " + nCnt;
            // 210525 jym : 메모리 증가로 임시 삭제
            //setLog(sData);
            //Utils.TRACE(sData);
        }

        // generic 응용
        private T IntToEnum<T>(int e)
        {
            return (T)(object)e;
        }


        private void DTrace_Message()
        {
            //int nPage = 1;
            //int nX = 0;
            //int nY = 1;

            //for (int nMot = 0; nMot < (int)EAx.Endaxis; nMot++)
            //{
            //    dGetcp = ((nMot == (int)EAx.Table1_R) || (nMot == (int)EAx.Dress1_R)) ? HW.MT.GetRpm((EAx)nMot) : HW.MT.GetCP((EAx)nMot);
            //    dGetfp = ((nMot == (int)EAx.Table1_R) || (nMot == (int)EAx.Dress1_R)) ? HW.MT.GetRpm((EAx)nMot) : HW.MT.GetFP((EAx)nMot);

            //    CShared_mem.SetMsg(nPage, 1, nY, $"{IntToEnum<EAx>(nMot)} => " +
            //        $"CP = {dGetcp.ToString("F4")}, " +
            //        $"FP = {dGetfp.ToString("F4")}, " +
            //        $"Load = {HW.MT.GetLoad((EAx)nMot).ToString("F2")}, " +
            //        $"HD = {HW.MT.GetHome((EAx)nMot)}, " +
            //        $"Alm = {HW.MT.GetAlarm((EAx)nMot)}, " +
            //        $"Busy = {HW.MT.GetBusy((EAx)nMot)}, ");
            //    nY++;
            //}

        }

        #region Switch 해당 함수 
        //public ESWITCH STOP_Switch(ESWITCH nSet, ESWITCH bVal)
        //{
        //    ESWITCH bRet_val = bVal;
        //    if (nSet == ESWITCH.Set)// Set
        //    {
        //        HW.IO.Set(EIo.Y_SYS_LAMP_STOP, (bVal == ESWITCH.Lamp_Off) ? false : true);
        //        //CIO.It.Set_Y(eY.SYS_BtnStop, (bVal == mSWITCH.Lamp_Off) ? false : true);
        //    }
        //    else// Check
        //    {
        //        bRet_val = HW.IO.Get(EIo.X_SYS_BUTTON_STOP) ? ESWITCH.Push_On : ESWITCH.Push_Off;
        //        //(CIO.It.Get_X(eX.SYS_BtnStop) == false) ? mSWITCH.Push_Off : mSWITCH.Push_On;
        //    }
        //    return bRet_val;
        //}

        //private CTim m_mFlickSStop = new CTim();
        //static int nFlickerSStop = 0;
        //public void SwitchStop_Lamp(int nSel)
        //{
        //    if (nSel == 1)
        //    {
        //        STOP_Switch(ESWITCH.Set, ESWITCH.Push_On);
        //    }
        //    else if (nSel == 2)
        //    {// Flicker 는 어떻게 하지
        //        if (nFlickerSStop == 0)
        //        {
        //            nFlickerSStop = 1;
        //            m_mFlickSStop.Start(500);
        //        }
        //        else if (nFlickerSStop == 1)
        //        {
        //            if (m_mFlickSStop.End() == true)
        //            {
        //                if (HW.IO.Get(EIo.Y_SYS_LAMP_STOP) == true)
        //                {
        //                    HW.IO.Set(EIo.Y_SYS_LAMP_STOP, false);
        //                }
        //                else
        //                {
        //                    HW.IO.Set(EIo.Y_SYS_LAMP_STOP, true);
        //                }
        //                nFlickerSStop = 0;
        //            }
        //        }
        //        else
        //        {
        //            nFlickerSStop = 0;
        //        }
        //    }
        //    else
        //    {
        //        STOP_Switch(ESWITCH.Set, ESWITCH.Push_Off);
        //    }
        //}


        //public ESWITCH START_Switch(ESWITCH nSet, ESWITCH bVal)
        //{
        //    ESWITCH bRet_val = bVal;
        //    if (nSet == ESWITCH.Set)// Set
        //    {
        //        HW.IO.Set(EIo.Y_SYS_LAMP_START, (bVal == ESWITCH.Lamp_Off) ? false : true);
        //        //CIO.It.Set_Y(eY.SYS_BtnStart, (bVal == mSWITCH.Lamp_Off) ? false : true);
        //    }
        //    else// Check
        //    {
        //        bRet_val = HW.IO.Get(EIo.X_SYS_BUTTON_START) ? ESWITCH.Push_On : ESWITCH.Push_Off;
        //        //(CIO.It.Get_X(eX.SYS_BtnStart) == false) ? mSWITCH.Push_Off : mSWITCH.Push_On;
        //    }
        //    return bRet_val;
        //}

        //public ESWITCH RESET_Switch(ESWITCH nSet, ESWITCH bVal)
        //{
        //    ESWITCH bRet_val = bVal;
        //    if (nSet == ESWITCH.Set)// Set
        //    {
        //        HW.IO.Set(EIo.Y_SYS_LAMP_RESET, (bVal == ESWITCH.Lamp_Off) ? false : true);
        //        //CIO.It.Set_Y(eY.SYS_BtnReset, (bVal == mSWITCH.Lamp_Off) ? false : true);
        //    }
        //    else// Check
        //    {
        //        bRet_val = HW.IO.Get(EIo.X_SYS_BUTTON_RESET) ? ESWITCH.Push_On : ESWITCH.Push_Off;
        //        //bRet_val = (CIO.It.Get_X(eX.SYS_BtnReset) == false) ? mSWITCH.Push_Off : mSWITCH.Push_On;
        //    }
        //    return bRet_val;
        //}

        private CTim m_mFlickSReset = new CTim();
        static int nFlickerSReset = 0;
        //public void SwitchReset_Lamp(int nSel)
        //{
        //    if (nSel == 1)
        //    {
        //        RESET_Switch(ESWITCH.Set, ESWITCH.Push_On);
        //    }
        //    else if (nSel == 2)
        //    {// Flicker 는 어떻게 하지
        //        if (nFlickerSReset == 0)
        //        {
        //            nFlickerSReset = 1;
        //            m_mFlickSReset.Start(500);
        //        }
        //        else if (nFlickerSReset == 1)
        //        {
        //            if (m_mFlickSReset.End() == true)
        //            {
        //                if (HW.IO.Get(EIo.Y_SYS_LAMP_RESET) == true)
        //                {
        //                    HW.IO.Set(EIo.Y_SYS_LAMP_RESET, false);
        //                }
        //                else
        //                {
        //                    HW.IO.Set(EIo.Y_SYS_LAMP_RESET, true);
        //                }
        //                nFlickerSReset = 0;
        //            }
        //        }
        //        else
        //        {
        //            nFlickerSReset = 0;
        //        }
        //    }
        //    else
        //    {
        //        RESET_Switch(ESWITCH.Set, ESWITCH.Push_Off);
        //    }
        //}
        #endregion


        #region Log Function
        protected void _SetLog(string msg)
        {
            StackTrace sTrace = new StackTrace();
            StackFrame sFrame = sTrace.GetFrame(1);

            string method = sFrame.GetMethod().Name.PadRight(20);

            //CLog.Register(eLogType, _ParseLog(method, msg));
        }

        protected void _SetLog(string msg, double pos)
        {
            msg = string.Format("{0}  Pos : {1}mm", msg, pos);

            StackTrace sTrace = new StackTrace();
            StackFrame sFrame = sTrace.GetFrame(1);

            string method = sFrame.GetMethod().Name.PadRight(20);

           // CLog.Register(eLogType, _ParseLog(method, msg));
        }

        private string _ParseLog(string method, string msg)
        {
            string status = GConst.EqStatus.ToString();
            if (GConst.EqStatus == EQStatus.Err_Status)
            {
                //int err = (int)ErrManager.It.Current + 1;
                //status = string.Format("{0}[{1}]", status, err.ToString("000000"));
            }
            status.PadRight(20);

            StringBuilder builder = new StringBuilder();
            builder.Append(status + "\t");
            builder.Append(method + "()\tPrg_cnt : ");
            builder.Append(Prg_cnt);
            /*
            int cnt = (int)EProc_Define.STEP_ARRAY_COUNT;
            for (int i = 0; i < cnt; i++)
            {
                builder.Append(_steps[i]);
                if (i != cnt - 1)
                {
                    builder.Append(", ");
                }
            }
            */
            builder.Append("\t");
            builder.Append(msg);

            return builder.ToString();
        }
        #endregion

    }
}
