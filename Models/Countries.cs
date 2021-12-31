using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Countries
    {
        public Countries(int id, string name)
        {
            this.id = id;
            this.name = name;

        }
        public int id { get; set; }

        public string name { get; set; }
    }
}