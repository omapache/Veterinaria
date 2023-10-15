using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TratamientoMedicoRepository  : GenericRepo<TratamientoMedico>, ITratamientoMedico
{
    protected readonly ApiContext _context;
    
    public TratamientoMedicoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TratamientoMedico>> GetAllAsync()
    {
        return await _context.TratamientoMedicos
            .Include(p => p.Cita)
            .Include(p => p.Medicamento)
            .ToListAsync();
    }

    public override async Task<TratamientoMedico> GetByIdAsync(int id)
    {
        return await _context.TratamientoMedicos
        .Include(p => p.Cita)
        .Include(p => p.Medicamento)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 