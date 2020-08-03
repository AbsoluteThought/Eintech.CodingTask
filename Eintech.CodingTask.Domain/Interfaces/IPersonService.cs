using Eintech.CodingTask.Domain.Models;
using System;
using System.Collections.Generic;

namespace Eintech.CodingTask.Domain.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetAll();
        void Add(string name);
    }
}
