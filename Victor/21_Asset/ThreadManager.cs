using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Victor
{
    public enum EThread
    {
        Seq = 0,
        Log = 1,
        End
    }

    public static class ThreadManager
    {
        private static Thread[] _thread = new Thread[Enum.GetValues(typeof(EThread)).Length];
        public static void Start()
        {
            CData.SPara.iDelPeriod = 10;
            // Log 쓰레드 시작
            _thread[(int)EThread.Log] = new Thread(new ThreadStart(_Log));
            _thread[(int)EThread.Log].Priority = ThreadPriority.Lowest;
            _thread[(int)EThread.Log].Start();
        }

        public static void Release()
        {
            int cnt = Enum.GetValues(typeof(EThread)).Length;
            for (int i = 0; i < cnt; i++)
            {
                if (_thread[i] != null)
                {
                    _thread[i].Abort();
                    _thread[i] = null;
                }
            }
        }

        /// <summary>
        /// Log Save 를 위해 쓰레드 가동
        /// </summary>
        private static void _Log()
        {
            CLog.Write(ELog.MAIN, "Start log method.");

            string sPath_Log = GVar.PATH_LOG;
            //string sPath_Spc = GVar.PATH_SPC;
            string sPath_Del = string.Empty;
            DateTime dtBootDate = DateTime.Now;
            int iYear = 0;
            int iMonth = 0;
            int iDay = 0;

            while (true)
            {
                tMainLog tVal;
                int iCnt = CLog.QueLog.Count;
                if (iCnt > 0)
                {
                    for (int i = 0; i < iCnt; i++)
                    {
                        CLog.QueLog.TryDequeue(out tVal);
                        CLog.Save(tVal);
                    }
                }

                DateTime dtDelDate = DateTime.Today.AddDays(-CData.SPara.iDelPeriod);

                // Log Delete Period
                if (CData.SPara.iDelPeriod != 0 && dtBootDate.Day != DateTime.Now.Day)
                //if (CData.SPara.iDelPeriod != 0 )
                {
                    // 연이 바뀌었을때
                    for (iYear = dtDelDate.Year; iYear > dtDelDate.Year - 3; iYear--)
                    {
                        if (iYear != dtDelDate.Year)
                        {
                            // Log Folder
                            sPath_Del = sPath_Log + iYear.ToString();
                            DirectoryInfo diY = new DirectoryInfo(sPath_Del);
                            if (diY.Exists)
                            {
                                diY.Delete(true);
                            }
                            // SPC Folder
                            //sPath_Del = sPath_Spc + iYear.ToString();
                            //diY = new DirectoryInfo(sPath_Del);
                            //if (diY.Exists)
                            //{
                            //    diY.Delete(true);
                            //}
                        }
                    }

                    // 월이 바뀌었을때
                    for (iMonth = dtDelDate.Month; iMonth > 0; iMonth--)
                    {
                        if (iMonth != dtDelDate.Month)
                        {
                            // Log Folder
                            sPath_Del = sPath_Log + dtDelDate.Year.ToString("0000") + "\\" + iMonth.ToString("00");
                            DirectoryInfo diM = new DirectoryInfo(sPath_Del);
                            if (diM.Exists)
                            {
                                diM.Delete(true);
                            }
                            // SPC Folder
                            //sPath_Del = sPath_Spc + dtDelDate.Year.ToString("0000") + "\\" + iMonth.ToString("00");
                            //diM = new DirectoryInfo(sPath_Del);
                            //if (diM.Exists)
                            //{
                            //    diM.Delete(true);
                            //}
                        }
                    }

                    // 일이 바뀌었을때
                    for (iDay = dtDelDate.Day; iDay > 0; iDay--)
                    {
                        // Log Folder
                        sPath_Del = sPath_Log + dtDelDate.Year.ToString("0000") + "\\" + dtDelDate.Month.ToString("00") + "\\" + iDay.ToString("00");
                        DirectoryInfo di = new DirectoryInfo(sPath_Del);
                        if (di.Exists)
                        {
                            di.Delete(true);
                        }
                        // SPC Folder
                        //sPath_Del = sPath_Spc + dtDelDate.Year.ToString("0000") + "\\" + dtDelDate.Month.ToString("00") + "\\" + iDay.ToString("00");
                        //di = new DirectoryInfo(sPath_Del);
                        //if (di.Exists)
                        //{
                        //    di.Delete(true);
                        //}
                    }
                    dtBootDate = DateTime.Now;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
