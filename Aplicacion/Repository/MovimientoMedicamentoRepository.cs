using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MovimientoMedicamentoRepository : GenericRepo<MovimientoMedicamento>, IMovimientoMedicamento
{
    protected readonly ApiContext _context;
    
    public MovimientoMedicamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.MovimientoMedicamentos
            .Include(p => p.TipoMovimiento)
            .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.MovimientoMedicamentos
        .Include(p => p.TipoMovimiento)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 