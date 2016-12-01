using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Filme
    {
        public Filme()
        {

        }

        public List<Ator> Atores { get; set; }

        public List<Serie> Series { get; set; }

        public Resenha Resenha { get; set; }
    }
}
