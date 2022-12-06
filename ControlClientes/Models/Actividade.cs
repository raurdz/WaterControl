using System;
using System.Collections.Generic;

namespace ControlClientes.Models
{
    public partial class Actividade
    {
        public Actividade()
        {
            Trabajos = new HashSet<Trabajo>();
        }

        public long Id { get; set; }
        public string? NombreActividad { get; set; }
        public string? CostoPorHora { get; set; }
        public long? IdCliente { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }
}
