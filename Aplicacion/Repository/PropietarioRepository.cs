using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PropietarioRepository : GenericRepo<Propietario>, IPropietario
{
    protected readonly ApiContext _context;

    public PropietarioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
            .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Propietarios as IQueryable<Propietario>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> Consulta4A()
    {
        var consulta = from p in _context.Propietarios
        select new
        {
            Nombre = p.Nombre,
            Email = p.Email,
            Telefono = p.Telefono,
            Mascotas = (from m in _context.Mascotas
                        where m.IdPropietarioFk == p.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento
                        }).ToList()
        };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }
    public async Task<object> Consulta5B()
    {
        var consulta = from p in _context.Propietarios
        select new
        {
            Nombre = p.Nombre,
            Email = p.Email,
            Telefono = p.Telefono,
            Mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.IdRazaFk equals r.Id
                        where r.Nombre == "Golden Retriver"
                        where m.IdPropietarioFk == p.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                            Raza = r.Nombre
                        }).ToList()
        };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }
}