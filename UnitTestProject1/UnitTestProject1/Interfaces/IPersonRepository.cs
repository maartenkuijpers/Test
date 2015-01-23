using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestProject1.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
        Person GetPersonById(string id);
    }
}
