using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ILaboratorio : IGenericRepo<Laboratorio>
{
    Task<object> Consulta2A();
    Task<(int totalRegistros, object registros)> Consulta2A(int pageIndez, int pageSize, string search);
}
