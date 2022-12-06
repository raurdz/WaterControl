using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace ControlClientes.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
        }
        [Required]
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Email { get; set; }
        public string? Clave { get; set; }
        public int IdRol { get; set; } = 3;

        public virtual Role? IdRolNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
