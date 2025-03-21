﻿
public enum ELang
{
    English = 0,
    Chinese = 1,
    Korean = 2,
}
public enum EUser
{
    Operator  ,
    Technician,
    Engineer  ,
    Master
}

public enum eMsg
{
    Notice,
    Warning,
    Error
}
public enum eRecipGroup
{
    Common,
    Loader,
    Bank,
    Unloader,
    End
}
public enum eEthernet
{
    No = 0,
    Port_Name = 1,
    IPaddress = 2,
    Port_no = 3,
    Host = 4,
    Protocol = 5,
    End
}
public enum eSerial
{
    No = 0,
    Port_Name = 1,
    Baud_Rate = 2,
    Data_bit = 3,
    Stop_bit = 4,
    Parity_bit = 5,
    Flow_Control = 6,
    End
}
public enum eErrorListGrid
{
    ErrCode = 0,
    Name = 1,
    End
}
public enum eErrorListArray
{
    Code = 0,
    Name = 1,
    Action = 2,
    Image = 3,

    Name_En = 4,
    Action_En = 5,
    Name_Ch = 6,
    Action_Ch = 7,
    Name_Kr = 8,
    Action_Kr = 9,
    End
}
public enum eIOListGrid
{
    Label = 0,
    Name = 1,
    Coil = 2,
    Part = 3,
    End
}
public enum eIOArray
{
    Label = 0,
    InOut = 1,
    Name = 2,
    Coil = 3,
    Part = 4,
    Desc = 5,
    End
}
public enum eIO_Kind
{
    In = 0, 
    Out = 1,
    end
}

public enum eMotorConfig
{
    swAxis = 0,
    hwAxis = 1,
    Name,
    Use,
    Servo,
    Lead_Pitch,
    Mv_Dir,
    InPosWidth,
    PP1,
    HomeLogic,
    Home_Coil,
    Limit_Coil,
    Alarm_Coil,
    Z_Phase,
    end
}
public enum eMotorListGrid
{
    swAxis = 0,
    Name,
    Servo,
    Cmd_mm,
    Enc_mm,
    Home_End,
    Sen_Home,
    Sen_NLimit,
    Sen_PLimit,    
    Alarm_In,
    ZPhase_In,
    Inpos_In,
    end
}

public enum eSpcGrid
{
    DataNo = 0,
    Name = 1,
    Description = 2,
    X_Data = 3,
    Y_Data = 4,
    Z_Data = 5,
    End
}
public enum eSpcArray
{
    No = 0,
    Name = 1,
    Description = 2,
    xData = 3,
    yData = 4,
    zData = 5,
    End
}

/// <summary>
/// Machine 상태
/// 1.	설비의 상태 우선 순위 : 1)EMG > 2)Auto > 3)Manual > 4)Initial > 5)Error > 6)Alarm >7)Stop,
///    ㄴ Error/Alarm : 설비 정지 중일 때 Display 됨
///     : Initial 보다 위의 상태일때는 Error/Alarm 발생시 설비 가동상황 우선 display
/// </summary>
public enum EQStatus
{
    EMG_Status,     // 설비의 비상 정지 상태 -비상정지 시 설정
    Run_Status,      // 설비의 Auto run 진행 상태 - 설비의 Auto 진행 시 설정
    Manual_Status,  // 설비의 Manual 진행 상태 - 설비의 Manual 진행 시 설정
    All_Initial_Status, // 설비의 All Home 진행 상태 - 설비의 All Home 진행 시 설정
    Semi_Auto_Status, // Stage 부분 Dual 로 이동시 사용

    Err_Status,     // 설비의 Error 발생 상태 - 설비의 Error 시 설정
    Alarm_Status,   // 설비의 Warning 발생 상태 - 설비의 Warning 시 설정
    Stop_Status,    // 설비의 정상 Stop 발생 상태 - 설비의 정상 Stop 시 설정

    //public bool[] bRun_Module_Status = new bool[50];
}


public enum DbTableName
{
    AUXUNIT,
    AXIS_CMD,
    AXIS_HOME,
    AXIS_POS,
    ERROR,
    INOUTSIGNAL,
    MEASURE_RAWDATA,
    MEASURE_VALUE,
    PRODUCT,
    RUN,
    SPINDLE,
    WHEEL,
    WORKPATH

};

public enum eError
{
    number,
    name,             // Alarm 
    action,
    image,    
    
    Name_En,          // 영문 알람명
    Action_En,          // 영문 알람명
    Name_Ch,          // 중국어 알라몀
    Action_Ch,        // 원인 및 조치내용
    Name_Kr,
    Action_Kr

}
public struct TErr
{
    public int number;
    public string name;             // Alarm 
    public string action;
    public string image;

    // 다국어 지원
    public string Name_En;          // 영문 알람명
    public string Action_En;          // 영문 알람명
    public string Name_Ch;          // 중국어 알라몀
    public string Action_Ch;        // 원인 및 조치내용
    public string Name_Kr;
    public string Action_Kr;
}

/// <summary>
/// Error list
/// </summary>
/// 

public enum EErr
{
    NONE = 000000,

    // System Error 010000 ~ 019999
    SYS_ERROR = 010000,
    SYS_EMG_FRONT_LEFT,
    SYS_EMG_FRONT_RIGHT,
    SYS_EMG_REAR_LEFT,
    SYS_EMG_REAR_RIGHT,
    SYS_MAIN_VACUUM_OFF_CHECK,
    SYS_WHEEL_FILE_NOT_SELECT,
    SYS_WHEEL_FILE_SAVE_ERROR,
    SYS_EMG_BUTTON_PRESS,                          // 비상 정지 버튼이 눌렸다.
    Err010009 = 010009,
    Err010010 = 010010,
    Err010011 = 010011,
    Err010012 = 010012,
    Err010013 = 010013,
    Err010014 = 010014,
    Err010015 = 010015,
    Err010016 = 010016,
    Err010017 = 010017,
    Err010018 = 010018,
    Err010019 = 010019,
    Err010020 = 010020,
    Err010021 = 010021,
    Err010022 = 010022,
    Err010023 = 010023,
    Err010024 = 010024,
    Err010025 = 010025,
    Err010026 = 010026,
    Err010027 = 010027,
    Err010028 = 010028
};


/// <summary>
/// Switch 및 lamp On/Off 주기
/// </summary>
public class Lamp_flag
{
    public bool bFliker_2;// 0.2초 주기 사용
    public bool bFliker_5;// 0.5초 주기 사용
}

/// <summary>
/// Tower lamp On/Off 주기
/// </summary>
public class TwrLamp_flag
{
    public bool RED_Lamp;   // RED lamp
    public bool YELL_Lamp;  // YELLOW lamp
    public bool GREEN_Lamp; // GREEN lamp
    public bool BLUE_Lamp;  // BLUE lamp
}

