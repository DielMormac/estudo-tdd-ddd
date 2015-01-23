
using System.Collections.Generic;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura.Fabricas;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Servicos
{
    public class ServicoDeConsultaDePacotes
    {
        public IEnumerable<Pacote> ConsultarTodos()
        {
            using (var ut = FabricaUnidadeDeTrabalho.Criar())
                return new Pacotes(ut).ConsultarTodos();
        }

        public Pacote ConsultarPorId(int idDoEvento)
        {
            using (var ut = FabricaUnidadeDeTrabalho.Criar())
                return new Pacotes(ut).ConsultarPorId(idDoEvento);
        }
    }
}