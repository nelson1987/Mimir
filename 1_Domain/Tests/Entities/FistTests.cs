using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mimir.Domain.Test.Entities
{
    //    Lista de Caso de Uso - Mimir
    //Idéia, podemos visualizar a forma de exibir do Deezer

    //Atores: 
    //Administrador - Administradores do site
    //WikiAdmin - Administradores da Wiki
    //UsuariosPagantes - Usuário Wiki Pagantes
    //Usuarios - Usuário Wiki não Pagantes
    //Visualizadores - Usuários que só lerão as notícias e não terão acesso a wiki

    //- Criar Login Para Wiki e Fórum
    //- Assinar Lista de Email
    //- Criar notícia
    //- Adicionar Comentário
    //- Adicionar Filme
    //- Adicionar Quadrinhos/Grpahic Novel
    //- Adicionar Série
    //- Adicionar Herói(na)
    //- Adicionar Vilã(o)
    //- Adicionar Grupo
    //- Adicionar Ator(atriz)
    //- Adicionar Diretor(a)
    //- Adicionar Desenhista
    //- Adicionar Produtor(a)
    //- Adicionar Resenha
    //- Dar Nota
    //- Notificar Usuário de Resposta Fórum
    //- Realizar Sorteio
    //- Upload imagens

    //Repositórios:
    //. Entrar no site
    //. Realizar Login
    //. Visualizar Descontos
    //. Visualizar Notícias
    //. Visualizar Respostas Wiki
    //. Visualizar Filmes/Série/Herói/Vilão/Grupo/Quadrinhos/Grpahic Novel
    //. Relacionar Filmes/Série/Herói/Vilão/Grupo/Quadrinhos/Grpahic Novel
    [TestClass]
    public class FirstTests
    {
        [TestMethod]
        public void Validar_Primeiro_Teste()
        {
            //EntidadeTeste entidadeTeste = new EntidadeTeste();
            //Assert.AreEqual(true, true);
            //Leilão
            var davi = new Usuario("Davi");
            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(davi, 300.00));
            Assert.AreEqual(leilaoPlaystation.Lances.Count, 1);
        }
        [TestMethod]
        public void Validar_Segundo_Teste()
        {
            //Leilão
            var davi = new Usuario("Davi");
            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(davi, 300.00));
            leilaoPlaystation.ProporLance(new Lance(davi, 250.00));
            leilaoPlaystation.ProporLance(new Lance(davi, 200.00));
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avaliar(leilaoPlaystation);
            Assert.AreEqual(leiloeiro.MaiorLance, 300.00);
        }
        [TestMethod]
        public void Validar_Terceiro_Teste()
        {
            //EntidadeTeste entidadeTeste = new EntidadeTeste();
            //Assert.AreEqual(true, true);
            //Leilão
            var davi = new Usuario("Davi");
            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(davi, 200.00));
            leilaoPlaystation.ProporLance(new Lance(davi, 250.00));
            leilaoPlaystation.ProporLance(new Lance(davi, 300.00));
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avaliar(leilaoPlaystation);
            Assert.AreEqual(leiloeiro.MaiorLance, 300.00);
        }
        [TestMethod]
        public void Validar_Quarto_Teste()
        {
            //EntidadeTeste entidadeTeste = new EntidadeTeste();
            //Assert.AreEqual(true, true);
            //Leilão
            var davi = new Usuario("Davi");
            var bruno = new Usuario("Bruno");
            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(davi, 200.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 250.00));
            leilaoPlaystation.ProporLance(new Lance(davi, 300.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 350.00));
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avaliar(leilaoPlaystation);
            Assert.AreEqual(leiloeiro.MaiorLance, 350.00);
        }
        [TestMethod]
        public void Validar_UsuarioVencedorLeilaoCrescente_Teste()
        {
            var davi = new Usuario("Davi");
            var bruno = new Usuario("Bruno");
            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(davi, 200.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 250.00));
            leilaoPlaystation.ProporLance(new Lance(davi, 300.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 350.00));
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avaliar(leilaoPlaystation);
            Assert.AreEqual(leiloeiro.VencedorLance, bruno);
        }
        [TestMethod]
        public void Validar_UsuarioVencedorLeilaoInternet_Teste()
        {
            var joao = new Usuario("Joao");
            var bruno = new Usuario("Bruno");
            var lucas = new Usuario("Lucas");

            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(joao, 200.00));
            leilaoPlaystation.ProporLance(new Lance(joao, 400.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 250.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 325.00));
            leilaoPlaystation.ProporLance(new Lance(joao, 300.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 350.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 250.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 350.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 200.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 250.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 500.00));
            leilaoPlaystation.ProporLance(new Lance(joao, 150.00));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avaliar(leilaoPlaystation);
            Assert.AreEqual(leiloeiro.VencedorLance, lucas);
        }
        [TestMethod]
        public void Validar_UsuarioVencedorLeilaoInternetContador_Teste()
        {
            var joao = new Usuario("Joao");
            var bruno = new Usuario("Bruno");
            var lucas = new Usuario("Lucas");

            var leilaoPlaystation = new Leilao("Playstation");
            leilaoPlaystation.ProporLance(new Lance(joao, 200.00));
            leilaoPlaystation.ProporLance(new Lance(joao, 400.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 250.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 325.00));
            leilaoPlaystation.ProporLance(new Lance(joao, 300.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 350.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 250.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 350.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 200.00));
            leilaoPlaystation.ProporLance(new Lance(bruno, 250.00));
            leilaoPlaystation.ProporLance(new Lance(lucas, 500.00));
            leilaoPlaystation.ProporLance(new Lance(joao, 150.00));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avaliar(leilaoPlaystation);
            Assert.AreEqual(leilaoPlaystation.Lances.Count, 8);
        }

    }
    public class Usuario
    {
        public Usuario(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; private set; }
    }

    public class Lance
    {
        public Lance(Usuario usuario, double valor)
        {
            Valor = valor;
            Usuario = usuario;
        }
        public double Valor { get; private set; }
        public Usuario Usuario { get; private set; }
    }

    public class Leilao
    {
        public Leilao(string descricao)
        {
            Descricao = descricao;
            Lances = new List<Lance>();

        }
        public string Descricao { get; private set; }

        public List<Lance> Lances { get; private set; }

        public void ProporLance(Lance lance)
        {
            if (Lances.Any())
            {
                if (!Lances.Where(x => x.Valor == lance.Valor).Any())
                {
                    Lances.Add(lance);
                }
            }
            else
            {
                Lances.Add(lance);
            }
        }
    }
    public class Avaliador
    {
        private double MaiorDeTodos = double.MinValue;
        private Usuario Vencedor;

        public void Avaliar(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > MaiorDeTodos)
                {
                    MaiorDeTodos = lance.Valor;
                    Vencedor = lance.Usuario;
                }
            }
        }

        public double MaiorLance { get { return MaiorDeTodos; } }
        public Usuario VencedorLance { get { return Vencedor; } }
    }
}
