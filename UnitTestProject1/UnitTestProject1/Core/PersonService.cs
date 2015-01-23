using System;
using System.Collections.Generic;
using UnitTestProject1.Interfaces;

namespace UnitTestProject1.Core
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
            var people = personRepos.GetPeople();
            people.Sort((lhp, rhp) => String.Compare(lhp.LastName, rhp.LastName, StringComparison.Ordinal));
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
