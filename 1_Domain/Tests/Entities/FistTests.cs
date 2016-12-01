using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mimir.Domain.Test.Entities
{
    [TestClass]
    public class FirstTests
    {
        [TestMethod]
        public void Validar_Primeiro_Teste()
        {
            EntidadeTeste entidadeTeste = new EntidadeTeste();
            Assert.AreEqual(entidadeTeste, new EntidadeTeste());
        }
    }
}
