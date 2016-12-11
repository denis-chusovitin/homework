using System;

namespace Humans
{
    public static class NameHelper
    {
        static Random rnd = new Random();

        static string[] maleNames = { "Владимир", "Константин", "Денис", "Тарас", "Иван", "Степан" };
        static string[] femaleNames = { "Мария", "Анастасия", "Анна", "Евгения", "Елена", "Ольга" };

        public static string GetRandomName(Gender gender)
        {
            if (gender == Gender.Male)
            {
                return maleNames[rnd.Next(0, maleNames.Length)];
            }
            else
            {
                return femaleNames[rnd.Next(0, femaleNames.Length)];
            }
        }

        public static string GetPatronymic(string name, Gender gender)
        {
            if (gender == Gender.Male)
            {
                return name + "ович";
            }
            else
            {
                return name + "овна";
            }
        }
        public static string GetRandomPatronymic(Gender gender)
        {
            string name = maleNames[rnd.Next(0, maleNames.Length)];

            return GetPatronymic(name, gender);
        }
    }
}