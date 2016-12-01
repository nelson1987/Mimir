using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Vilao
    {
        public Vilao()
        {

        }

        public List<Heroi> ArquiRivais { get; set; }

        public Resenha Resenha { get; set; }
    }
}
