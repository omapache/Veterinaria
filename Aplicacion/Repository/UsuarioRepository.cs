using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class UsuarioRepository : GenericRepo<Usuario>, IUsuario
{
    private readonly ApiContext _context;

    public UsuarioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Usuarios
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Usuarios
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.Nombre.ToLower() == username.ToLower());
    }
    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
            .ToListAsync();
    }

    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}