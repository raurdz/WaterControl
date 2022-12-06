using System;
using System.Collections.Generic;

namespace ControlClientes.Models
{
    public partial class Trabajo
    {
        public long Id { get; set; }
        public string? NombreTrabajo { get; set; }
        public long? IdActividad { get; set; }
        public long? IdEntregable { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Actividade? IdActividadNavigation { get; set; }
        public virtual Entregable? IdEntregableNavigation { get; set; }
    }
}
