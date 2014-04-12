using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerInjection.Dependencies
{
    public class DefaultLogger : ILogger
    {
        public void Log(string logData)
        {
            System.Diagnostics.Debug.WriteLine(logData, "default");
        }
    } 
}