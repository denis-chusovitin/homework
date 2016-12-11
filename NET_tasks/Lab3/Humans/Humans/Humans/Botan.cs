using System;

namespace Humans
{
    [Couple("Girl", 0.7, "SmartGirl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.8, "Book")]
    public class Botan : Student
    {
        public double AverageMark { get; }
        public Botan(CoolParent pt) : base(pt as Parent)
        {
            AverageMark = Math.Log10(pt.Money);
        }
        public Botan(Gender gender) : base(gender)
        {
            AverageMark = HumanHelper.GetRandomMark();
        }
    }
}
