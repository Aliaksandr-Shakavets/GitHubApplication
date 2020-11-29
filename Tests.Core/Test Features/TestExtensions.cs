using System.Text;

namespace Tests.Core
{
    public static class TestExtensions
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

        private static char GetRandomChar()
        {
            var numericCode = new System.Random().Next(0, 26);
            char randomChar = (char)('A' + numericCode);
            return randomChar;
        }
    }
}
