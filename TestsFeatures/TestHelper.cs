using System;
using System.Text;

namespace TestsFeatures
{
    public static class TestHelper
    {
        public static string GetRandomString(int length)
        {
            var randomString = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                randomString.Append(GetRandomChar());
            }

            return randomString.ToString();
        }

        public static char GetRandomChar()
        {
            var numericCode = new Random().Next(0, 26);
            char randomChar = (char)('A' + numericCode);

            return randomChar;
        }
    }
}
