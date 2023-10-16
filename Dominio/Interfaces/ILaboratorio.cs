using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ILaboratorio : IGenericRepo<Laboratorio>
{
    Task<object> Consulta2A();
}
