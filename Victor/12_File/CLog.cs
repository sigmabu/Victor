//using SuhwooUtil;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Victor
{
    public static class CLog
    {
        public static object lockObject = new object(); 
        private static CTim m_Kill = new CTim();

        #region Log "deleteDate " 이전 폴더는 삭제
        private static void mLog_Delete(string sPath)
        {
            try
            {
                int deleteDate = 1;
                DirectoryInfo di = new DirectoryInfo(sPath);
                if (di.Exists)
                {
                    DirectoryInfo[] dirinfo = di.GetDirectories();
                    string iDate = DateTime.Today.AddDays(-deleteDate).ToString("yyyyMMdd");
                    foreach (DirectoryInfo dir in dirinfo)
                    {
                        if (iDate.CompareTo(dir.LastWriteTime.ToString("yyyyMMdd")) > 0)
                        {
                            dir.Attributes = FileAttributes.Normal;
                            dir.Delete(true);
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        #endregion

        /// <summary>
        /// 로그 큐에 로그 데이터 등록
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public static void Register(eLog type, string msg)
        {
            if (CData.QueLog != null)
            {
                tMainLog log = new tMainLog();
                log.eType = type;
                log.dtTime = DateTime.Now;
                log.sMsg = msg;
#if !DEBUG
                Console.WriteLine(log);
#endif
                CData.QueLog.Enqueue(log);
            }
        }

        public static void Save(tMainLog log)
        {
            eLog type = log.eType;
            DateTime time = log.dtTime;
            string dir = "";

            string now = time.ToString("[yyyyMMdd-HHmmss fff]");
            string name = time.ToString("yyyyMMddHH");

            StringBuilder sSB = new StringBuilder();
            sSB.Append(GV.PATH_LOG);
            sSB.Append("\\");
            sSB.Append(time.Year.ToString("0000"));
            sSB.Append("\\");
            sSB.Append(time.Month.ToString("00"));
            sSB.Append("\\");
            sSB.Append(time.Day.ToString("00"));
            sSB.Append("\\");

            dir = sSB.ToString();

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            switch (type)
            {
                case eLog.OPL:
                case eLog.SWITCH:
                case eLog.LELV:
                case eLog.LRAIL:
                case eLog.LPNP:
                case eLog.STAGE1:
                case eLog.STAGE2:
                case eLog.UPNP:
                case eLog.DRY:
                case eLog.UELV:
                case eLog.MR:
                case eLog.LDTR:
                case eLog.UDTR:
                case eLog.PROCESS:
                    {
                        // 프로세스 (시퀀스)
                        sSB = new StringBuilder(dir);
                        sSB.Append("Sequence\\");
                        sSB.Append(type.ToString());
                        sSB.Append("\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }

                case eLog.MAIN:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append(type.ToString());
                        sSB.Append("\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
                case eLog.MARIADB:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append("MariaDB\\");
                       // sSB.Append(type.ToString());
                        sSB.Append("\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
                case eLog.SECSGEM:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append("SecsGem\\");
                        sSB.Append(type.ToString());
                        sSB.Append("\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
                case eLog.FTP:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append("SecsGem\\");
                        sSB.Append(type.ToString());
                        sSB.Append("\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
                case eLog.AGV:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append("AGV\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
                case eLog.LASER:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append("LASER\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
                case eLog.ERR:
                    {
                        sSB = new StringBuilder(dir);
                        sSB.Append("ERR\\");
                        if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                        sSB.Append(name);
                        sSB.Append(".log");
                        Check_File_Access(sSB.ToString(), now + "\t" + log.sMsg, true);

                        break;
                    }
            }
        }

        public static void Check_File_Access(string _path,string log,bool append)
        {
            //CSV 파일이 Open되어 있으면 강제적으로 Kill후 write한다.
            string filename = Path.GetFileName(_path);
            if (killps(filename)== true) m_Kill.Wait(2000);
            FileInfo fi = new FileInfo(_path);
            lock (lockObject)
            {
                if(append)
                {
                    try
                    {
                        using (FileStream file = new FileStream(fi.FullName, FileMode.Append, FileAccess.Write, FileShare.Read))
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            // You can add code here if file is accessible
                            writer.WriteLine(log);
                            writer.Close();
                            writer.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        CMsg.Show(eMsg.Error, "Error", ex.Message);
                        return ;
                    }
                }
                else
                {
                    try
                    {
                        using (FileStream file = new FileStream(fi.FullName, FileMode.Create, FileAccess.Write, FileShare.Read))
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            // You can add code here if file is accessible
                            writer.WriteLine(log);
                            writer.Close();
                            writer.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        CMsg.Show(eMsg.Error, "Error", ex.Message);
                        return ;
                    }
                }
            }
        }

        //koo 191101 : error window 
        public static bool killps(string filename)
        {
            bool kill = false;

            //200324 ksg :
            string[] sp = filename.Split('.');
            if(sp[1] != "csv" && sp[1] != "Csv" && sp[1] != "CSV") return kill;

            string sFullFileName = filename + " - Excel";
            var excelProcesses = Process.GetProcessesByName("excel");

            foreach (var process in excelProcesses)
            {
                if (process.MainWindowTitle == $"Microsoft Excel - {filename}") // String.Format for pre-C# 6.0 
                {
                    process.Kill();
                    kill = true;
                }
                else if (process.MainWindowTitle == sFullFileName) //190501 ksg : Excel 파일 Close 조건 추가
                {
                    process.Kill();
                    kill = true;
                    
                }
                else if (process.MainWindowTitle == filename) //190501 ksg : Excel 파일 Close 조건 추가
                {
                    process.Kill();
                    kill = true;                    
                }
                else 
                {
                }
            }
            return kill;
        }
    }
}
