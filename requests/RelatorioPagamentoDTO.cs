namespace teste.requests;

public class RelatorioPagamentoDTO
{
    public string NomePaciente { get; set; }
    public string ValorPago { get; set; }
    public string FormaPagamento { get; set; }
    public string Procedimento { get; set; }
    public string Profissional { get; set; }
    public DateTime HorarioAgendado { get; set; }
    public DateTime DataHoraPagamento { get; set; }
}
