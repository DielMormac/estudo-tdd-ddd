
using System.Collections.Generic;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura.Fabricas;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Servicos
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