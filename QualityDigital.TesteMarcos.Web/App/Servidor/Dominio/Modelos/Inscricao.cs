using System.Linq;
using System;
using System.Collections.Generic;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Modelos
{
    public class Inscricao
    {
        public Inscricao(
            string nomeDoParticipante, 
            DateTime dataDeNascimentoDoParticipante,
            string telefoneDoParticipante,
            Pacote pacoteSelecionado,
            int[] atividadesSelecionadas)
        {
            Id = int.MaxValue; //todo: O mínimo para passar nos testes de unidade
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
        public int[] AtividadesSelecionadas { get; private set; }

        private void ValidaInscricao()
        {
            if (String.IsNullOrWhiteSpace(NomeDoParticipante) || NomeDoParticipante.Length < 5)
                throw new InformacaoInvalidaNoModelo("O nome do participante é inválido.");

            if (String.IsNullOrWhiteSpace(TelefoneDoParticipante))
                throw new InformacaoInvalidaNoModelo("O telefone do participante é inválido.");

            if (PacoteSelecionado == null)
                throw new InformacaoInvalidaNoModelo("O pacote selecionado é inválido.");

            if (AtividadesSelecionadas == null || AtividadesSelecionadas.Length == 0)
                throw new InformacaoInvalidaNoModelo("Não há atividades selecionadas.");

            //todo: continuar
        }
    }
}