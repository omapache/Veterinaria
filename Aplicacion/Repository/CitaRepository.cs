using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class CitaRepository : GenericRepo<Cita>, ICita
{
    protected readonly ApiContext _context;
    
    public CitaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(p => p.Mascota)
            .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(p => p.Mascota)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

} 