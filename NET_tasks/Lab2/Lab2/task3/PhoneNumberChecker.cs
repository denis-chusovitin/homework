namespace Task3
{
    public class PhoneNumberChecker
    {
        public static bool IsPhoneNumber(string str)
        {
            return Checker.CheckString(str, @"^((\+7|8)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\-]{3,10}$");
        }
    }
}
