using System;

namespace Humans
{
    public static class HumanHelper
    {
        static Random rnd = new Random();

        const int MinAge = 16;
        const int MaxAge = 80;

        const int GenderAmount = 2;

        public static Gender GetRandomGender()
        {
            return (Gender)rnd.Next(0, GenderAmount);
        }
        public static int GetRandomAge()
        {
            return rnd.Next(MinAge, MaxAge);
        }
        public static double GetRandomMark()
        {
            return 2 * rnd.NextDouble() + 3;
        }
        public static double GetRandomMoney()
        {
            return Math.Pow(10, GetRandomMark());
        }
    }
}
