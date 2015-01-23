using System;
using System.Collections.Generic;

namespace QualityDigital.TesteMarcos.Web.Dominio.Modelos
{
    public class Inscricao
    {
        public Inscricao(string nomeDoParticipante, DateTime dataDeNascimentoDoParticipante,
            string telefoneDoParticipante,
            Pacote pacoteSelecionado,
            IEnumerable<AtividadePacote> atividadesSelecionadas)
        {
            NomeDoParticipante = nomeDoParticipante;
            DataDeNascimentoDoParticipante = dataDeNascimentoDoParticipante;
            TelefoneDoParticipante = telefoneDoParticipante;
            PacoteSelecionado = pacoteSelecionado;
            AtividadesSelecionadas = atividadesSelecionadas;
        }

        public int Id { get; set; }
        public string NomeDoParticipante { get; set; }
        public DateTime DataDeNascimentoDoParticipante { get; set; }
        public string TelefoneDoParticipante { get; set; }
        public Pacote PacoteSelecionado { get; set; }
        public IEnumerable<AtividadePacote> AtividadesSelecionadas { get; set; }
    }
}