using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Victor
{
    internal class FileMapping
    {
        public static class CDef
        {
            // Debug 화면 라인당  Char 글자 수
            public const int PACKET_ROW = 500;
            /// <summary>
            /// Debug 화면 Display 라인 개수
            /// </summary>
            public const int PACKET_STR = 38;
            /// <summary>
            /// Debug Page 수
            /// </summary>
            public const int PAGE_MAX = 11;
        }

        public struct _Packet
        {
            public UInt32 nPage; // Page 번호

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CDef.PACKET_STR)]
            public _MSGData[] MsgData;

        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class CMSGMem
        {
            public Int16 nstatus;
            public Int16 nShow_Win;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)CDef.PAGE_MAX)]
            public _Packet[] packet;

        }

        public struct _MSGData
        {
            public Color col;
            public UInt32 nX;
            public UInt32 nY;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)CDef.PACKET_ROW)]
            public String str;

        };

    }
}
