using Eintech.CodingTask.Infrastruture.Data;
using Eintech.CodingTask.Infrastruture.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eintech.CodingTask.Test.Helpers
{
    public static class FakeDataContext
    {
        internal static ApplicationDbContext CreateContextWithTestData()
        {
            var persons = new List<Person>
            {
                new Person { Id = 1, Name = "Marry Berry", CreatedDate = new DateTime(2020, 08, 02) },
                new Person { Id = 2, Name = "Dave Brown", CreatedDate = new DateTime(2020, 08, 03) }
            };

            var mockPersons = CreateDbSetMock(persons);

            var mockContext = new Mock<ApplicationDbContext>();

            mockContext.Setup(x => x.Set<Person>()).Returns(() => mockPersons.Object);

            return mockContext.Object;
        }

        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
