namespace Mimir.Domain.Entities.WebForLink
{
    public class Usuario
    {
        public Usuario(string login, Contratante contratante)
        {
            Login = login;
            Contratante = contratante;
        }
        
        public string Login { get; private set; }

        public Contratante Contratante { get; private set; }
    }
}