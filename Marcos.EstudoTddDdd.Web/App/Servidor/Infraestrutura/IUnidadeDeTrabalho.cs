
using System;
using System.Data;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        IDbCommand CriarComando();
        void SalvarAlteracoes();
    }
}