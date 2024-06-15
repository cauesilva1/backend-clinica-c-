using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;
using teste.requests;

namespace teste.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgendaController : ControllerBase
{
    private readonly AppDbContext _context;

        public AgendaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AgendamentoModel>> Get()
        {
            return _context.Agendamentos.ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] AgendaRequest request)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Cpf_Cliente == request.Cpf_Cliente);
                var procedimento = _context.procedimentos.FirstOrDefault(p => p.procedimento == request.Nome_Procedimento);
                var profissional = _context.profissionais.FirstOrDefault(pr => pr.nome_profissional == request.Nome_Profissional);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado.");
                }
                if (procedimento == null)
                {
                    return NotFound("Procedimento não encontrado.");
                }
                if (profissional == null)
                {
                    return NotFound("Profissional não encontrado.");
                }

                var agendamento = new AgendamentoModel
                {
                    Cpf_Cliente = cliente.Cpf_Cliente,
                    cod_procedimento = procedimento.cod_procedimento,
                    id_profissional = profissional.id_profissional,
                    horario_agendamento = request.Horario_Agendamento
                };

                _context.Agendamentos.Add(agendamento);
                _context.SaveChanges();

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o agendamento: {ex.Message}");
            }
        }
}
