using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimir.Domain.Entities
{
    public class Passo
    {
        public Passo(int id, string descricao)
        {
            Descricao = descricao;
            Aprovado = false;
            ProximoPasso = new List<Passo>();
            PassoAnterior = new List<Passo>();
            Id = id;
        }

        public int Id { get; private set; }

        public string Descricao { get; private set; }

        public bool Aprovado { get; private set; }

        public List<Passo> PassoAnterior { get; private set; }

        public List<Passo> ProximoPasso { get; private set; }

        public void AdicionarPassoAnterior(List<Passo> passoAnterior)
        {
            PassoAnterior.AddRange(passoAnterior);
        }
        public void AdicionarPassoAnterior(Passo passoAnterior)
        {
            PassoAnterior.Add(passoAnterior);
        }

        public void AdicionarProximoPasso(List<Passo> proximoPasso)
        {
            ProximoPasso.AddRange(proximoPasso);
        }

        public void AdicionarProximoPasso(Passo proximoPasso)
        {
            ProximoPasso.Add(proximoPasso);
        }

        public void Aprovar()
        {
            Aprovado = true;
        }
    }
}
