using System;
using NUnit.Framework;

namespace Tests.Core
{
    public static class AppSettings
    {
        static AppSettings()
        {
            Url = new Uri(TestContext.Parameters[nameof(Url)]);
            Login = TestContext.Parameters[nameof(Login)];
            Password = TestContext.Parameters[nameof(Password)];
            Email = TestContext.Parameters[nameof(Email)];
            AccessToken = TestContext.Parameters[nameof(AccessToken)];
            BrowserType = TestContext.Parameters[nameof(BrowserType)];
        }

        public static Uri Url { get; }

        public static string Login { get; }

        public static string Password { get; }

        public static string Email { get; }

        public static string EmailPassword { get; }

        public static string AccessToken { get; }

        public static string BrowserType { get; }
    }
}
