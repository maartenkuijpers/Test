using System.Collections.Generic;
using UnitTestProject1.Core;

namespace UnitTestProject1.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
        Person GetPersonById(string id);
    }
}
