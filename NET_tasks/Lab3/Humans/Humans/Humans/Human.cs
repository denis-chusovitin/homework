namespace Humans
{
    public class Human : IHasName
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Human() : this(HumanHelper.GetRandomGender()) { }
        public Human(Gender gender) : this(gender, NameHelper.GetRandomName(gender)) { }
        public Human(Gender gender, string name)
        {
            Gender = gender;
            Age = HumanHelper.GetRandomAge();
            Name = name;
        }
    }
}
