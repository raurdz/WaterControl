using System;
using System.Collections.Generic;

namespace ControlClientes.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Actividades = new HashSet<Actividade>();
        }

        public long Id { get; set; }
        public string? NombreCliente { get; set; }
        public string HorasEstablecidas { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Actividade> Actividades { get; set; }
    }
}
