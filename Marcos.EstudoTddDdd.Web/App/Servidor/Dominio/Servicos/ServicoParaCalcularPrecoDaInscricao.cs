
using System.Linq;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Contratos;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Servicos
{
    public class ServicoParaCalcularPrecoDaInscricao
    {
        private readonly ServicoDeConsultaDePacotes _servicoDeConsultaDePacotes;

        public ServicoParaCalcularPrecoDaInscricao(ServicoDeConsultaDePacotes servicoDeConsultaDePacotes)
        {
            _servicoDeConsultaDePacotes = servicoDeConsultaDePacotes;
        }

        public decimal Calcular(int idDoEvento, int[] atividadesSelecionadas)
        {
            var pacote = _servicoDeConsultaDePacotes.ConsultarPorId(idDoEvento);

            if (atividadesSelecionadas != null)
                return pacote != null ? 
                    pacote.Valor + pacote.Atividades.Where(x => atividadesSelecionadas.Contains(x.Id)).Sum(x => x.Valor) : 0;
            
            return pacote != null ? pacote.Valor : 0;
        }
    }
}