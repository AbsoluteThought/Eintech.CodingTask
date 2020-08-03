using Eintech.CodingTask.Infrastruture.Entities.Base;
using System;

namespace Eintech.CodingTask.Infrastruture.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
