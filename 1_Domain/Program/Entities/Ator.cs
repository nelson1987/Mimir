using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Ator
    {
        public Ator()
        {

        }

        public List<Serie> Series { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}
