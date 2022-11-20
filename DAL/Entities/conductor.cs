using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.Entities
{
    public class conductor
    {
        
        [key]
        public int id { get; set; }
        public string identificacion { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        public bool activo { get; set; }

        public int matriculaId { get; set; }

        public virtual matricula matricula { get; set; }

        public virtual ICollection<sanciones> sanciones { get; set; }

    }
}
