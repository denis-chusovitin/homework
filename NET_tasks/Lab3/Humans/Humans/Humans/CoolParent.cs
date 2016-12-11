using System;

namespace Humans
{
    public class CoolParent : Parent
    {
        public double Money { get; }
        public CoolParent(Botan bt) : base(bt as Student)
        {
            Money = Math.Pow(10, bt.AverageMark);
        }
        public CoolParent() : base()
        {
            Money = HumanHelper.GetRandomMoney();
        }
    }
}
