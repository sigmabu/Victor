using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using Util;
using Victor;

/// <summary>
/// Global Variable
/// </summary>
public class GVar
{
    #region Path


    public static readonly string PATH_START = Application.StartupPath + "\\";
    /// <summary>
    /// settingConfigs Folder Path  StartUp\\settingConfigs\\
    /// </summary>
    public static readonly string PATH_CONFIG = Application.StartupPath + "\\04_Config\\";
    public static readonly string PATH_CONFIG_Serial = Application.StartupPath + "\\04_Config\\Serial.csv";
    public static readonly string PATH_CONFIG_Ethernet = Application.StartupPath + "\\04_Config\\Ethernet.csv";

    public static readonly string PATH_EQUIP_IOList = Application.StartupPath + "\\05_Equip\\IO\\IOList.csv";
    public static readonly string PATH_EQUIP_MotorList = Application.StartupPath + "\\05_Equip\\Motion\\motor.json";

    public static readonly string PATH_EQUIP_ErrorList = Application.StartupPath + "\\03_Error\\ErrorList.xls";
    public static readonly string PATH_EQUIP_ErrorImageFolder = Application.StartupPath + "\\03_Error\\Image\\";
    /// <summary>
    /// Device Folder Path  StartUp\\Device\\
    /// </summary>
    public static readonly string PATH_DEVICE = Application.StartupPath + "\\Device\\";

    #endregion

    /// <summary>
    /// UI 화면 Page
    /// </summary>
    public static int m_iPage { get; set; }

    public static string EOF = "EOF";

    /// <summary>
    /// ini 화일 Section 과 Key 설정
    /// </summary>
    public static string[] ini_RecipeSection { get; set; }
    public static string[] ini_RecipeKey { get; set; }
    public static string[][] RecipeKeyName = new string[100][];
        
}

public class Gcolor
{

    #region Color
    public static Color ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
    public static Color ColorNotic = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
    public static Color ColorWarning = Color.Yellow;
    public static Color ColorError = Color.Red;

    public static Color Color_OnGreen = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30)))));
    #endregion
}
