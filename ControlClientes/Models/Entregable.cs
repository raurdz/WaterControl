using System;
using System.Collections.Generic;

namespace ControlClientes.Models
{
    public partial class Entregable
    {
        public Entregable()
        {
            Trabajos = new HashSet<Trabajo>();
        }

        public long Id { get; set; }
        public string? NombreEntregable { get; set; }
        public string? CostoTotal { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }
}
