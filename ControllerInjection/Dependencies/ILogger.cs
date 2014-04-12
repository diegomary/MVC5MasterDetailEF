using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInjection.Dependencies
{
    public  interface ILogger
    {
        void Log(string logData);
    }
}
