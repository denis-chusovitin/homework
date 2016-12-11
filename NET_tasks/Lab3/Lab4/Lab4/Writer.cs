using System;
using Humans;

namespace Lab4
{
    public static class Writer
    {
        private static void PrintHuman(Girl girl, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("{0}: {1} {2}", girl.GetType().Name, girl.Name, girl.Patronymic);
            Console.ResetColor();
        }

        private static void PrintHuman(Student student, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("{0}: {1} {2}", student.GetType().Name, student.Name, student.Patronymic);
            Console.ResetColor();
        }
        public static void PrintCreature(IHasName creature)
        {
            if (creature is Book)
            {
                Console.WriteLine("Книга");
                return;
            }

            if (creature is Student)
            {
                if (creature is Botan)
                {
                    PrintHuman(creature as Botan, ConsoleColor.Cyan);
                }
                else
                {
                    PrintHuman(creature as Student, ConsoleColor.Yellow);
                }
                return;
            }

            if (creature is Girl)
            {
                if (creature is PrettyGirl)
                {
                    PrintHuman(creature as PrettyGirl, ConsoleColor.Magenta);
                    return;
                }

                if (creature is SmartGirl)
                {
                    PrintHuman(creature as SmartGirl, ConsoleColor.Blue);
                    return;
                }

                PrintHuman(creature as Girl, ConsoleColor.Green);
            }
        }
    }
}
