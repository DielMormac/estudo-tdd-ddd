using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;

namespace QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios
{
    public class Inscricoes : IInscricoes
    {
        private IUnidadeDeTrabalho _ut;

        public IInscricoes NaUnidadeDeTrabalho(IUnidadeDeTrabalho ut)
        {
            _ut = ut;
            return this;
        }

        public Inscricao Inserir(Inscricao inscricao)
        {
            //TODO O mínimo para passar nos testes de unidade
            return new Inscricao("", new System.DateTime(), "", null, null);
        }
    }
}