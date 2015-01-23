
using System.Collections.Generic;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Modelos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos
{
    public interface IInscricoes
    {
        IInscricoes NaUnidadeDeTrabalho(IUnidadeDeTrabalho ut);
        Inscricao Inserir(Inscricao inscricao);
    }
}