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
public enum eErrorArray
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

