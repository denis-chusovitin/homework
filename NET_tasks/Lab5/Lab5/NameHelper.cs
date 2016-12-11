using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class NameHelper
    {
        static Random rnd = new Random();
        static string[] names = { "Василий", "Петр", "Михаил", "Мария", "Александр", "Евгения",
            "Ольга", "Дмитрий", "Дарья", "Анастасия" };
        public static string GetRandomName()
        {
            return names[rnd.Next(0, names.Length)];    
        }
    }
}
