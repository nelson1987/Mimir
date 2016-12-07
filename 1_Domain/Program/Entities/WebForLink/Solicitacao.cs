using Mimir.Domain.Entities.Emuns;
using System.Linq;

namespace Mimir.Domain.Entities.WebForLink
{
    public abstract class Solicitacao
    {
        public Solicitacao(Usuario usuario, Fornecedor fornecedor, int tipo)
        {
            Tipo = tipo;
            Solicitante = usuario;
            Solicitado = fornecedor;
            Status = StatusSolicitacao.None;
        }

        public int Tipo { get; private set; }

        public Usuario Solicitante { get; private set; }

        public Fornecedor Solicitado { get; private set; }

        public StatusSolicitacao Status { get; private set; }

        public Fluxo Fluxo { get; private set; }

        public void IncluirFluxo(Fluxo fluxo)
        {
            Fluxo = fluxo;
            Status = StatusSolicitacao.Aguardando;
        }
        abstract public void ConcluirTramiteAtual();
        public void ConcluirSolicitacao()
        {
            Status = StatusSolicitacao.Concluido;
        }
        public Tramite TramiteAtual {
            get {
                return Fluxo.Tramites.FirstOrDefault(x => x.Aguardando);
            }
        }
    }

    public class SolicitacaoCriacaoFornecedor : Solicitacao
    {
        public SolicitacaoCriacaoFornecedor(Usuario usuario, Fornecedor fornecedor)
            : base(usuario, fornecedor, 1)
        {

        }
        public override void ConcluirTramiteAtual()
        {
            if (Fluxo.Tramites.Any())
            {
                Fluxo.Tramites.FirstOrDefault(x => x.Aguardando).ConcluirTramite();
            }
            if (TramiteAtual == null)
                ConcluirSolicitacao();
        }
    }
}
