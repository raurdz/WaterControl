using Microsoft.EntityFrameworkCore;
using ControlClientes.Models;

namespace ControlClientes.Services.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string email, string clave);

        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
