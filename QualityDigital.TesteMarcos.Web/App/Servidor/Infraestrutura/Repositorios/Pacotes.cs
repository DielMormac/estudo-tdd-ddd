using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Contratos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura;
using QualityDigital.TesteMarcos.Web.Dominio.Modelos;

namespace QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios
{
    public class Pacotes : IPacotes
    {
        private readonly IUnidadeDeTrabalho _ut;

        public Pacotes(IUnidadeDeTrabalho ut)
        {
            _ut = ut;
        }

        public Pacote ConsultarPorId(int id)
        {
            var atividades = ConsultarAtividadesPorIdDoPacote(id);

            using (var comando = _ut.CriarComando())
            {
                comando.CommandText = "select codpac,descricao,vagas,precopac from Pacote (nolock) where codpac = @codpac";
                comando.Parameters.Add(new SqlParameter("@codpac", id));

                return ExecutaComandoPacote(comando, atividades).FirstOrDefault();
            }
        }

        public IEnumerable<Pacote> ConsultarTodos()
        {
            var atividades = ConsultarTodasAtividades();

            using (var comando = _ut.CriarComando())
            {
                comando.CommandText = "select codpac,descricao,vagas,precopac from Pacote (nolock) order by descricao";
                return ExecutaComandoPacote(comando, atividades);
            }
        }

        private IEnumerable<Pacote> ExecutaComandoPacote(IDbCommand comando, IEnumerable<AtividadePacote> atividades)
        {
            var pacotes = new List<Pacote>();

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                    pacotes.Add(MapearPacote(reader, atividades));

                return pacotes;
            }
        }

        private Pacote MapearPacote(IDataRecord registro, IEnumerable<AtividadePacote> atividades)
        {
            var id = (int)registro["codpac"];

            return new Pacote(
                id,
                (string)registro["descricao"],
                (decimal)registro["precopac"],
                (int)registro["vagas"],
                atividades.Where(x => x.IdPacote == id)
            );
        }

        private IEnumerable<AtividadePacote> ConsultarTodasAtividades()
        {
            using (var comando = _ut.CriarComando())
            {
                comando.CommandText = "select codatv,descricao,vagas,precoatv,codpac from Atividade (nolock) order by descricao";
                return ExecutaComandoPacote(comando);
            }
        }

        private IEnumerable<AtividadePacote> ConsultarAtividadesPorIdDoPacote(int idDoPacote)
        {
            using (var comando = _ut.CriarComando())
            {
                comando.CommandText = "select codatv,descricao,vagas,precoatv,codpac from Atividade (nolock) where codpac = @codpac order by descricao";
                comando.Parameters.Add(new SqlParameter("@codpac", idDoPacote));
                return ExecutaComandoPacote(comando);
            }
        }

        private IEnumerable<AtividadePacote> ExecutaComandoPacote(IDbCommand comando)
        {
            var pacotes = new List<AtividadePacote>();

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                    pacotes.Add(MapearAtividadePacote(reader));

                return pacotes;
            }
        }

        private AtividadePacote MapearAtividadePacote(IDataRecord registro)
        {
            return new AtividadePacote(
                (int)registro["codatv"],
                (string)registro["descricao"],
                (decimal)registro["precoatv"],
                (int)registro["vagas"],
                (int)registro["codpac"]);
        }
    }
}