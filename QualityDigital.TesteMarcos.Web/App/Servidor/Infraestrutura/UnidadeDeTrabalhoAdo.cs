using System.Data;
using System.Data.SqlClient;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura
{
    public class UnidadeDeTrabalhoAdo : IUnidadeDeTrabalho
    {
        private SqlConnection _conexao;
        private SqlTransaction _transacao;
        private readonly bool _conexaoPropria;

        public UnidadeDeTrabalhoAdo(SqlConnection conexao, bool conexaoPropria)
        {
            _conexao = conexao;
            _conexaoPropria = conexaoPropria;
            _transacao = _conexao.BeginTransaction();
        }

        public IDbCommand CriarComando()
        {
            var comando = _conexao.CreateCommand();
            comando.Transaction = _transacao;
            return comando;
        }

        public void SalvarAlteracoes()
        {
            _transacao.Commit();
            _transacao = null;
        }

        public void Dispose()
        {
            if (_transacao != null)
            {
                _transacao.Rollback();
                _transacao = null;
            }

            if (_conexao != null && _conexaoPropria)
            {
                _conexao.Close();
                _conexao = null;
            }
        }
    }
}