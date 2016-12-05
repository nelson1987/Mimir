using System.Collections.Generic;

namespace Mimir.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome)
        {
            Nome = nome;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public List<Comentario> Comentarios { get; private set; }
    }
}
