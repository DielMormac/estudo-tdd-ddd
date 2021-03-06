﻿using System.Data.SqlClient;

namespace Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Fabricas
{
    public static class FabricaUnidadeDeTrabalho
    {
        public static IUnidadeDeTrabalho Criar()
        {
            
            var conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["bancodedados"].ToString());
            conexao.Open();
            return new UnidadeDeTrabalhoAdo(conexao, true);
        }
    }
}