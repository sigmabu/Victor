﻿using System;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Policy;


public struct TCommon
{
    public bool bCValue;
    public int  nCValue;
    public double dCValue;
    public string sCValue;
}
public struct TLoader
{
    public bool bLValue;
    public int nLValue;
    public double dLValue;
    public string sLValue;
}

public struct TUnloader
{
    public bool bULValue;
    public int nULValue;
    public double dULValue;
    public string sULValue;
}
/// <summary>
/// 디바이스 전체적인 구조체
/// </summary>
public struct mRecipe
{
    /// <summary>
    /// 디바이스 이름
    /// </summary>
    public string sDeviceName;

    /// <summary>
    /// 부울값 저장
    /// </summary>
    public bool bSaveValue;

    /// <summary>
    /// 정수값 저장
    /// </summary>
    public int nSaveValue;
    
    /// <summary>
    /// 실수값 저장
    /// </summary>
    public double dSaveValue;

    /// <summary>
    /// 마지막 수정 날짜
    /// </summary>
    public string dtEditLast;

    public TCommon C_Data;
    public TLoader L_Data;
    public TUnloader Ul_Data;

    public object GetVal(string name)
    {
        return GetType().GetField(name).GetValue(this);
    }

    public object GetVal(string name, int index)
    {
        IList arr = (IList)GetType().GetField(name).GetValue(this);
        return arr[index];
    }

    public void SetVal(string name, object val)
    {
        object obj = this;
        GetType().GetField(name).SetValue(obj, val);
        this = (mRecipe)obj;
    }

    public void SetVal(string name, object val, int index)
    {
        object obj = this;
        IList arr = (IList)GetType().GetField(name).GetValue(obj);
        arr[index] = val;
        GetType().GetField(name).SetValue(obj, arr);
        this = (mRecipe)obj;
    }

}

public struct mEthernet
{
    public string sNo;
    public string sName;
    public string sIPaddress;
    public string sPort;
    public string sHost; //Server/Client
    public string sProtocol;// TCP/UDP
}
public static class mEthernet_Env
{
    public static String[] sName = new String[4] { "NET00", "NET01", "NET03", "NET04" };
    public static string[] sAddress = new String[1] { "192,168.0.1" };
    public static int[] nPort = new int[2] { 1000,2000 };
    public static String[] sHost = new String[2] { "Server", "Client"};
    public static String[] sProtocol = new String[2] { "TCP", "UDP"};
}
public struct mSerial
{
    public int nNo;
    public string sPort_Name;
    public string sBaud_Rate;
    public string sData_bit;
    public string sParity_bit;
    public string sStop_bit;
}
public static class mSerial_Env
{
    public static String[] sName = new String[4] { "COM10", "COM11", "COM12", "COM13" };
    public static int[] nBaud = new int[10] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200 };
    public static int[] nData = new int[2] { 8, 7 };
    public static String[] nStop = new String[4] { "None", "One", "Two", "OnePointFive" };
    public static String[] nParity = new String[5] { "None", "Odd", "Even", "Mark", "Space" };
}
public struct mIOList
{
    public string sLabel;
    public string sInOut;
    public string sName;
    public string sCoil;
    public string sPart;
    public string sDesc; 
}

public struct mErrorList
{
    public string sCode;
    public string sName;
    public string sAction;
    public string sImage;

