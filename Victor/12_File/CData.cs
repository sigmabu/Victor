using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Victor.HardWare;

namespace Victor
{
    public static class CData
    {
        public static bool IsVR = false;

        public static void Init()
        {
        }

        public static void Release()
        {
        }

        /// <summary>
        /// 디바이스 구조체
        /// </summary>
        public static mRecipe tRecipe = new mRecipe();
        /// <summary>
        /// 현재 사용중인 디바이스 파일의 경로
        /// </summary>
        public static string RecipeCur = "";

        public static string RecipeGr = "";

        /// <summary>
        /// Serial Port 설정
        /// </summary>
        public static mSerial[] tSerial = new mSerial[20];
        /// <summary>
        /// Ethernet 설정
        /// </summary>
        public static mEthernet[] tEthernet = new mEthernet[20];

        public static mIOList[] tInList = new mIOList[1024];
        public static mIOList[] tOutList = new mIOList[1024];

        public static mErrorList[] tErrorList = new mErrorList[1024];

        public static mSpcList[] tSpcList = new mSpcList[1024];

        /// <summary>
        /// Motor List
        /// </summary>
        public static mMotor[] tMotor = new mMotor[32];

        /// <summary>
        /// 옵션 구조체
        /// </summary>
        public static tServiceOption SPara = new tServiceOption();

        /// <summary>
        /// Service Option Struct
        /// </summary>
        public struct tServiceOption
        {
            /// <summary>
            /// Log 자동 삭제 주기
            /// </summary>
            public int iDelPeriod;
        }
    }
}
