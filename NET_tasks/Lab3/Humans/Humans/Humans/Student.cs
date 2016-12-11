namespace Humans
{
    [Couple("Girl", 0.7, "Girl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    public class Student : Human
    {
        public string Patronymic { get; } 
        public Student(Parent pt) : base()
        {
            Patronymic = NameHelper.GetPatronymic(pt.Name, Gender);
        }
        public Student(Gender gender) : base(gender)
        {
            Patronymic = NameHelper.GetRandomPatronymic(gender);
        }
    }
}
