using System.Collections.Generic;

namespace Mimir.Domain.Entities.WebForLink
{
    public class Fornecedor
    {
        public Fornecedor(string documento)
        {
            Documento = documento;
        }

        public string Documento { get; set; }
        public List<Solicitacao> Solicitacoes { get; set; }
    }
}
