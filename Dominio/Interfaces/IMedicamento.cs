using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMedicamento : IGenericRepo<Medicamento>
{
    Task<object> Consulta5A();
}
