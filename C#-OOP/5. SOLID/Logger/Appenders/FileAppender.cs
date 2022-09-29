using Loggers.EnumLogLevel;
using Loggers.Layouts;
using Loggers.LogFiles;
using System;
using System.IO;

namespace Loggers.Appenders
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";

        public FileAppender(ILayout layout, ILogFile logfile) : base(layout)
        {
            LogFile = logfile;
        }

        public ILogFile LogFile { get; set; }
        public override void Append(string dateTime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);

            this.Count++;

            LogFile.Write(appendMessage);

            File.AppendAllText(FilePath, appendMessage + Environment.NewLine);

        }

        public override string GetAppenderInfo()
        {
            return base.GetAppenderInfo() + $", File size {this.LogFile.Size}" + Environment.NewLine;
        }
    }
}
