using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IProveedor : IGenericRepo<Proveedor>
{
    Task<object> Consulta4B();
    Task<(int totalRegistros, object registros)> Consulta4B(int pageIndez, int pageSize, string search);

}
