namespace UnitTestProject1.Core
{
    public class Person
    {
        public string Id;
        public string FirstName;
        public string LastName;

        public Person(string newId, string fn, string ln)
        {
            Id = newId;
            FirstName = fn;
            LastName = ln;
        }
    }
}
