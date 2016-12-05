using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Noticia
    {
        public Noticia(string assunto)
        {
            Assunto = assunto;
        }

        public string Assunto { get; private set; }
        public List<Comentario> Comentarios { get; private set; }
    }
}
