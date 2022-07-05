using Loggers.Appenders;
using Loggers.EnumLogLevel;
using Loggers.Layouts;
using Loggers.LogFiles;
using Loggers.Loggers;
using System;

namespace Loggers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            ILogger logger = new Logger();

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] inputInfo = Console.ReadLine().Split(" ");

                string appenderType = inputInfo[0];
                string layoutType = inputInfo[1];

                IAppender appender = null;
                ILayout layout = null;

                if (layoutType == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }

                else if (layoutType == "XmlLayout")
                {
                    layout = new XmlLayout();
                }         

                if (appenderType == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }

                else if (appenderType == "FileAppender")
                {
                    ILogFile logfile = new LogFile();
                    
                    appender = new FileAppender(layout, logfile);
                }

                if (inputInfo.Length == 3)
                {
                    string reportLevel = inputInfo[2];
                    bool isValidLogLevel = Enum.TryParse(reportLevel, true, out LogLevel logLevel);

                    if (isValidLogLevel)
                    {
                        appender.ReportLevel = logLevel;
                    }
 
                }

                logger.Appenders.Add(appender);
            }



            string inputMessage = Console.ReadLine();

            while (inputMessage != "END")
            {
                string[] inputMessageSplitted = inputMessage.Split('|');

                string reportLevel = inputMessageSplitted[0];
                string dateTime = inputMessageSplitted[1];
                string message = inputMessageSplitted[2];

                bool isValidLogLevel = Enum.TryParse(reportLevel, true, out LogLevel logLevel);

                if (!isValidLogLevel)
                {
                    inputMessage = Console.ReadLine();
                    continue;
                }

                if (logLevel == LogLevel.Info)
                {
                    logger.Info(dateTime, message);
                }

                else if (logLevel == LogLevel.Warning)
                {
                    logger.Warning(dateTime, message);
                }

                else if (logLevel == LogLevel.Error)
                {
                    logger.Error(dateTime, message);
                }

                else if (logLevel == LogLevel.Critical)
                {
                    logger.Critical(dateTime, message);
                }

                else if (logLevel == LogLevel.Fatal)
                {
                    logger.Fatal(dateTime, message);
                }

                inputMessage = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            Console.WriteLine();
            Console.WriteLine(logger.GetLoggerInfo());
        }
    }
}
