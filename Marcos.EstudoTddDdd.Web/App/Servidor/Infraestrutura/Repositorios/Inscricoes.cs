using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Contratos;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Modelos;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Repositorios
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