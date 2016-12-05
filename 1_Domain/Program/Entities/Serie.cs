using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Serie
    {
        public Serie(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public List<Ator> Atores { get; private set; }

        public Resenha Resenha { get; private set; }
    }
}
