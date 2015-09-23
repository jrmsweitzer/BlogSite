using NUnit.Core;
using NUnit.Core.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium.Framework
{
    [NUnitAddinAttribute(Type = ExtensionType.Core,
        Name = "Log Failure Messages",
        Description = "Logs test results to the logger")]
    public class NUnitExtension : IAddin, EventListener
    {
        public bool Install(IExtensionHost host)
        {
            //LOGGER.GetLogger(LOGNAME).LogInfo("Install");
            IExtensionPoint listeners = host.GetExtensionPoint("EventListeners");
            if (listeners == null)
                return false;

            listeners.Install(this);
            return true;
        }

        public void RunStarted(string name, int testCount) { }
        public void SuiteStarted(TestName testName) { }
        public void TestStarted(TestName testName) { }
        public void TestFinished(TestResult result)
        {
            Stacktrace.AddTestResult(result);
            Stacktrace.LogStackTrace();
        }
        public void SuiteFinished(TestResult result) { }
        public void RunFinished(TestResult result) { }

        public void TestOutput(TestOutput testOutput) { }
        public void RunFinished(Exception exception) { }
        public void UnhandledException(Exception exception) { }
    }
}
