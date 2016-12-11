namespace Humans
{
    public class Parent : Human
    {
        public int ChildAmount { get; }
        public Parent(Student st)
        {
            Name = st.Patronymic.Substring(0, st.Patronymic.Length - 4);
            Gender = Gender.Male;
            ChildAmount = 1;
            Age = st.Age + HumanHelper.GetRandomAge();
        }
        public Parent() : base(Gender.Male)
        {
            ChildAmount = 1;
        }
    }
}
