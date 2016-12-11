using System.Text.RegularExpressions;

namespace Task3
{
    static class Checker
    {
        public static bool CheckString(string str, string pattern)
        {
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, pattern);
        }
    }
}
