using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ModelsProfessor
{
    public class Professor
    {
        [Key]
        public int IdProfessor { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string location { get; set; }
        public bool sex { get; set; }
        public string CI { get; set; }
        public int IdUniversity { get; set; }
    }
}