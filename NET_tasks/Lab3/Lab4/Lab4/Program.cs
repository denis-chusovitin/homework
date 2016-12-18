using System;
using System.Linq;
using Lab4.Properties;

namespace Lab4
{
    internal static class Program
    {
        private static ConsoleKey[] exitKeys = { ConsoleKey.Q, ConsoleKey.F10 };
        private static bool IsExitKey(ConsoleKey key)
        {
            return exitKeys.Contains(key);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Resources.Greeting);
            Console.WriteLine(Resources.KeyEnter);

            God god = new God();

            while (!IsExitKey(Console.ReadKey(true).Key))
            {
                var man = HumanGenerator.GenRandomMale();
                var woman = HumanGenerator.GenRandomFemale();

                Writer.PrintCreature(man);
                Writer.PrintCreature(woman);

                var res = god.Couple(man, woman);

                if (res != null)
                {
                    Console.Write(Resources.IsLiked);
                    Writer.PrintCreature(res);
                }
                else
                {
                    Console.WriteLine(Resources.IsNotLiked);
                }
            } 
        }
    }
}
