using System;
using Humans;

namespace Lab4
{
    public static class HumanGenerator
    {
        static Random rnd = new Random();

        static int maleTypeAmount = Enum.GetValues(typeof(MaleType)).Length;
        static int femaleTypeAmount = Enum.GetValues(typeof(FemaleType)).Length;

        public static Human GenRandomMale()
        {
            switch ((MaleType)rnd.Next(0, maleTypeAmount))
            {
                case MaleType.Student:
                    return new Student(Gender.Male);
                default:
                    return new Botan((Gender.Male));
            }
        }

        public static Human GenRandomFemale()
        {
            switch ((FemaleType)rnd.Next(0, femaleTypeAmount))
            {
                case FemaleType.Girl:
                    return new Girl();
                case FemaleType.SmartGirl:
                    return new SmartGirl();
                default:
                    return new PrettyGirl();
            }
        }
    }
}
