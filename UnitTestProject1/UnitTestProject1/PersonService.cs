using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestProject1.Interfaces;

namespace UnitTestProject1
{
    public class PersonService
    {
        private IPersonRepository personRepos;

        public PersonService(IPersonRepository repos)
        {
            personRepos = repos;
        }

        public List<Person> GetAllPeople()
        {
            return personRepos.GetPeople();
        }

        public List<Person> GetAllPeopleSorted()
        {
            List<Person> people = personRepos.GetPeople();
            people.Sort(delegate(Person lhp, Person rhp)
            {
                return lhp.LastName.CompareTo(rhp.LastName);
            })
            ;
            return people;
        }

        public Person GetPerson(string id)
        {
            try
            {
                return personRepos.GetPersonById(id);
            }
            catch (ArgumentException)
            {
                return null; // no person with this id found
            }
        }
    }
}
