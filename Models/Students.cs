using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Students
    {
        public int id { get; set; }
        public string? name { get; set; }

        [DataType(DataType.Date)]
        public DateOnly date_of_birth { get; set; }

        [Column("class_id")]
        public int ClassesId { get; set; }
        public Classes? Classes { get; set; }

        [Column("country_id")]
        public int CountriesId { get; set; }
        public Countries? Countries { get; set; }
    }
}