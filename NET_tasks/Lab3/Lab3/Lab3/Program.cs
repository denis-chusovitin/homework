using System;
using Lab3.Properties;
using System.Collections.ObjectModel;
using Humans;

namespace Lab3
{
    class Program
    {
        private static void PrintMoney(double money)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Resources.OutputFile))
            {
                file.WriteLine("{0:F2}", money);
            }
        }

        private static void PrintHumansInBlanks(ReadOnlyCollection<Human> humans)
        {
            int pos = 4;

            foreach (Human human in humans)
            {
                Console.SetCursorPosition(0, pos);
                HumanPrinter.PrintHuman(human, ConsoleColor.DarkGray);

                pos += 2;
            }
        }

        static void Main()
        {
            Console.WriteLine(Resources.Greeting);

            DateTime localDate = DateTime.Now;
       /*     if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine(Resources.SundayExcuse);
                return;
            }
            */
            Console.WriteLine(Resources.PairAmountEnter);

            int pairAmount;
            if (!int.TryParse(Console.ReadLine().Trim(), out pairAmount) || pairAmount <= 0)
            {
                Console.WriteLine(Resources.InvalidNumber);
                return;
            }

            God god = new God();

            GodHelper.CreateHumans(god, pairAmount);

            ReadOnlyCollection<Human> humans = god.GetHumans();
            GodHelper.PrintHumansWithBlanks(humans);

            foreach(Human human in humans)
            {
                god.CreatePair(human);
            }
          
            humans = god.GetPairedHumans();
            PrintHumansInBlanks(humans);
        }
    }
}
