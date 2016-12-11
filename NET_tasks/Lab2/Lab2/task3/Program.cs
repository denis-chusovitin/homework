using System;
using Task3.Properties;

namespace Task3
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Resources.Greeting);
            Console.WriteLine(Resources.TypeString); 

            var stringToCheck = Console.ReadLine();

            while (stringToCheck.Length != 0)
            {
                if (EmailChecker.IsEmail(stringToCheck))
                {
                    Console.WriteLine(Resources.ValidEmail);
                }
                else if (PostalCodeChecker.IsPostalCode(stringToCheck))
                {
                    Console.WriteLine(Resources.ValidCode);
                }
                else if (PhoneNumberChecker.IsPhoneNumber(stringToCheck))
                {
                    Console.WriteLine(Resources.ValidNumber);
                }
                else
                {
                    Console.WriteLine(Resources.InvalidString);
                }

                stringToCheck = Console.ReadLine();
            }
        }
    }
}
