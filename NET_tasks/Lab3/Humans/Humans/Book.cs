namespace Humans
{
    public class Book : IHasName
    {
        public string Name { get; }
        public Book(string name)
        {
            Name = name;
        }
    }
}
