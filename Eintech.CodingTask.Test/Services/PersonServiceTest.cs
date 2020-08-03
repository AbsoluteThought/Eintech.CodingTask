using Eintech.CodingTask.Domain.Interfaces;
using Eintech.CodingTask.Domain.Services;
using Eintech.CodingTask.Infrastruture.Data;
using Eintech.CodingTask.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eintech.CodingTask.Test.Services
{
    public class PersonServiceTest
    {
        private IPersonService _personService;

        [SetUp]
        public void Setup()
        {
            _personService = new PersonService(FakeDataContext.CreateContextWithTestData());
        }

        [Test]
        [TestCase("Marry Berry")]
        [TestCase("Dave Brown")]
        public void GetAll_ReturnName(string name)
        {
            var people = _personService.GetAll();

            var count = people.Count(x => x.Name == name);

            Assert.IsTrue(count == 1, $"Name is missing for list: {name}");
        }
    }
}
