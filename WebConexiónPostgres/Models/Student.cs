using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
        public bool sex { get; set; }
        public int IdUniversity { get; set; }
    }
}