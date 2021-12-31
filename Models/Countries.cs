using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Countries: BaseEntity
    {
        public int id { get; set; }

        public string? name { get; set; }
    }
}