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
public class CGvar
{
    #region Path
    public static readonly string PATH_START = Application.StartupPath + "\\";
    /// <summary>
    /// settingConfigs Folder Path  StartUp\\settingConfigs\\
    /// </summary>
    public static readonly string PATH_CONFIG = Application.StartupPath + "\\04_Config\\";
    /// <summary>
    /// Wheel Folder Path  StartUp\\Wheel\\
    /// </summary>
    public static readonly string PATH_WHEEL = Application.StartupPath + "\\Wheel\\";
    /// <summary>
    /// Device Folder Path  StartUp\\Device\\
    /// </summary>
    public static readonly string PATH_DEVICE = Application.StartupPath + "\\Device\\";
    
    #endregion
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
