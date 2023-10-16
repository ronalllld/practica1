using System.ComponentModel.DataAnnotations;
using BDuniversidad.context;

namespace BDuniversidad.models
{
    using System.ComponentModel.DataAnnotations;

    public class Universidad
    {
        [Key]
        public long IdUniversidad { get; set; }
        public string Nombre { get; set; }
    }

}
