using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    static class Generator
    {
        static Random Rnd = new Random();

        const int MinMark = 2;
        const int MaxMark = 5;

        const int MinSleepTime = 0;
        const int MaxSleepTime = 10000;

        const int MinExamPassTime = 0;
        const int MaxExamPassTime = 3000;

        const int MinStudentAmount = 10;
        const int MaxStudentAmount = 30;

        public static int GetRandomMark()
        {
            return Rnd.Next(MinMark, MaxMark + 1);
        }
        public static int GetRandomSleepTime()
        {
            return Rnd.Next(MinSleepTime, MaxSleepTime);
        }
        public static int GetRandomExamPassTime()
        {
            return Rnd.Next(MinExamPassTime, MaxExamPassTime);
        }
        public static int GetRandomStudentAmount()
        {
            return Rnd.Next(MinStudentAmount, MaxStudentAmount);
        }
    }
}
