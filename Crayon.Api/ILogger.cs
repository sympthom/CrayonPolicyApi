using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api
{
    public interface ILogger
    {
        void Information(string message);

        void Warning(string message);

        void Error(string message);
    }
}
