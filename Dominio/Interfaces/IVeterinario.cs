using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IVeterinario : IGenericRepo<Veterinario>
{
    Task<object> Consulta1A();
    Task<(int totalRegistros, object registros)> Consulta1A(int pageIndez, int pageSize, string search);

}
