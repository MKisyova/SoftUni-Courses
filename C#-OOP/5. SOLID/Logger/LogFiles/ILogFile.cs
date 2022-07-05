
namespace Loggers.LogFiles
{
    public interface ILogFile
    {
        public int Size { get; }

        void Write(string message);
    }
}
