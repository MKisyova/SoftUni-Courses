using Loggers.EnumLogLevel;
using Loggers.Layouts;

namespace Loggers.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public LogLevel ReportLevel { get; set; }

        public int Count { get; protected set; }

        public abstract void Append(string dateTime, LogLevel reportLevel, string message);

        public virtual string GetAppenderInfo()
                 => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.Count}";
    }
}
