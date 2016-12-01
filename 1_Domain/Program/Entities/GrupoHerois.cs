using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class GrupoHerois
    {
        public GrupoHerois()
        {

        }

        public List<Heroi> ListaHerois { get; set; }

        public Resenha Resenha { get; set; }
    }
}
