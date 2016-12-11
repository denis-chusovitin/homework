namespace Task3
{
    public class PostalCodeChecker
    {
        public static bool IsPostalCode(string str)
        {
            return Checker.CheckString(str, @"^[\d]{5}([\d]|([-][\d]{5}))$");
        }
    }
}
