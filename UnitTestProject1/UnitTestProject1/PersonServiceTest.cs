using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Mocks;
using UnitTestProject1.Interfaces;

namespace UnitTestProject1
{
    [TestFixture]
    public class PersonServiceTest
    {
        // The dynamic mock proxy that we will use to implement IPersonRepository
        private DynamicMock personRepositoryMock;

        // Set up some testing data
        private Person onePerson = new Person("1", "Wendy", "Whiner");
        private Person secondPerson = new Person("2", "Aaron", "Adams");
        private List<Person> peopleList;

        [SetUp]
        public void TestInit()
        {
            peopleList = new List<Person>();
            peopleList.Add(onePerson);
            peopleList.Add(secondPerson);

            // Construct a Mock Object of the IPersonRepository Interface
            personRepositoryMock = new DynamicMock(typeof(IPersonRepository));
        }

        [Test]
        public void TestGetAllPeople()
        {
            // Tell that mock obecjt when the "GetPeople" method is called to returns a predefined list of people.
            personRepositoryMock.ExpectAndReturn("GetPeople", peopleList);

            // Construct a Person service with the Mock IPersonRepository.
            PersonService service = new PersonService((IPersonRepository) personRepositoryMock.MockInstance);

            // Call methods and assert tests
            Assert.AreEqual(2, service.GetAllPeople().Count);
        }

        [Test]
        public void TestGetAllPeopleSorted()
        {
            // Tell that mock object when the "GetPeople" method is called to returns a predefined list of people.
            personRepositoryMock.ExpectAndReturn("GetPeople", peopleList);

            // Construct a Person service with the Mock IPersonRepository.
            PersonService service = new PersonService((IPersonRepository)personRepositoryMock.MockInstance);

            // This method really has "Business Logic" in it - the sorting of people
            List<Person> people = service.GetAllPeopleSorted();
            Assert.IsNotNull(people);
            Assert.AreEqual(2, people.Count);

            // Make sure the first person returns is the correct one.
            Person p = people[0];
            Assert.AreEqual("Adams", p.LastName);
        }

        [Test]
        public void TestGetSinglePersonWithValidId()
        {
            // Tell that mock object when the "GetPeople" method is called to returns a predefined list of people.
            personRepositoryMock.ExpectAndReturn("GetPeople", peopleList);

            // Construct a Person service with the Mock IPersonRepository.
            PersonService service = new PersonService((IPersonRepository)personRepositoryMock.MockInstance);

            Person p = service.GetPerson("1");
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Id, "1");
        }

        [Test]
        public void TestGetSinglePersonWithInvalidId()
        {
            // Tell that mock object when the "GetPersonById" is called with a null value to throw an ArgumentException
            personRepositoryMock.ExpectAndThrow("GetPersonById", new ArgumentException("Invalid person id."), null);

            // Construct a Person service with the Mock IPersonRepository.
            PersonService service = new PersonService((IPersonRepository)personRepositoryMock.MockInstance);

            // The only way to get null is if the underlying IPersonRepository threw an ArgumentException.
            Assert.IsNull(service.GetPerson(null));
        }
    }
}
