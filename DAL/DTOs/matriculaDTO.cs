using ActividadSanciones_ASPNET.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadSanciones_ASPNET.DAL.DTOs
{
    public class matriculaDTO
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        public string numero{ get; set; }

        public DateTime fecha_expedicion { get; set; }

        public DateTime fechaValida_hasta { get; set; }

        public bool activo { get; set; }

    }
}
