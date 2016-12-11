using System;
using Humans;

namespace Lab3
{
    static class Writer
    {
        private static void PrintStudent(Student st)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Student {0} {1}", st.Name, st.Patronymic);
            Console.ResetColor();
        }
        private static void PrintBotan(Botan bt)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Botan {0} {1}, оценка {2:F2}", bt.Name, bt.Patronymic, bt.AverageMark);
            Console.ResetColor();
        }
        private static void PrintParent(Parent pt)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Parent {0}, детей {1}", pt.Name, pt.ChildAmount);
            Console.ResetColor();
        }
        private static void PrintCoolParent(CoolParent pt)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("CoolParent {0}, детей {1}, денег ", pt.Name, pt.ChildAmount);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0:F2}", pt.Money);
            Console.ResetColor();
        }
        public static void PrintHuman(Human human, ConsoleColor color = ConsoleColor.Black)
        {
            Console.BackgroundColor = color;

            if (human is Student)
            {
                if (human is Botan)
                {
                    PrintBotan(human as Botan);
                }
                else
                {
                    PrintStudent(human as Student);
                }
            }
            else
            {
                if (human is CoolParent)
                {
                    PrintCoolParent(human as CoolParent);
                }
                else
                {
                    PrintParent(human as Parent);
                }
            }

            Console.ResetColor();
        }
    }
}
