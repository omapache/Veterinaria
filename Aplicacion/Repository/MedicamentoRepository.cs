using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MedicamentoRepository : GenericRepo<Medicamento>, IMedicamento
{
    protected readonly ApiContext _context;
    
    public MedicamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .Include(p => p.Laboratorio)
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
        .Include(p => p.Laboratorio)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
} 