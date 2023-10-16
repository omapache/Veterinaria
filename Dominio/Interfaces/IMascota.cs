using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMascota : IGenericRepo<Mascota>
{
    Task<object> Consulta3A();
    Task<object> Consulta6A();
}