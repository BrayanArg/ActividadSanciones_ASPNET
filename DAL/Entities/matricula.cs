

namespace ActividadSanciones_ASPNET.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class matricula
    {
        
        [key]
        public int id { get; set; }

        public string numero { get; set; }

        public DateTime fecha_expedicion { get; set; }

        public DateTime fechaValida_hasta { get; set; }

        public bool activo { get; set; }

        public virtual ICollection<conductor>conductor{ get; set; }
    }
}
