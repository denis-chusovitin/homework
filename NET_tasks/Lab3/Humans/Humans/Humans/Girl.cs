using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    [Couple("Student", 0.7, "Girl")]
    [Couple("Botan", 0.3, "SmartGirl")]
    public class Girl : Human
    {
        public string Patronymic { get; set; }
        public Girl() : base(Gender.Female)
        {
            Patronymic = NameHelper.GetRandomPatronymic(Gender.Female);
        }
        public Girl(string name, string parentName) : base(Gender.Female, name)
        {
            Patronymic = NameHelper.GetPatronymic(parentName, Gender.Female);
        }
    }
}
