using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using Util;
using Victor;

/// <summary>
/// Global Const
/// </summary>
namespace Victor
{
    public class GConst
    {

        public static void Init()
        {
        }

        public static void Release()
        {
        }
        public static EQStatus EqStatus = EQStatus.Stop_Status;

        public static CMariadb Cmariadb { get; set; }

        public static bool IsConn {  get; set; }

    }
}
