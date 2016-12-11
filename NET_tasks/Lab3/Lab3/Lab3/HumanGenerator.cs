using System;
using Humans;

namespace Lab3
{
    public static class HumanGenerator
    {
        static Random rnd = new Random();

        static int humanTypeAmount = Enum.GetValues(typeof(HumanType)).Length;

        private static Human SelectHuman(Gender gender)
        {
            switch ((HumanType)rnd.Next(0, humanTypeAmount))
            {
                case HumanType.Parent:
                    return new Parent();
                case HumanType.Student:
                    return new Student(gender);
                case HumanType.CoolParent:
                    return new CoolParent();
                default:
                    return new Botan(gender);
            }
        }

        public static Human GenRandomHuman()
        {
            return SelectHuman(HumanHelper.GetRandomGender());
        }

        public static Human GenRandomHuman(Gender gender)
        {
            if (gender == Gender.Male)
            {
                return SelectHuman(gender);
            }
            else
            {
                if (rnd.Next(0, 2) == 0)
                {
                    return new Student(gender);
                }
                else
                {
                    return new Botan(gender);
                }

            }
        }
    }
}
