using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MascotaRepository : GenericRepo<Mascota>, IMascota
{
    protected readonly ApiContext _context;
    
    public MascotaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
            .Include(p => p.Propietario)
            .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
        .Include(p => p.Propietario)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 