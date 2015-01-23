
using System.Collections.Generic;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos
{
    public interface IPacotes
    {
        IPacotes NaUnidadeDeTrabalho(IUnidadeDeTrabalho ut);
        Pacote ConsultarPorId(int id);
        IEnumerable<Pacote> ConsultarTodos();
    }
}