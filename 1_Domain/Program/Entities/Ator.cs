using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Ator
    {
        public Ator()
        {

        }
        public string Nome { get; private set; }

        public List<Serie> Series { get; private set; }

        public List<Filme> Filmes { get; private set; }
    }
}
