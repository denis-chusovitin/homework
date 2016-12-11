namespace Humans
{
    [Couple("Student", 0.2, "Girl")]
    [Couple("Botan", 0.5, "Book")]
    public sealed class SmartGirl : Girl
    {
        public SmartGirl() : base() { }
        public SmartGirl(string name, string parentName) : base(name, parentName) { }
    }
}
