using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPropietario : IGenericRepo<Propietario>
{
    Task<object> Consulta4A();
    Task<object> Consulta5B();
}
