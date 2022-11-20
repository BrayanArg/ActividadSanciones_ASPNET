using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.DTOs
{
    public class sancionesDTO
    {
        public int id { get; set; }

        public DateTime fecha_actual { get; set; }

        public int conductorId { get; set; }

        public string nombreConductor { get; set; }

        public string apellidosConductor { get; set; }

        public string sancion { get; set; }

        public decimal valor { get; set; }
    }
}
