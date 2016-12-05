namespace Mimir.Domain.Entities
{
    public class Comentario
    {
        public Comentario(Usuario autor, string texto)
        {
            Autor = autor;
            Texto = texto;
        }

        public Usuario Autor { get; private set; }

        public string Texto { get; private set; }
    }
}
