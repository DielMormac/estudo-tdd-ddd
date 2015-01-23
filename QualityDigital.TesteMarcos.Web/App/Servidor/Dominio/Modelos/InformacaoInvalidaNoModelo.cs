using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Modelos
{
    public class InformacaoInvalidaNoModelo : Exception
    {
        public InformacaoInvalidaNoModelo(string mensagem)
            : base(mensagem)
        {

        }
    }
}