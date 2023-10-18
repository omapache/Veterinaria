using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMovimientoMedicamento : IGenericRepo<MovimientoMedicamento>
{
    Task<object> Consulta2B();
    Task<(int totalRegistros, object registros)> Consulta2B(int pageIndez, int pageSize, string search);

}
