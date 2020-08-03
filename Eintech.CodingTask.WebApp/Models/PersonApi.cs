using System.ComponentModel.DataAnnotations;

namespace Eintech.CodingTask.WebApp.Models
{
    public class PersonApi
    {
        [Required]
        public string Name { get; set; }
    }
}
