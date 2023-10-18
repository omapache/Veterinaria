using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMedicamento : IGenericRepo<Medicamento>
{
    Task<object> Consulta5A();
    Task<(int totalRegistros, object registros)> Consulta5A(int pageIndez, int pageSize, string search);

}
