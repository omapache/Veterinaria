namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        Administrator,
        Personal,
        Medico,
    }
    public const Roles rol_default = Roles.Personal;
}
