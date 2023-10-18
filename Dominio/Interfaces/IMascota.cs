using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMascota : IGenericRepo<Mascota>
{
    Task<object> Consulta3A();
    abstract Task<(int totalRegistros, object registros)> Consulta3A(int pageIndez, int pageSize, string search);
    Task<object> Consulta6A();
    abstract Task<(int totalRegistros, object registros)> Consulta6A(int pageIndez, int pageSize, string search);
    Task<object> Consulta1B();
    Task<object> Consulta3B();
    abstract Task<object> Consulta6B();
    abstract Task<(int totalRegistros, object registros)> Consulta6B(int pageIndez, int pageSize, string search);
}