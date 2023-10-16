using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IVeterinario : IGenericRepo<Veterinario>
{
    Task<object> Consulta1A();
}
