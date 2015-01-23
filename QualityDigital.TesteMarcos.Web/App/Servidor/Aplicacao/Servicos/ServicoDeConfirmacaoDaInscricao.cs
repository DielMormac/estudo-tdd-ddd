using QualityDigital.TesteMarcos.Web.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios;

namespace QualityDigital.TesteMarcos.Web.Aplicacao.Servicos
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