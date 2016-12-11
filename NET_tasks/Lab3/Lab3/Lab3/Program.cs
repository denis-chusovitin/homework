using System;
using System.Collections.Generic;
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

                file.Close();
                file.Dispose();
            }
        }

        private static void CreateHumans(God god, int pairAmount)
        {

            god.CreateHuman(Gender.Male);

            if (pairAmount > 1)
            {
                god.CreateHuman(Gender.Female);
            }

            for (int i = 2; i < pairAmount; i++)
            {
                god.CreateHuman();
            }

        }

        private static void PrintHumansWithBlanks(ReadOnlyCollection<Human> humans)
        {
            foreach (Human human in humans)
            {
                Writer.PrintHuman(human);
                Console.WriteLine();
            }
        }

        private static void PrintHumansInBlanks(ReadOnlyCollection<Human> humans)
        {
            int pos = 4;

            foreach (Human human in humans)
            {
                Console.SetCursorPosition(0, pos);
                Writer.PrintHuman(human, ConsoleColor.DarkGray);

                pos += 2;
            }
        }

        static void Main()
        {
            Console.WriteLine(Resources.Greeting);

            DateTime localDate = DateTime.Now;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine(Resources.SundayExcuse);
                return;
            }

            Console.WriteLine(Resources.PairAmountEnter);
            string s;
            s = Console.ReadLine();

            int pairAmount;
            if (!int.TryParse(s, out pairAmount) || pairAmount <= 0)
            {
                Console.WriteLine(Resources.InvalidNumber);
                return;
            }

            God god = new God();

            CreateHumans(god, pairAmount);

            ReadOnlyCollection<Human> humans = god.GetHumans();
            PrintHumansWithBlanks(humans);

            foreach(Human human in humans)
            {
                god.CreatePair(human);
            }
          
            humans = god.GetPairedHumans();
            PrintHumansInBlanks(humans);
        }
    }
}
