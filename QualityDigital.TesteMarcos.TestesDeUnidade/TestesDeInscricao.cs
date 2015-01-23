using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityDigital.TesteMarcos.Web.Aplicacao.Servicos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Servicos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura.Fabricas;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios;

namespace QualityDigital.TesteMarcos.TestesDeUnidade
{
    [TestClass]
    public class TestesDeInscricao
    {
        [TestMethod]
        public void ComoUsuarioQueroMeInscreverNoEvento()
        {
            //Arrange
            var atividadesPacote = new List<AtividadePacote>
            {
                new AtividadePacote(1,"Princíos S.O.L.I.D", 10, 5,1),
                new AtividadePacote(2,"DDD", 2, 5,1),
            };

            Inscricao inscricao =
                new Inscricao("Marcos",
                    new DateTime(1991, 7, 12),
                    "11987607381",
                    new Pacote(1, "Arquitetura de Software", 10, 5, atividadesPacote),
                    atividadesPacote);

            //Act
            ServicoDeConfirmacaoDaInscricao servico = new ServicoDeConfirmacaoDaInscricao();
            Inscricao inscricaoSalva = servico.ConfirmarInscricao(inscricao);

            //Asserts
            Assert.IsTrue(inscricaoSalva.Id > 0);
        }

        [TestMethod]
        public void ComoUsuarioQueroPodeVisualizarOTotalDoPacoteSelecionado()
        {
            //Arrange
            var atividadesSelecionadas = new []
            {
                1,
                2
            };

            const int pacote = 1;

            //Act
            var precoDaInscricao = new ServicoParaCalcularPrecoDaInscricao(new ServicoDeConsultaDePacotes())
                .Calcular(pacote, atividadesSelecionadas);

            //Asserts
            Assert.IsTrue(precoDaInscricao > 0);
        }

        [TestMethod]
        public void ComoUsuarioQueroPodeVisualizarAQuantidadeDeVagasDisponiveisNoPacote()
        {
        }

        [TestMethod]
        public void ComoUsuarioQueroPodeVisualizarAQuantidadeDeVagasDisponiveisNaAtividadeDoPacote()
        {
        }

        [TestMethod]
        public void ComoUsuarioQueroPodeConsultarAListaDosPacotesDisponiveis()
        {
            //Arrange
            Pacotes pacotes = new Pacotes(FabricaUnidadeDeTrabalho.Criar());

            //Act
            var todosOsPacotes = pacotes.ConsultarTodos();

            //Assert
            Assert.IsTrue(todosOsPacotes.Any());
        }

    }
}
