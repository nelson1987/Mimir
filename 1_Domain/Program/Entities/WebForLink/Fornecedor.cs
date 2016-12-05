using System.Collections.Generic;

namespace Mimir.Domain.Entities.WebForLink
{
    public class Fornecedor
    {
        public Fornecedor(string documento)
        {

        }

        public List<Solicitacao> Solicitacoes { get; set; }
    }
}
