
using System;
using System.Data;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        IDbCommand CriarComando();
        void SalvarAlteracoes();
    }
}