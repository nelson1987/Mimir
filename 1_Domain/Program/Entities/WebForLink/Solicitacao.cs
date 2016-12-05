namespace Mimir.Domain.Entities.WebForLink
{
    public abstract class Solicitacao
    {
        public Solicitacao(Usuario usuario, Fornecedor fornecedor, int tipo)
        {
            Tipo = tipo;
            Solicitante = usuario;
            Solicitado = fornecedor;
        }

        public int Tipo { get; private set; }

        public Usuario Solicitante { get; private set; }

        public Fornecedor Solicitado { get; private set; }
    }

    public class SolicitacaoCriacaoFornecedor : Solicitacao
    {
        public SolicitacaoCriacaoFornecedor(Usuario usuario, Fornecedor fornecedor)
            : base(usuario, fornecedor, 1)
        {
        }
    }
}
