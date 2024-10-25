using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Concurrent;


    public enum ELog
    {
        None,
        //    로그 분류
        //    대분류 -> 모든 로그는 전체 로그에 기록, 에러 발생 시에는 에러 로그 기록
        MAIN,
        /// <summary>
        /// DEB.log    전체 로그 : Debug Log
        /// </summary>
        DBE,
        /// <summary>
        /// ERR.log    에러 발생 로그 : Error Log -> 에러발생값 같이 기록
        /// </summary>
        ERR,
        
        //상태별 - 이벤트성
        /// <summary>
        /// OPL.log    조작로그 : Operate Log -> 조작된 버튼
        /// </summary>
        OPL,
        /// <summary>
        /// DSL.log    데이터저장로그 : Data Save Log -> 2개의 파일로 기록, 통채로/변경된부분만
        /// </summary>
    }

    public struct tMainLog
    {
        /// <summary>
        /// 로그의 시퀀스
        /// </summary>
        public ELog ESeq;
        /// <summary>
        /// 로그 종류
        /// </summary>
        public ELog eType;
        /// <summary>
        /// 로그 발생 시간
        /// </summary>
        public DateTime dtTime;
        /// <summary>
        /// 로그 메세지
        /// </summary>
        public string sMsg;
    }


public class CLogManager
{

    /// <summary>
    /// Log를 저장하기 위한 큐
    /// </summary>        
    public static ConcurrentQueue<tMainLog> QueLog = new ConcurrentQueue<tMainLog>();

    /// <summary>
    /// Log를 Trace 위한 큐
    /// </summary>        
    public static ConcurrentQueue<tMainLog> QueLog_Trace = new ConcurrentQueue<tMainLog>();

    public static object lockObject = new object();
    private static CTime m_Kill = new CTime();

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
    /// <param name="_eLog"></param>
    /// <param name="msg"></param>
    public static void Register(ELog _eLog, string msg)
    {
        if (QueLog != null)
        {
            tMainLog pLog = new tMainLog();
            pLog.eType = _eLog;
            pLog.dtTime = DateTime.Now;
            pLog.sMsg = msg;
#if !DEBUG
                Trace(log);
#endif
            QueLog.Enqueue(pLog);
            QueLog_Trace.Enqueue(pLog);
        }
    }

    public static void Save(tMainLog pLog)
    {
        ELog eLog = pLog.eType;
        DateTime time = pLog.dtTime;
        string dir = "";

        string now = time.ToString("[yyyyMMdd-HHmmss fff]");
        string name = time.ToString("yyyyMMddHH");

        StringBuilder sSB = new StringBuilder();
        sSB.Append(GVar.PATH_LOG);
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

        switch (eLog)
        {
            case ELog.OPL:
                {
                    // 프로세스 (시퀀스)
                    sSB = new StringBuilder(dir);
                    sSB.Append("GUI\\");
                    sSB.Append(eLog.ToString());
                    sSB.Append("\\");
                    if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                    sSB.Append(name);
                    sSB.Append(".Log");
                    Check_File_Access(sSB.ToString(), now + "\t" + pLog.sMsg, true);

                    break;
                }
            case ELog.MAIN:
                {
                    sSB = new StringBuilder(dir);
                    sSB.Append(eLog.ToString());
                    sSB.Append("\\");
                    if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                    sSB.Append(name);
                    sSB.Append(".Log");
                    Check_File_Access(sSB.ToString(), now + "\t" + pLog.sMsg, true);

                    break;
                }
            case ELog.DBE:
                {
                    sSB = new StringBuilder(dir);
                    sSB.Append(eLog.ToString());
                    sSB.Append(@"Debug\");
                    if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                    sSB.Append(name);
                    sSB.Append(".Log");
                    Check_File_Access(sSB.ToString(), now + "\t" + pLog.sMsg, true);

                    break;
                }
            case ELog.ERR:
                {
                    sSB = new StringBuilder(dir);
                    sSB.Append("ERR\\");
                    if (!Directory.Exists(sSB.ToString())) { Directory.CreateDirectory(sSB.ToString()); }
                    sSB.Append(name);
                    sSB.Append(".Log");
                    Check_File_Access(sSB.ToString(), now + "\t" + pLog.sMsg, true);

                    break;
                }
        }
    }

    public static void Check_File_Access(string _path, string sMsg, bool append)
    {
        //CSV 파일이 Open되어 있으면 강제적으로 Kill후 write한다.
        string filename = Path.GetFileName(_path);
        if (killps(filename) == true) m_Kill.Wait(2000);
        FileInfo fi = new FileInfo(_path);
        lock (lockObject)
        {
            if (append)
            {
                try
                {
                    using (FileStream file = new FileStream(fi.FullName, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        // You can add code here if file is accessible
                        writer.WriteLine(sMsg);
                        writer.Close();
                        writer.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message.ToString());
                    return;
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
                        writer.WriteLine(sMsg);
                        writer.Close();
                        writer.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message.ToString());
                    return;
                }
            }
        }
    }

    // error window 
    public static bool killps(string filename)
    {
        bool kill = false;

        string[] sp = filename.Split('.');
        if (sp[1] != "csv" && sp[1] != "Csv" && sp[1] != "CSV") return kill;

        string sFullFileName = filename + " - Excel";
        var excelProcesses = Process.GetProcessesByName("excel");

        foreach (var process in excelProcesses)
        {
            if (process.MainWindowTitle == $"Microsoft Excel - {filename}") // String.Format for pre-C# 6.0 
            {
                process.Kill();
                kill = true;
            }
            else if (process.MainWindowTitle == sFullFileName) //Excel 파일 Close 조건 추가
            {
                process.Kill();
                kill = true;

            }
            else if (process.MainWindowTitle == filename) //Excel 파일 Close 조건 추가
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