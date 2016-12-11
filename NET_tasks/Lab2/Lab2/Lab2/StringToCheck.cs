using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    static class PalindromeChecker
    {
        private static string ignoredChars = " \t!,.?!:-()[]";
        private static bool IsDelimiter(char c)
        {
            return ignoredChars.Contains(c.ToString());
        }
        public static bool IsPalindrome(string str)
        {
            var i = 0;
            var j = str.Length - 1;
            var isPalindrome = true;

            while (i < j && isPalindrome)
            {
                if (IsDelimiter(str[i]))
                {
                    i++;
                    continue;
                }

                if (IsDelimiter(str[j]))
                {
                    j--;
                    continue;
                }

                isPalindrome = char.ToLower(str[i]) == char.ToLower(str[j]);

                i++;
                j--;
            }

            return isPalindrome;
        }
    }
}
