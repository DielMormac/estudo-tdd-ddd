
using System.Collections.Generic;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos
{
    public interface IPacotes
    {
        Pacote ConsultarPorId(int id);
        IEnumerable<Pacote> ConsultarTodos();
    }
}