using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Humans;

namespace Lab3
{
    internal class God : IGod
    {
        private List<Human> humans = new List<Human>();
        private List<Human> pairedHumans = new List<Human>();

        public double this[int i] 
        {
            get
            {
                if (i < 0 || i >= humans.Count)
                {
                    throw new System.IndexOutOfRangeException();
                }
                CoolParent human = humans[i] as CoolParent;

                if (human != null)
                {
                    return human.Money;
                }
                else
                {
                    return 0;
                }        
            }
        }

        public double GetTotalMoney()
        {
            double sum = 0;
            for (int i = 0; i < humans.Count; i++)
            {
                sum += this[i];
            }

            return sum;
        }

        public void CreateHuman()
        {
            humans.Add(HumanGenerator.GenRandomHuman());
        }

        public void CreateHuman(Gender sex)
        {
            humans.Add(HumanGenerator.GenRandomHuman(sex));
        }

        public void CreatePair(Human human)
        {
            if (human == null)
            {
                return;
            }

            Human humanToAdd;
            
            if (human is Student)
            {
                if (human is Botan)
                {
                    humanToAdd = new CoolParent(human as Botan);
                }
                else
                {
                    humanToAdd = new Parent(human as Student);
                }
            }
            else
            {
                if (human is CoolParent)
                {
                    humanToAdd = new Botan(human as CoolParent);
                }
                else 
                {
                    humanToAdd = new Student(human as Parent);
                }
            }

            pairedHumans.Add(humanToAdd);
        }

        public ReadOnlyCollection<Human> GetHumans()
        {
            return humans.AsReadOnly();
        }

        public ReadOnlyCollection<Human> GetPairedHumans()
        {
            return pairedHumans.AsReadOnly();
        }
    }
}
