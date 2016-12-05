namespace Mimir.Domain.Entities.WebForLink
{
    public class Usuario
    {
        public Usuario(string login)
        {
            Login = login;
        }
        
        public string Login { get; private set; }
    }
}