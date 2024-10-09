using System;
using System.Collections;
using System.Drawing;


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
