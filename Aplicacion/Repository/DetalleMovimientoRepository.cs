using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class DetalleMovimientoRepository : GenericRepo<DetalleMovimiento>, IDetalleMovimiento
{
    protected readonly ApiContext _context;
    
    public DetalleMovimientoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _context.DetalleMovimientos
            .Include(p => p.MovimientoMedicamento)
            .Include(p => p.Medicamento)
            .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id)
    {
        return await _context.DetalleMovimientos
            .Include(p => p.MovimientoMedicamento)
            .Include(p => p.Medicamento)        
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 