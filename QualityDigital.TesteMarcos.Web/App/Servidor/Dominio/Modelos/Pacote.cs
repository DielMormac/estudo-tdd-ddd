using System.Collections.Generic;

namespace QualityDigital.TesteMarcos.Web.Dominio.Modelos
{
    public class Pacote
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Vagas { get; set; }
        public IEnumerable<AtividadePacote> Atividades { get; set; }

        public Pacote(int id, string nome, decimal valor, int vagas, IEnumerable<AtividadePacote> atividades)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Vagas = vagas;
            Atividades = atividades;
        }
    }
}