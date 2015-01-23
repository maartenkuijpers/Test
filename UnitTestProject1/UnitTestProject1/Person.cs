using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
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
