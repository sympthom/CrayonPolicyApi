using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Crayon.Api.Policy.Test
{
    public sealed class DebugLogger : ILogger
    {
        public void Information(string message)
        {
            Debug.WriteLine(message);
        }

        public void Warning(string message)
        {
            Debug.WriteLine(message);
        }

        public void Error(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
