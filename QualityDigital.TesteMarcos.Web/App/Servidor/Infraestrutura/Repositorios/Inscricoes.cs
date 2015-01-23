using QualityDigital.TesteMarcos.Web.Dominio.Modelos;

namespace QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios
{
    public class Inscricoes
    {
        public Inscricao Inserir(Inscricao inscricao)
        {
            inscricao.Id = int.MaxValue;
            return inscricao;
        }
    }
}