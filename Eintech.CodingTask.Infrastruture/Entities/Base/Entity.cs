using System.ComponentModel.DataAnnotations;

namespace Eintech.CodingTask.Infrastruture.Entities.Base
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
