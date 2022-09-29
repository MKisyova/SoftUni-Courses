using Loggers.EnumLogLevel;
using Loggers.Layouts;

namespace Loggers.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public int Count { get; }

        public LogLevel ReportLevel { get; set; }

        void Append(string dateTime, LogLevel reportLevel, string message);

        string GetAppenderInfo();
    }
}
