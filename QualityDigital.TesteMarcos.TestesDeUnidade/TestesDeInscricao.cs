using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualityDigital.TesteMarcos.Web.Aplicacao.Servicos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Servicos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura.Fabricas;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios;
using Rhino.Mocks;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos;

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
            var atividadesPacoteSelecionado = new List<AtividadePacote>
            {
                new AtividadePacote(1,"Princíos S.O.L.I.D", valor: 10, vagas: 5, idPacote: 1),
                new AtividadePacote(2,"DDD", valor: 2, vagas: 3, idPacote: 1),
            };

            var pacoteSelecionado = new Pacote(1, "Arquitetura de Software", valor: 10, vagas: 5, atividades: atividadesPacoteSelecionado);

            var atividadesSelecionadas = new [] {1};

            
            var mockUnidadeTrabalho = MockRepository.GenerateMock<IUnidadeDeTrabalho>();
            var mockPacotes = MockRepository.GenerateMock<IPacotes>();

            mockPacotes.Stub(x => x.NaUnidadeDeTrabalho(mockUnidadeTrabalho)).Return(mockPacotes);
            mockPacotes.Stub(x => x.ConsultarPorId(1)).Return(pacoteSelecionado);

            //Act
            var precoDaInscricao = new ServicoParaCalcularPrecoDaInscricao(new ServicoDeConsultaDePacotes(() => mockUnidadeTrabalho, mockPacotes))
                .Calcular(1, atividadesSelecionadas);

            //Asserts
            Assert.IsTrue(precoDaInscricao == 20);
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
            var mockUnidadeTrabalho = MockRepository.GenerateMock<IUnidadeDeTrabalho>();
            var mockPacotes = MockRepository.GenerateMock<IPacotes>();

            mockPacotes.Stub(x => x.NaUnidadeDeTrabalho(mockUnidadeTrabalho)).Return(mockPacotes);
            mockPacotes.Stub(x => x.ConsultarTodos()).Return(new List<Pacote> { new Pacote(1, "pacote", valor: 10, vagas: 2, atividades: new List<AtividadePacote>()) });

            //Act
            var todosOsPacotes = new ServicoDeConsultaDePacotes(() => mockUnidadeTrabalho, mockPacotes).ConsultarTodos();

            //Assert
            Assert.IsTrue(todosOsPacotes.Count() == 1);
            Assert.IsTrue(todosOsPacotes.First().Valor == 10);
        }

    }
}
