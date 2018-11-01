using System.Threading;

namespace UnitTestingDemo
{
    public class Logger : ILogger
    {
        public void Log(params object[] values)
        {
            Thread.Sleep(10000);
        }
    }
}
