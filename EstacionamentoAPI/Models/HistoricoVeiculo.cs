namespace EstacionamentoAPI.Models
{
    public class HistoricoVeiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public Decimal ValorPago { get; set; }
    } 
}