namespace Task3
{
    public static class EmailChecker
    {
        public static bool IsEmail(string str)
        {
            return Checker.CheckString(str, @"^[_a-zA-Z]?([.]?(\w)+)+[@]([a-zA-Z]+\.)+([a-zA-Z]{2,4}|museum|domain)$");
        }
    }
}
