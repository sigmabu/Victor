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

    /// <summary>
    /// Device Folder Path  StartUp\\Device\\
    /// </summary>
    public static readonly string PATH_DEVICE = Application.StartupPath + "\\Device\\";

    #endregion

    /// <summary>
    /// UI 화면 Page
    /// </summary>
    public static int m_iPage { get; set; }

    /// <summary>
    /// ini 화일 Section 과 Key 설정
    /// </summary>
    public static string[] ini_RecipeSection { get; set; }
    public static string[] ini_RecipeKey { get; set; }
    public static string[][] RecipeKeyName = new string[100][];
        
}

public class CGcolor
{

    #region Color
    public Color ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
    public Color ColorNotic = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
    public Color ColorWarning = Color.Yellow;
    public Color ColorError = Color.Red;
    #endregion
}
