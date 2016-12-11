using System;
using System.Collections;
using Humans;

namespace Lab4
{
    public class God 
    {
        private bool isLikeCheck;
        private const string namespaceName = "Humans";
        private const string projectName = "Humans";

        private static Random rnd = new Random();
        private bool IsLike(double fisrtProbability, double secondProbability)
        {
            if (isLikeCheck)
            {
                return (rnd.NextDouble() < fisrtProbability * secondProbability);
            }

            return true;
        }

        public CoupleAttribute FindAttribute(Human first, Human second)
        {
            Type type1 = first.GetType();
            Type type2 = second.GetType();

            IEnumerator pairs = Attribute.GetCustomAttributes(type1, typeof(CoupleAttribute)).GetEnumerator();

            while (pairs.MoveNext())
            {
                var attr = pairs.Current as CoupleAttribute;
                if (attr.Pair == type2.Name)
                {
                    return attr;
                }
            }

            return null;
        }

        private string GetName(Human human)
        {
            try
            {
                var name = human.GetType().GetMethods()[2].Invoke(human, null).ToString(); //get_Name
                return name;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        private IHasName CreateChildOrBook(string childType, string childName, string parentName) 
        {
            var creatureType = Type.GetType($"{namespaceName}.{childType}, {projectName}"); 

            if (childType != "Book")
            {
                return (IHasName)Activator.CreateInstance(creatureType, childName, parentName);
            }
            else
            {
                return (IHasName)Activator.CreateInstance(creatureType, childName);
            }
        }
        
        public IHasName Couple(Human first, Human second)
        {
            if (first.Gender == second.Gender)
            {
                throw new DateException();
            }

            var man = Gender.Male == first.Gender ? first : second;
            var woman = Gender.Female == second.Gender ? second : first;

            var manAttribute = FindAttribute(man, woman);
            var womanAttribute = FindAttribute(woman, man);
            var childName = GetName(woman);

            if (IsLike(manAttribute.Probability, womanAttribute.Probability))
            {
                return CreateChildOrBook(manAttribute.ChildType, childName, man.Name);
            }

            return null;
        }

        public God(bool isLikeCheck)
        {
            this.isLikeCheck = isLikeCheck;
        }

        public God() : this(true) { }
    }
}
