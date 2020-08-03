using Eintech.CodingTask.Domain.Interfaces;
using Eintech.CodingTask.Domain.Models;
using Eintech.CodingTask.Infrastruture.Data;
using Eintech.CodingTask.Infrastruture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eintech.CodingTask.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PersonModel> GetAll()
        {
            return _dbContext.Persons.Select(x => new PersonModel
            {
                Name = x.Name,
                CreatedDate = x.CreatedDate
            });
        }

        public void Add(string name)
        {
            _dbContext.Persons.Add(new Person
            {
                Name = name,
                CreatedDate = DateTime.Now
            });
            _dbContext.SaveChanges();
        }
    }       
}
