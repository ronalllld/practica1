using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsUniversities
{
    public class University
    {
        [Key]
        public int IdUniversity { get; set; }
        public string name { get; set; }
    }
}