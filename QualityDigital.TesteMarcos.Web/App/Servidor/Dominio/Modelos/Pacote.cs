using System.Collections.Generic;

namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Modelos
{
    public class Pacote
    {
        public Pacote(int id, string nome, decimal valor, int vagas, IEnumerable<AtividadePacote> atividades)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Vagas = vagas;
            Atividades = atividades;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int Vagas { get; private set; }
        public IEnumerable<AtividadePacote> Atividades { get; private set; }
    }
}