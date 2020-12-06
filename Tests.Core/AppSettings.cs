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
            PersonalAccessToken = TestContext.Parameters[nameof(PersonalAccessToken)];
            BrowserType = TestContext.Parameters[nameof(BrowserType)];
        }

        public static Uri Url { get; }

        public static string Login { get; }

        public static string Password { get; }

        public static string Email { get; }

        public static string EmailPassword { get; }

        public static string PersonalAccessToken { get; }

        public static string BrowserType { get; }
    }
}
