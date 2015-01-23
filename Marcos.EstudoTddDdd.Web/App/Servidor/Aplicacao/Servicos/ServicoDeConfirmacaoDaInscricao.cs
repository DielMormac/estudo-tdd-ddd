using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Modelos;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Repositorios;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Aplicacao.Servicos
{
    public class ServicoDeConfirmacaoDaInscricao
    {
        public Inscricao ConfirmarInscricao(Inscricao inscricao)
        {
            Inscricoes inscricoes = new Inscricoes();
            var inscricaoSalva = inscricoes.Inserir(inscricao);

            //Manter as vagas disponíveis?
            //Enviar e-mail de confirmação
            //Enviar SMS
            //Qualquer outra coisa

            return inscricaoSalva;
        }
    }
}