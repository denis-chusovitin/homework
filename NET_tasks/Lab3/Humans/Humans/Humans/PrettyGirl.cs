namespace Humans
{
    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Botan", 0.1, "PrettyGirl")]
    public sealed class PrettyGirl : Girl
    {
        public PrettyGirl() : base() { }
        public PrettyGirl(string name, string parentName) : base(name, parentName) { }
    }
}
