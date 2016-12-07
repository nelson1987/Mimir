using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimir.Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Mimir.Domain.Tests.Entities
{
    [TestClass]
    public class WorkFlowTests
    {
        Passo passoA;
        Passo passoB;
        Passo passoC;
        Passo passoD;
        Passo passoE;
        Passo passoF;
        Passo passoG;
        Passo passoH;
        Passo passoI;
        Passo passoJ;

        [TestInitialize]
        public void SetUp()
        {
            passoA = new Passo(1, "PassoA");
            passoB = new Passo(2, "PassoB");
            passoC = new Passo(3, "PassoC");
            passoD = new Passo(4, "PassoD");
            passoE = new Passo(5, "PassoE");
            passoF = new Passo(6, "PassoF");
            passoG = new Passo(7, "PassoG");
            passoH = new Passo(8, "PassoH");
            passoI = new Passo(9, "PassoI");
            passoJ = new Passo(10, "PassoJ");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Passo primeiroPasso = new Passo(1, "PassoA");
            Passo segundoPasso = new Passo(2, "PassoB");
            Passo terceiroPasso = new Passo(3, "PassoC");
            //A
            primeiroPasso.AdicionarProximoPasso(segundoPasso);
            //B
            segundoPasso.AdicionarPassoAnterior(primeiroPasso);
            segundoPasso.AdicionarProximoPasso(terceiroPasso);
            //C
            terceiroPasso.AdicionarPassoAnterior(segundoPasso);

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { primeiroPasso });
            fluxo.AdicionarPasso(new List<Passo> { segundoPasso });
            fluxo.AdicionarPasso(new List<Passo> { terceiroPasso });

            Assert.AreEqual(fluxo.PassoAtual.Descricao, primeiroPasso.Descricao);
            Assert.AreEqual(fluxo.PassoAtual.Aprovado, false);

            fluxo.AprovarPassoAtual();

            Assert.AreEqual(fluxo.PassoAtual.Descricao, segundoPasso.Descricao);
            Assert.AreEqual(fluxo.PassoAtual.Aprovado, false);
        }

        [TestMethod]
        public void Com5Passos()
        {
            Passo primeiroPasso = new Passo(1, "PassoA");
            Passo segundoPasso = new Passo(2, "PassoB");
            Passo terceiroPasso = new Passo(3, "PassoC");
            Passo quartoPasso = new Passo(4, "PassoD");
            Passo quintoPasso = new Passo(5, "PassoE");
            //Passo1
            primeiroPasso.AdicionarProximoPasso(segundoPasso);
            //Passo2
            segundoPasso.AdicionarPassoAnterior(primeiroPasso);
            segundoPasso.AdicionarProximoPasso(terceiroPasso);
            //Passo3
            terceiroPasso.AdicionarPassoAnterior(segundoPasso);
            terceiroPasso.AdicionarProximoPasso(quartoPasso);
            //Passo4
            quartoPasso.AdicionarPassoAnterior(terceiroPasso);
            quartoPasso.AdicionarProximoPasso(quintoPasso);
            //Passo5
            quintoPasso.AdicionarPassoAnterior(terceiroPasso);

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { primeiroPasso });
            fluxo.AdicionarPasso(new List<Passo> { segundoPasso });
            fluxo.AdicionarPasso(new List<Passo> { terceiroPasso });
            fluxo.AdicionarPasso(new List<Passo> { quartoPasso });
            fluxo.AdicionarPasso(new List<Passo> { quintoPasso });
            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, primeiroPasso.Descricao);
            fluxo.AprovarPassoAtual(primeiroPasso);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, segundoPasso.Descricao);
            fluxo.AprovarPassoAtual(segundoPasso);
            //Aprovar P3
            Assert.AreEqual(fluxo.PassoAtual.Descricao, terceiroPasso.Descricao);
            fluxo.AprovarPassoAtual(terceiroPasso);
            //Aprovar P4
            Assert.AreEqual(fluxo.PassoAtual.Descricao, quartoPasso.Descricao);
            fluxo.AprovarPassoAtual(quartoPasso);
            //Aprovar P5
            Assert.AreEqual(fluxo.PassoAtual.Descricao, quintoPasso.Descricao);
            fluxo.AprovarPassoAtual(quintoPasso);
            Assert.IsTrue(fluxo.Concluido);
        }

        [TestMethod]
        public void Com5PassosDuplos()
        {
            Passo primeiroPasso = new Passo(1, "PassoA");
            Passo segundoPasso = new Passo(2, "PassoB");
            Passo terceiroPasso = new Passo(3, "PassoC");
            Passo quartoPasso = new Passo(4, "PassoD");
            Passo quintoPasso = new Passo(5, "PassoE");
            //PassoA
            primeiroPasso.AdicionarProximoPasso(segundoPasso);
            primeiroPasso.AdicionarProximoPasso(terceiroPasso);
            //PassoB
            segundoPasso.AdicionarPassoAnterior(primeiroPasso);
            segundoPasso.AdicionarProximoPasso(quartoPasso);
            //PassoC
            terceiroPasso.AdicionarPassoAnterior(primeiroPasso);
            terceiroPasso.AdicionarProximoPasso(quartoPasso);
            //PassoD
            quartoPasso.AdicionarPassoAnterior(segundoPasso);
            quartoPasso.AdicionarPassoAnterior(terceiroPasso);
            quartoPasso.AdicionarProximoPasso(quintoPasso);
            //PassoE
            quintoPasso.AdicionarPassoAnterior(quartoPasso);

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { primeiroPasso });
            fluxo.AdicionarPasso(new List<Passo> { segundoPasso, terceiroPasso });
            fluxo.AdicionarPasso(new List<Passo> { quartoPasso });
            fluxo.AdicionarPasso(new List<Passo> { quintoPasso });

            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, primeiroPasso.Descricao);
            fluxo.AprovarPassoAtual(primeiroPasso);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, segundoPasso.Descricao);
            fluxo.AprovarPassoAtual(segundoPasso);
            //Aprovar P3
            Assert.AreEqual(fluxo.PassoAtual.Descricao, terceiroPasso.Descricao);
            fluxo.AprovarPassoAtual(terceiroPasso);
            //Aprovar P4
            Assert.AreEqual(fluxo.PassoAtual.Descricao, quartoPasso.Descricao);
            fluxo.AprovarPassoAtual(quartoPasso);
            //Aprovar P5
            Assert.AreEqual(fluxo.PassoAtual.Descricao, quintoPasso.Descricao);
            fluxo.AprovarPassoAtual(quintoPasso);
            Assert.IsTrue(fluxo.Concluido);
        }
        [TestMethod]
        public void Com5PassosTriplo()
        {
            Passo passoA = new Passo(1, "PassoA");
            Passo passoB = new Passo(2, "PassoB");
            Passo passoC = new Passo(3, "PassoC");
            Passo passoD = new Passo(4, "PassoD");
            Passo passoE = new Passo(5, "PassoE");
            Passo passoF = new Passo(6, "PassoF");
            //PassoA
            passoA.AdicionarProximoPasso(passoB);
            passoA.AdicionarProximoPasso(passoC);
            //PassoB
            passoB.AdicionarProximoPasso(passoD);
            passoB.AdicionarProximoPasso(passoE);
            //PassoC
            passoC.AdicionarProximoPasso(passoE);
            //PassoD
            passoD.AdicionarProximoPasso(passoF);
            //PassoE
            passoE.AdicionarProximoPasso(passoF);
            //PassoB
            passoB.AdicionarPassoAnterior(passoA);
            //PassoC
            passoC.AdicionarPassoAnterior(passoA);
            //PassoD
            passoD.AdicionarPassoAnterior(passoB);
            //PassoE
            passoE.AdicionarPassoAnterior(passoB);
            passoE.AdicionarPassoAnterior(passoD);
            //Passo F
            passoE.AdicionarPassoAnterior(passoB);
            passoE.AdicionarPassoAnterior(passoD);

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { passoA });
            fluxo.AdicionarPasso(new List<Passo> { passoB, passoC });
            fluxo.AdicionarPasso(new List<Passo> { passoD, passoE });
            fluxo.AdicionarPasso(new List<Passo> { passoF });

            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoA.Descricao);
            fluxo.AprovarPassoAtual(passoA);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoB.Descricao);
            fluxo.AprovarPassoAtual(passoB);
            //Aprovar P3
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoC.Descricao);
            fluxo.AprovarPassoAtual(passoC);
            //Aprovar P4
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoD.Descricao);
            fluxo.AprovarPassoAtual(passoD);
            //Aprovar P5
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoE.Descricao);
            fluxo.AprovarPassoAtual(passoE);
            //Aprovar P6
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoF.Descricao);
            fluxo.AprovarPassoAtual(passoF);

            Assert.IsTrue(fluxo.Concluido);
        }

        [TestMethod]
        public void PassosCruzados()
        {
            passoA.AdicionarProximoPasso(new List<Passo> { passoB, passoC, passoD });
            passoB.AdicionarProximoPasso(new List<Passo> { passoE, passoG });
            passoC.AdicionarProximoPasso(new List<Passo> { passoE, passoF });
            passoD.AdicionarProximoPasso(new List<Passo> { passoE, passoF, passoG });
            passoE.AdicionarProximoPasso(new List<Passo> { passoH, passoI });
            passoF.AdicionarProximoPasso(new List<Passo> { passoI });
            passoG.AdicionarProximoPasso(new List<Passo> { passoH, passoI });
            passoH.AdicionarProximoPasso(new List<Passo> { passoJ });
            passoI.AdicionarProximoPasso(new List<Passo> { passoJ });

            passoB.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoC.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoD.AdicionarPassoAnterior(new List<Passo> { passoB });

            passoE.AdicionarPassoAnterior(new List<Passo> { passoB, passoC, passoD });
            passoF.AdicionarPassoAnterior(new List<Passo> { passoC, passoD });
            passoG.AdicionarPassoAnterior(new List<Passo> { passoB, passoD });

            passoH.AdicionarPassoAnterior(new List<Passo> { passoE, passoG });
            passoI.AdicionarPassoAnterior(new List<Passo> { passoE, passoF, passoG });

            passoJ.AdicionarPassoAnterior(new List<Passo> { passoH, passoI });

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { passoA });
            fluxo.AdicionarPasso(new List<Passo> { passoB, passoC, passoD });
            fluxo.AdicionarPasso(new List<Passo> { passoE, passoF, passoG });
            fluxo.AdicionarPasso(new List<Passo> { passoH, passoI });
            fluxo.AdicionarPasso(new List<Passo> { passoJ });

            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoA.Descricao);
            fluxo.AprovarPassoAtual(passoA);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoB.Descricao);
            fluxo.AprovarPassoAtual(passoB);
            //Aprovar P3
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoC.Descricao);
            fluxo.AprovarPassoAtual(passoC);
            //Aprovar P4
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoD.Descricao);
            fluxo.AprovarPassoAtual(passoD);
            //Aprovar P5
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoE.Descricao);
            fluxo.AprovarPassoAtual(passoE);
            //Aprovar P6
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoF.Descricao);
            fluxo.AprovarPassoAtual(passoF);
            //Aprovar P6
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoG.Descricao);
            fluxo.AprovarPassoAtual(passoG);
            //Aprovar P6
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoH.Descricao);
            fluxo.AprovarPassoAtual(passoH);
            //Aprovar P6
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoI.Descricao);
            fluxo.AprovarPassoAtual(passoI);
            //Aprovar P6
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoJ.Descricao);
            fluxo.AprovarPassoAtual(passoJ);

            Assert.IsTrue(fluxo.Concluido);
        }

        [TestMethod]
        [ExpectedException(typeof(AprovacaoException))]
        public void PassosCruzadosAprovacaoDePassoJaAprovado()
        {
            #region ProximosPassos
            passoA.AdicionarProximoPasso(new List<Passo> { passoB, passoC, passoD });
            passoB.AdicionarProximoPasso(new List<Passo> { passoE, passoG });
            passoC.AdicionarProximoPasso(new List<Passo> { passoE, passoF });
            passoD.AdicionarProximoPasso(new List<Passo> { passoE, passoF, passoG });
            passoE.AdicionarProximoPasso(new List<Passo> { passoH, passoI });
            passoF.AdicionarProximoPasso(new List<Passo> { passoI });
            passoG.AdicionarProximoPasso(new List<Passo> { passoH, passoI });
            passoH.AdicionarProximoPasso(new List<Passo> { passoJ });
            passoI.AdicionarProximoPasso(new List<Passo> { passoJ });
            #endregion

            #region PassosAnteriores
            passoB.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoC.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoD.AdicionarPassoAnterior(new List<Passo> { passoB });

            passoE.AdicionarPassoAnterior(new List<Passo> { passoB, passoC, passoD });
            passoF.AdicionarPassoAnterior(new List<Passo> { passoC, passoD });
            passoG.AdicionarPassoAnterior(new List<Passo> { passoB, passoD });

            passoH.AdicionarPassoAnterior(new List<Passo> { passoE, passoG });
            passoI.AdicionarPassoAnterior(new List<Passo> { passoE, passoF, passoG });

            passoJ.AdicionarPassoAnterior(new List<Passo> { passoH, passoI });
            #endregion

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { passoA });
            fluxo.AdicionarPasso(new List<Passo> { passoB, passoC, passoD });
            fluxo.AdicionarPasso(new List<Passo> { passoE, passoF, passoG });
            fluxo.AdicionarPasso(new List<Passo> { passoH, passoI });
            fluxo.AdicionarPasso(new List<Passo> { passoJ });

            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoA.Descricao);
            fluxo.AprovarPassoAtual(passoA);
            fluxo.AprovarPassoAtual(passoC);
            fluxo.AprovarPassoAtual(passoB);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoD.Descricao);
            fluxo.AprovarPassoAtual(passoB);
        }

        [TestMethod]
        public void PassosCruzadosAprovacaoAleatoria()
        {
            #region ProximosPassos
            passoA.AdicionarProximoPasso(new List<Passo> { passoB, passoC, passoD });
            passoB.AdicionarProximoPasso(new List<Passo> { passoE, passoG });
            passoC.AdicionarProximoPasso(new List<Passo> { passoE, passoF });
            passoD.AdicionarProximoPasso(new List<Passo> { passoE, passoF, passoG });
            passoE.AdicionarProximoPasso(new List<Passo> { passoH, passoI });
            passoF.AdicionarProximoPasso(new List<Passo> { passoI });
            passoG.AdicionarProximoPasso(new List<Passo> { passoH, passoI });
            passoH.AdicionarProximoPasso(new List<Passo> { passoJ });
            passoI.AdicionarProximoPasso(new List<Passo> { passoJ });
            #endregion

            #region PassosAnteriores
            passoB.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoC.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoD.AdicionarPassoAnterior(new List<Passo> { passoB });

            passoE.AdicionarPassoAnterior(new List<Passo> { passoB, passoC, passoD });
            passoF.AdicionarPassoAnterior(new List<Passo> { passoC, passoD });
            passoG.AdicionarPassoAnterior(new List<Passo> { passoB, passoD });

            passoH.AdicionarPassoAnterior(new List<Passo> { passoE, passoG });
            passoI.AdicionarPassoAnterior(new List<Passo> { passoE, passoF, passoG });

            passoJ.AdicionarPassoAnterior(new List<Passo> { passoH, passoI });
            #endregion

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { passoA });
            fluxo.AdicionarPasso(new List<Passo> { passoB, passoC, passoD });
            fluxo.AdicionarPasso(new List<Passo> { passoE, passoF, passoG });
            fluxo.AdicionarPasso(new List<Passo> { passoH, passoI });
            fluxo.AdicionarPasso(new List<Passo> { passoJ });

            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoA.Descricao);
            fluxo.AprovarPassoAtual(passoA);
            fluxo.AprovarPassoAtual(passoC);
            fluxo.AprovarPassoAtual(passoB);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoD.Descricao);
        }

        [TestMethod]
        public void PassosComPassoSuperiorMuitoMaisDemoradoQueOsDemais()
        {
            #region ProximosPassos
            passoA.AdicionarProximoPasso(new List<Passo> { passoB, passoC, passoD });
            passoB.AdicionarProximoPasso(new List<Passo> { passoE });
            passoC.AdicionarProximoPasso(new List<Passo> { passoH });
            passoD.AdicionarProximoPasso(new List<Passo> { passoI });
            passoE.AdicionarProximoPasso(new List<Passo> { passoF });
            passoF.AdicionarProximoPasso(new List<Passo> { passoG, passoH });
            passoG.AdicionarProximoPasso(new List<Passo> { passoJ });
            passoH.AdicionarProximoPasso(new List<Passo> { passoJ });
            passoI.AdicionarProximoPasso(new List<Passo> { passoJ });
            #endregion

            #region PassosAnteriores
            passoB.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoC.AdicionarPassoAnterior(new List<Passo> { passoB });
            passoD.AdicionarPassoAnterior(new List<Passo> { passoB });

            passoE.AdicionarPassoAnterior(new List<Passo> { passoB, passoC, passoD });
            passoF.AdicionarPassoAnterior(new List<Passo> { passoC, passoD });
            passoG.AdicionarPassoAnterior(new List<Passo> { passoB, passoD });

            passoH.AdicionarPassoAnterior(new List<Passo> { passoE, passoG });
            passoI.AdicionarPassoAnterior(new List<Passo> { passoE, passoF, passoG });

            passoJ.AdicionarPassoAnterior(new List<Passo> { passoH, passoI });
            #endregion

            WorkFlow fluxo = new WorkFlow();
            fluxo.AdicionarPasso(new List<Passo> { passoA });
            fluxo.AdicionarPasso(new List<Passo> { passoB, passoC, passoD });
            fluxo.AdicionarPasso(new List<Passo> { passoE, passoF, passoG });
            fluxo.AdicionarPasso(new List<Passo> { passoH, passoI });
            fluxo.AdicionarPasso(new List<Passo> { passoJ });

            //Aprovar P1
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoA.Descricao);
            fluxo.AprovarPassoAtual(passoA);
            fluxo.AprovarPassoAtual(passoC);
            fluxo.AprovarPassoAtual(passoB);
            //Aprovar P2
            Assert.AreEqual(fluxo.PassoAtual.Descricao, passoD.Descricao);
            //fluxo.AprovarPassoAtual(passoB);
            ////Aprovar P3
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoC.Descricao);
            //fluxo.AprovarPassoAtual(passoC);
            ////Aprovar P4
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoD.Descricao);
            //fluxo.AprovarPassoAtual(passoD);
            ////Aprovar P5
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoE.Descricao);
            //fluxo.AprovarPassoAtual(passoE);
            ////Aprovar P6
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoF.Descricao);
            //fluxo.AprovarPassoAtual(passoF);
            ////Aprovar P6
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoG.Descricao);
            //fluxo.AprovarPassoAtual(passoG);
            ////Aprovar P6
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoH.Descricao);
            //fluxo.AprovarPassoAtual(passoH);
            ////Aprovar P6
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoI.Descricao);
            //fluxo.AprovarPassoAtual(passoI);
            ////Aprovar P6
            //Assert.AreEqual(fluxo.PassoAtual.Descricao, passoJ.Descricao);
            //fluxo.AprovarPassoAtual(passoJ);

            //Assert.IsTrue(fluxo.Concluido);
        }
    }
}
