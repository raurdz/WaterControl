using Microsoft.EntityFrameworkCore;
using ControlClientes.Models;
using ControlClientes.Services.Contrato;

namespace ControlClientes.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CHPMWebContext _dbContext;
        public UsuarioService(CHPMWebContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string email, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Email == email && u.Clave == clave)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo) 
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
