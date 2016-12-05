using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            EntidadeTeste entidadeTeste = new EntidadeTeste();
            Assert.AreEqual(true, true);
        }
    }
}
