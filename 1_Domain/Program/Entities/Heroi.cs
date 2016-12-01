using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Heroi
    {
        public Heroi()
        {

        }

        public List<Vilao> ArquiViloes { get; set; }

        public Resenha Resenha { get; set; }
    }
}
