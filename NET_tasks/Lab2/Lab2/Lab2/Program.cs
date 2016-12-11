using System;
using Lab2.Properties;

namespace Lab2
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine(Resources.Greeting);
            Console.WriteLine(Resources.StringEnter);

            var stringToCheck = Console.ReadLine();

            while (stringToCheck.Length > 0)
            {
                if (PalindromeChecker.IsPalindrome(stringToCheck))
                {
                    Console.WriteLine(Resources.IsPalindrome);
                }
                else
                {
                    Console.WriteLine(Resources.IsNotPalindrome);
                }

                stringToCheck = Console.ReadLine();
            }
        }
    }
}