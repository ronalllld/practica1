using System.ComponentModel.DataAnnotations;
using BDuniversidad.context;
using BDuniversidad.models;

public class Estudiante
    {
        [Key]
        public long IdEstudiante { get; set; }

       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public bool Sexo { get; set; }
        public long IdUniversidad { get; set; }
        public Universidad Universidad { get; set; }
    

}
