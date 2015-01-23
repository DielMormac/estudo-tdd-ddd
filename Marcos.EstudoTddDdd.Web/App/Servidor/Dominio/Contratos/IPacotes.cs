
using System.Collections.Generic;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Modelos;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Contratos
{
    public interface IPacotes
    {
        IPacotes NaUnidadeDeTrabalho(IUnidadeDeTrabalho ut);
        Pacote ConsultarPorId(int id);
        IEnumerable<Pacote> ConsultarTodos();
    }
}