    public string sName_En;
    public string sAction_En;
    public string sName_Ch;
    public string sAction_Ch;
    public string sName_Kr;
    public string sAction_Kr;
}
/// <summary>
/// #swAxis : 프로그램 Axis
/// #hwAxis : 모션 제어기 Axis
/// #name : 사용자 Axis 이름
/// #use: 미사용(0)/ 사용 (1)
/// #mode: Servor(0)/Step(1)
/// #Lead_Pitch : Ball Screw Pitch 단위 um
/// #Mv_Dir : CW(0)/ CCW(1)
/// #InPosWidth : um 단위
/// #nPP1 : 1puls 당 이동 거리 단위 um
/// #HomeLogic : Home Search methode Only 센서(0)/ 센서and Z_Phase(1)
/// #Home_Coil : A(0)/B(1)
/// #Limit_Coil: A(0)/B(1)
/// #Alarm_Coil A(0)/B(1)
/// #Z_Phase : NotUse(0)/1(Use)
/// </summary>
public struct mMotor
{
    public int swAxis;
    public int hwAxis;
    public string sName;
    public string sUse;
    public string sMode;
    public int nLead_Pitch;
    public string sMv_Dir;
    public int nInPosWidth;
    public int nPP1;
    public string sHomeLogic;
    public string sHome_Coil;
    public string sLimit_Coil;
    public string sAlarm_Coil;
    public string sZ_Phase;
}

public static class mMotor_Env
{
    public static string[] sName = new string[2] { "Motor_0", "Motor_1" };
    public static string[] sUse = new string[2] { "use", "None"};
    public static string[] sMode = new string[4] { "Servo", "Step", "Torque", "Velocity" };
    public static string[] sDir = new string[2] { "CW", "CCW" };
    public static string[] sHome_Logic = new string[2] { "SenSor", "Sen after Z" };
    public static string[] sSen_Coil = new string[2] { "NO", "NC" };
}

public struct mSpcList
{
    public string sNo;
    public string sName;
    public string sDescrip;
    public string sXdata;
    public string sYdata;
    public string sZdata;
}

class mViewPage
{
    public static int nViewMain_111 { get { return 111; } set { } }
    public static int nViewRecipeList_211 { get { return 211; } set { } }
    public static int nViewRecipeItem_212 { get { return 212; } set { } }
    public static int nViewMaint_311 { get { return 311; } set { } }
    public static int nViewMaintSerial_312 { get { return 312; } set { } }
    public static int nViewMaintEthernet_313 { get { return 313; } set { } }
    public static int nViewMaintIOList_314 { get { return 314; } set { } }
    public static int nViewMaintErrorList_315 { get { return 315; } set { } }
    public static int nViewMaintMotorList_316 { get { return 316; } set { } }
    public static int nViewSPC_317 { get { return 317; } set { } }


    public static int nRcpPage { get; set; }

    public static int nMaintPage { get; set; }
    public static int mCurrViewPage { get; set; }
}

/// <summary>
/// 시퀀스 운용 플레그
/// </summary>
/// 
public struct TFlag
{
    /// <summary>
    /// 각 Process 의 Initial 진행 시 설정 (종료시 0)
    /// </summary>
    public bool init;
    /// <summary>
    /// 각 Process 의 Manual 진행 시 설정 (종료시 0)
    /// </summary>
    public bool manual;
    /// <summary>
    /// 각 Process 의 Run 진행 시 설정 (종료시 0)
    /// </summary>
    public bool run;
    /// <summary>
    /// 각 Process 의 정지를 하고자 할때 (cycle_depth 종료를 하고자 할때 )  false 설정
    /// </summary>
    public bool step;
    /// <summary>
    /// 각 Process 의 Stop 진행 시 설정 (종료시 0) false 설정
    /// </summary>
    public bool stop;
}

/// <summary>
/// Switch Push 상태
/// </summary>
public class SWITCH_STATUS
{
    // Key 및 센서 동작 상태 변수
    public bool bEMG_key;
    public bool bStop_key;
    public bool bManual_stop_Key;
    public bool bAuto_key;
    public bool bReset_key;
    public bool bDoor_lock;

    public bool bOutput_Halt;

    // 센서 동작에 따른 내부 사용하기 위한 변수
    public bool bEMG_stop_flag;
    public bool bError_flag;
    public bool bStop_flag;
    public bool bInit_flag;
    public bool bManual_stop_flag;
    public bool bRun_flag;
}


public struct CmdKey
{
    /// <summary>
    /// Running Command
    /// </summary>
    public bool bRun_flag;
    public bool bError_flag;
}


