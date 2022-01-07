using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Student: BaseEntity
    {
        public int id { get; set; }
        public string? name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime date_of_birth { get; set; }

        [Column("class_id")]
        public int ClassesId { get; set; }
        public Class? Classes { get; set; }

        [Column("country_id")]
        public int CountriesId { get; set; }
        public Country? Countries { get; set; }
    }
}