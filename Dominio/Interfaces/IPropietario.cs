using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPropietario : IGenericRepo<Propietario>
{
    Task<object> Consulta4A();
    Task<(int totalRegistros, object registros)> Consulta4A(int pageIndez, int pageSize, string search);
    Task<object> Consulta5B();
    Task<(int totalRegistros, object registros)> Consulta5B(int pageIndez, int pageSize, string search);

}
