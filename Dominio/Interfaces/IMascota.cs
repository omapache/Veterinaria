using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMascota : IGenericRepo<Mascota>
{
    Task<object> Consulta3A();
    Task<(int totalRegistros, object registros)> Consulta3A(int pageIndez, int pageSize, string search);
    Task<object> Consulta6A();
    Task<(int totalRegistros, object registros)> Consulta6A(int pageIndez, int pageSize, string search);
    Task<object> Consulta1B();
    Task<(int totalRegistros, object registros)> Consulta1B(int pageIndez, int pageSize, string search);
    Task<object> Consulta3B();
    Task<(int totalRegistros, object registros)> Consulta3B(int pageIndez, int pageSize, string search);
    Task<object> Consulta6B();
    Task<(int totalRegistros, object registros)> Consulta6B(int pageIndez, int pageSize, string search);
}