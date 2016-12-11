using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CoupleAttribute : Attribute
    {
        public string Pair { get; }
        public double Probability { get; }
        public string ChildType { get; }

        public CoupleAttribute(string pair, double probability, string childType)
        {
            Pair = pair;
            Probability = probability;
            ChildType = childType;
        }
    }
}
