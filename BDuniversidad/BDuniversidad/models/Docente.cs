using System.ComponentModel.DataAnnotations;
using BDuniversidad.context;
using BDuniversidad.models;

using System.ComponentModel.DataAnnotations;

    public class Docente
    {
        [Key]
        public int IdDocente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ubicacion { get; set; }
        public bool Sexo { get; set; }
        public int CI { get; set; }
        public int IdUniversidad { get; set; }

        public Universidad Universidad { get; set; }
    

}
