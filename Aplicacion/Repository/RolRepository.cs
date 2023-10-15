using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class RolRepository : GenericRepo<Rol>, IRol
{
    private readonly ApiContext _context;

    public RolRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
}