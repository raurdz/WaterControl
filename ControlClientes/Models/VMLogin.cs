using Microsoft.Build.Framework;

namespace ControlClientes.Models
{
    public class VMLogin
    {
        [Required]
        public string User { get; set; }
        public string PassWord { get; set; }
        public bool KeepLoggedIn { get; set; } 
    }
}
