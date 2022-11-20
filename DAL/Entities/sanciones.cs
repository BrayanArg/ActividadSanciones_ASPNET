using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.Entities
{
    public class sanciones
    {
        [key]
        public int id { get; set; }

        public DateTime fecha_actual { get; set; }

        public int conductorId { get; set; }

        public string sancion { get; set; }

        public string observacion { get; set; }

        public decimal valor { get; set; }

        public virtual conductor conductor { get; set; }
    }
}
