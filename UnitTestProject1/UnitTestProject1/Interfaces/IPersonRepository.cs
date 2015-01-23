using System.Collections.Generic;

namespace UnitTestProject1.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
        Person GetPersonById(string id);
    }
}
