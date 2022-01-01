using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Country: BaseEntity
    {
        public int id { get; set; }

        public string? name { get; set; }
    }
}