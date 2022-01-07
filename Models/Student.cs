using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Student: BaseEntity
    {
        public int id { get; set; }

       [Display(Name = "Name")]
        public string? name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Birth Date")]
        public DateTime date_of_birth { get; set; }

        [Column("class_id")]
        [Display(Name = "Class")]
        public int ClassesId { get; set; }

        [Display(Name = "Class")]
        public Class? Classes { get; set; }

        [Column("country_id")]
        [Display(Name = "Country")]
        public int CountriesId { get; set; }

        [Display(Name = "Country")]
        public Country? Countries { get; set; }
    }
}