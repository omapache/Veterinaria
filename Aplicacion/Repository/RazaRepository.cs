using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class RazaRepository : GenericRepo<Raza>, IRaza
{
    protected readonly ApiContext _context;
    
    public RazaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Razas
            .Include(p => p.Especie)
            .ToListAsync();
    }

    public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Razas
        .Include(p => p.Especie)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 