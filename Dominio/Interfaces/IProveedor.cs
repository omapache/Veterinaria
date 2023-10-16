using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IProveedor : IGenericRepo<Proveedor>
{
    Task<object> Consulta4B();
}
