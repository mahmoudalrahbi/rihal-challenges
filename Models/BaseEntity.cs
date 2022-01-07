using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace School.Models
{
    public class BaseEntity
    {
        [Display(Name = "Created Date")]
        public DateTime created_date { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime modified_date  { get; set; }
    }
}