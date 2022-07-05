using System.Linq;
using System.Text;

namespace Loggers.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size => sb.ToString().Where(c => char.IsLetter(c)).Sum(c => c);

        public void Write(string message)
         => sb.Append(message);

    }
}
