using OpenQA.Selenium;
using System;

namespace Tests.Core.Services
{
    public static class JavaScriptExecutorService
    {
        private static IWebDriver webDriver = WebDriverSingleton.GetWebDriver();

        public static object Execute(string script)
        {
            if (string.IsNullOrEmpty(script))
            {
                throw new ArgumentException($"'{nameof(script)}' cannot be null or empty", nameof(script));
            }

            return ((IJavaScriptExecutor)webDriver).ExecuteScript(script);
        }
    }
}
