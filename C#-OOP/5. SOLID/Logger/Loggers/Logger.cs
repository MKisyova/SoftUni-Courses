using Loggers.Appenders;
using Loggers.EnumLogLevel;
using System.Collections.Generic;
using System.Text;

namespace Loggers.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>();
            Appenders.AddRange(appenders);
        }

        public List<IAppender> Appenders { get;}

        public void Critical(string dateTime, string message)
        {
            LogData(dateTime, LogLevel.Critical, message);

        }

        public void Error(string dateTime, string message)
        {
            LogData(dateTime, LogLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            LogData(dateTime, LogLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            LogData(dateTime, LogLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            LogData(dateTime, LogLevel.Warning, message);
        }

        public string GetLoggerInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var appender in Appenders)
            {
                sb.AppendLine(appender.GetAppenderInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private void LogData(string dateTime, LogLevel reportLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                if (reportLevel >= appender.ReportLevel)
                {
                    appender.Append(dateTime, reportLevel, message);
                }

            }
        }
    }
}
