using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class EspecieRepository  : GenericRepo<Especie>, IEspecie
{
    protected readonly ApiContext _context;
    
    public EspecieRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Especie>> GetAllAsync()
    {
        return await _context.Especies
            .ToListAsync();
    }

    public override async Task<Especie> GetByIdAsync(int id)
    {
        return await _context.Especies
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 