using System;
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
        //public string sFlow_Control;
    }
    public static class mSerial_Env
    { 
        public static String[] sName = new String[4] { "COM10", "COM11", "COM12", "COM13" };
        public static int[]    nBaud = new int[10] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200 };
        public static int[]    nData = new int[2] { 8, 7 };
        public static String[] nStop = new String[4] { "None", "One", "Two", "OnePointFive" };
        public static String[]    nParity = new String[5] { "None", "Odd", "Even", "Mark", "Space" };
    }


    public static class mViewPage
    {
    public static int nViewMain = 111;
    public static int nViewRecipeList = 211;
    public static int nViewRecipeItem = 212;
    public static int nViewMaint = 311;
    public static int nViewMaintSerial = 312;
    public static int nViewMaintEthernet = 313;

    public static int nRcpPage { get; set; }

    public static int nMaintPage { get; set; }
    public static int mCurrViewPage  {get;set;  }
}

