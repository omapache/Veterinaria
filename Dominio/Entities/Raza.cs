namespace Dominio.Entities;
public class Raza : BaseEntity
{
    
    public int IdEspecieFk { get; set; }
    public Especie Especie { get; set; }
    public string Nombre { get; set; }
    public virtual Mascota Mascota { get; set; }
}
