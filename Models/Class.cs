using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Class: BaseEntity
    {
        public int id { get; set; }

        [Display(Name = "Class Name")]
        public string? class_name { get; set; }
    }
}