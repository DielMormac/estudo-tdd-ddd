
using System.Collections.Generic;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Modelos;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Contratos
{
    public interface IInscricoes
    {
        IInscricoes NaUnidadeDeTrabalho(IUnidadeDeTrabalho ut);
        Inscricao Inserir(Inscricao inscricao);
    }
}