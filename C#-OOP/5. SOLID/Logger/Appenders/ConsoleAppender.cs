using Loggers.EnumLogLevel;
using Loggers.Layouts;
using System;

namespace Loggers.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string dateTime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);

            this.Count++;

            Console.WriteLine(appendMessage);
        }

        public override string GetAppenderInfo()
        {
            return base.GetAppenderInfo() + Environment.NewLine;
        }
    }
}
