namespace Mimir.Domain.Entities
{
    public class Resenha
    {
        public Resenha(Usuario autor, string texto)
        {
            Autor = autor;
            Texto = texto;
        }

        public string Texto { get;  private set; }

        public Usuario Autor { get; private set; }
    }
}
