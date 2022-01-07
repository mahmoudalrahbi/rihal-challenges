using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Country: BaseEntity
    {
        public int id { get; set; }

        [Display(Name = "Country Name")]
        public string? name { get; set; }
    }
}