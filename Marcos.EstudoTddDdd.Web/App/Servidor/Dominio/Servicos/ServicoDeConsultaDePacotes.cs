
using System.Collections.Generic;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Fabricas;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Modelos;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Repositorios;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Contratos;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Servicos
{
    public class ServicoDeConsultaDePacotes
    {
        private System.Func<IUnidadeDeTrabalho> _fabricaUnidadeDeTrabalho;
        private IPacotes _pacotes;

        public ServicoDeConsultaDePacotes(System.Func<IUnidadeDeTrabalho> fabricaUnidadeDeTrabalho, IPacotes pacotes)
        {
            _fabricaUnidadeDeTrabalho = fabricaUnidadeDeTrabalho;
            _pacotes = pacotes;
        }

        public IEnumerable<Pacote> ConsultarTodos()
        {
            using (var ut = _fabricaUnidadeDeTrabalho())
                return _pacotes.NaUnidadeDeTrabalho(ut).ConsultarTodos();
        }

        public Pacote ConsultarPorId(int idDoEvento)
        {
            using (var ut = _fabricaUnidadeDeTrabalho())
                return _pacotes.NaUnidadeDeTrabalho(ut).ConsultarPorId(idDoEvento);
        }
    }
}