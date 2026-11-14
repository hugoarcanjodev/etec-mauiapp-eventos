namespace MauiAppEventos.Models
{
    public class Evento
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; } = DateTime.Today;
        public DateTime DataTermino { get; set; } = DateTime.Today;
        public int NumeroParticipantes { get; set; }
        public string Local { get; set; } = string.Empty;
        public double CustoPorParticipante { get; set; }

        public TimeSpan Duracao
        {
            get => DataTermino.Subtract(DataInicio);
        }

        public int DuracaoEmDias
        {
            get => Duracao.Days + 1;
        }

        public double CustoTotal
        {
            get => NumeroParticipantes * CustoPorParticipante;
        }
    }
}
