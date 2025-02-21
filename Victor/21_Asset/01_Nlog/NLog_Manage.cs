using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Victor
{
    public class LoggerService
    {
        private static readonly ILogger logger;

        static LoggerService()
        {
            // 특정 위치의 설정 파일 로드
            var configPath = @"C:\Config\NLog.config";
            var config = new XmlLoggingConfiguration(configPath);
            LogManager.Configuration = config;

            logger = LogManager.GetCurrentClassLogger();
        }

        public static void LogInfo(string message)
        {
            logger.Info(message);
        }

        public static void LogError(string message)
        {
            logger.Error(message);
        }

        public static void LogDebug(string message)
        {
            logger.Debug(message);
        }
    }

    /// <summary>
    ///  사용법 
    ///  static NLog_Manage Log_W = new NLog_Manage(); 생성후 사용
    /// </summary>
    public class NLog_Manage
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static Queue<string> taskQueue = new Queue<string>();
        private static Queue<string> InfoQueue = new Queue<string>();
        private static Queue<string> ErrorQueue = new Queue<string>();
        private static Queue<string> WarnQueue = new Queue<string>();
        private static Queue<string> DebugQueue = new Queue<string>();
        private static Queue<string> TraceQueue = new Queue<string>();
        private static bool isProcessing = false;
        private static Thread workerThread;
        private static Thread LogEnqueueThread;
        private static Thread LogEnqueueThread_1;

        private static bool isTrace_Enque = false;

        static NLog_Manage()
        {
            string sPath = @"D:\MyLogs\";
            ConfigureDynamicLogFiles(sPath);
            LogTask_Initial();
        }
        private static void ConfigureDynamicLogFiles(string logDirectory)
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // 특정 폴더에 있는 nlog.config 파일 로드
            //string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "nlog.config");
            string configPath = Path.Combine(@"D:\96_Worker\Winform\SharedMem\WindowsFormsApp1\", "04_NLog", "nlog.config");
            LogManager.LoadConfiguration(configPath);

            logger.Info("NLog 시작됨. 설정 파일: " + configPath);


            var config = LogManager.Configuration;

            // 일반 로그 타겟 변경
            var generalLog = (FileTarget)config.FindTargetByName("generalLog");
            if (generalLog != null)
            {
                generalLog.FileName = Path.Combine(logDirectory, "general_${shortdate}.log");
            }

            // 오류 로그 타겟 변경
            var errorLog = (FileTarget)config.FindTargetByName("errorLog");
            if (errorLog != null)
            {
                errorLog.FileName = Path.Combine(logDirectory, "error_${shortdate}.log");
            }

            var loggingRule = LogManager.Configuration.LoggingRules[0];
            loggingRule.SetLoggingLevels(LogLevel.Trace, LogLevel.Fatal); // Info 이상만 기록
            LogManager.ReconfigExistingLoggers();
        }


        private static void LogTask_Initial()
        {
            if (!isProcessing)
            {
                isProcessing = true;
                workerThread = new Thread(WriteLogQueue);
                workerThread.IsBackground = true;
                workerThread.Start();

                //LogEnqueueThread = new Thread(LogEnQueue);
                //LogEnqueueThread.IsBackground = true;
                //LogEnqueueThread.Start();

                //LogEnqueueThread_1 = new Thread(LogEnQueue_1);
                //LogEnqueueThread_1.IsBackground = true;
                //LogEnqueueThread_1.Start();
            }
        }

        private static void WriteLogQueue()
        {
            while (true)
            {
                string sGetLog = null;

                lock (TraceQueue)
                {
                    if (TraceQueue.Count > 0)
                    {
                        sGetLog = TraceQueue.Dequeue();
                        logger.Trace($"{DateTime.Now} :{sGetLog}");
                    }
                }
                sGetLog = null;
                lock (DebugQueue)
                {
                    if (DebugQueue.Count > 0)
                    {
                        sGetLog = DebugQueue.Dequeue();
                        logger.Debug($"{DateTime.Now} :{sGetLog}");
                    }
                }
                sGetLog = null;
                lock (WarnQueue)
                {
                    if (WarnQueue.Count > 0)
                    {
                        sGetLog = WarnQueue.Dequeue();
                        logger.Warn($"{DateTime.Now} :{sGetLog}");
                    }
                }
                sGetLog = null;
                lock (ErrorQueue)
                {
                    if (ErrorQueue.Count > 0)
                    {
                        sGetLog = ErrorQueue.Dequeue();
                        logger.Error($"{DateTime.Now} :{sGetLog}");
                    }
                }
                sGetLog = null;

                lock (InfoQueue)
                {
                    if (InfoQueue.Count > 0)
                    {
                        sGetLog = InfoQueue.Dequeue();
                        logger.Info($"{DateTime.Now} :{sGetLog}");
                    }
                    else
                    {
                        //isProcessing = false;
                        //break;
                    }
                }

                if (sGetLog != null)
                {
                    //this.Invoke((MethodInvoker)delegate {
                    //    Console.WriteLine($"처리 중: {sGetLog}");
                    //    lblStatus.Text = $"처리 중: {task}";
                    //    listBoxQueue.Items.RemoveAt(0);
                    //});
                    //Thread.Sleep(2000); // 작업 처리 시뮬레이션
                }
            }
        }

        /// <summary>
        /// Test 용도
        /// </summary>
        private void LogEnQueue()
        {
            while (true)
            {
                if (isTrace_Enque == true)
                {
                    logger.Trace("button1_Click,LogEnQueue ------- 로그가 기록되었습니다.");
                }
            }
        }

        /// <summary>
        /// Test 용도
        /// </summary>
        private void LogEnQueue_1()
        {
            while (true)
            {
                if (isTrace_Enque == true)
                {
                    logger.Trace("button1_Click,LogEnQueue_1 ++++++++++++++ 로그가 기록되었습니다.");
                }
            }
        }
        public static void Info(string sData)
        {
            lock (InfoQueue)
            {
                InfoQueue.Enqueue(sData);
            }
        }
        public void Error(string sData)
        {
            lock (ErrorQueue)
            {
                ErrorQueue.Enqueue(sData);
            }
        }

        public void Warn(string sData)
        {
            lock (WarnQueue)
            {
                WarnQueue.Enqueue(sData);
            }
        }
        public void Debug(string sData)
        {
            lock (DebugQueue)
            {
                DebugQueue.Enqueue(sData);
            }
        }
        public void Trace(string sData)
        {
            lock (TraceQueue)
            {
                TraceQueue.Enqueue(sData);
            }
        }
    }
}