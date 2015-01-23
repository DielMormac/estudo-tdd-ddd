namespace QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Modelos
{
    public class AtividadePacote
    {
        public AtividadePacote(int id, string nome, decimal valor, int vagas, int idPacote)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Vagas = vagas;
            IdPacote = idPacote;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int Vagas { get; private set; }
        public int IdPacote { get; private set; }
    }
}