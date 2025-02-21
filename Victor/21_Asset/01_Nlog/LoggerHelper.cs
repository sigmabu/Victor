using NLog;
using NLog.Config;
using System;
using System.IO;

//namespace WindowsFormsApp1._04_NLog
namespace Victor
{
    public class LoggerHelper
    {
        private static LoggerHelper _instance;
        private static readonly object _lock = new object();
        private static Logger _logger;

        private static readonly string ConfigFilePath = @"D:\01_Source\Victor\Victor\21_Asset\01_Nlog\NLog.config";
        private static readonly string DefaultLogDirectory = @"D:\MyLogs";

        private LoggerHelper()
        {
            ConfigureLogger();
        }

        public static LoggerHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoggerHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private void ConfigureLogger()
        {
            try
            {
                // 로그 폴더 존재 확인 및 생성
                if (!Directory.Exists(DefaultLogDirectory))
                {
                    Directory.CreateDirectory(DefaultLogDirectory);
                }

                // 설정 파일이 존재하면 로드
                if (File.Exists(ConfigFilePath))
                {
                    LogManager.Configuration = new XmlLoggingConfiguration(ConfigFilePath);
                }
                else
                {
                    Console.WriteLine($"NLog 설정 파일을 찾을 수 없습니다: {ConfigFilePath}");
                }

                _logger = LogManager.GetCurrentClassLogger();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NLog 설정 오류: {ex.Message}");
            }
        }

        public void Info(string message) => _logger.Info(message);
        public void Warn(string message) => _logger.Warn(message);
        public void Error(string message, Exception ex = null) => _logger.Error(ex, message);
        public void Debug(string message) => _logger.Debug(message);
        public void Fatal(string message, Exception ex = null) => _logger.Fatal(ex, message);
    }
}