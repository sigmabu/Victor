using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

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
    }
}
