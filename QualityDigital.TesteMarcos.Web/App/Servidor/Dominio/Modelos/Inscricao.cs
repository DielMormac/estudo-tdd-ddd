using System;
using System.Collections.Generic;

namespace QualityDigital.TesteMarcos.Web.Dominio.Modelos
{
    public class Inscricao
    {
        public Inscricao(
            string nomeDoParticipante, 
            DateTime dataDeNascimentoDoParticipante,
            string telefoneDoParticipante,
            Pacote pacoteSelecionado,
            IEnumerable<AtividadePacote> atividadesSelecionadas)
        {
            //TODO O mínimo para passar nos testes de unidade
            Id = int.MaxValue;
            NomeDoParticipante = nomeDoParticipante;
            DataDeNascimentoDoParticipante = dataDeNascimentoDoParticipante;
            TelefoneDoParticipante = telefoneDoParticipante;
            PacoteSelecionado = pacoteSelecionado;
            AtividadesSelecionadas = atividadesSelecionadas;
        }

        public int Id { get; private set; }
        public string NomeDoParticipante { get; private set; }
        public DateTime DataDeNascimentoDoParticipante { get; private set; }
        public string TelefoneDoParticipante { get; private set; }
        public Pacote PacoteSelecionado { get; private set; }
        public IEnumerable<AtividadePacote> AtividadesSelecionadas { get; private set; }
    }
}