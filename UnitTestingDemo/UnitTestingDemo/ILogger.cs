using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingDemo
{
    public interface ILogger
    {
        void Log(params object[] values);
    }
}
