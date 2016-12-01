using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Serie
    {
        public Serie()
        {

        }

        public List<Ator> Atores { get; set; }

        public Resenha Resenha { get; set; }
    }
}
