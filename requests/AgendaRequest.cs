namespace teste.requests;

public class AgendaRequest
{
    public string Cpf_Cliente { get; set; }
    public string Nome_Procedimento { get; set; }
    public string Nome_Profissional { get; set; }
    public DateTime Horario_Agendamento { get; set; }
}
