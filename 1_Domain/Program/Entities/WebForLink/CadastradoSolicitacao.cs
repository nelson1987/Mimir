namespace Mimir.Domain.Entities.WebForLink
{
    public class CadastradoSolicitacao
    {
        public CadastradoSolicitacao(Solicitacao solicitacao)
        {
            Solicitacao = solicitacao;
        }

        public Solicitacao Solicitacao { get; private set; }
    }
}
