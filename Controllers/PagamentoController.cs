using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;
using System.Linq;
using System.Text.Json;
using teste.requests;

namespace teste.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagamentoController : ControllerBase
{

    private readonly AppDbContext _context;

        public PagamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PagamentoModel>> Get()
        {
            return _context.Pagamentos.ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] PagamentoModel pagamento)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Cpf_Cliente == pagamento.Cpf_Cliente);
                var agendamento = _context.Agendamentos.FirstOrDefault(a => a.id_agendamento == pagamento.id_agendamento);

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado.");
                }

                if (agendamento == null)
                {
                    return NotFound("Agendamento não encontrado.");
                }

                var pagamentoJson = JsonSerializer.Serialize(pagamento);
                Console.WriteLine(pagamentoJson);

                _context.Pagamentos.Add(pagamento);
                _context.SaveChanges();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o pagamento: {ex.Message}");
            }
        }


        [HttpGet("relatorio")]
        public ActionResult<IEnumerable<RelatorioPagamentoDTO>> GetRelatorioPagamentos()
        {
            var relatorio = from pagamento in _context.Pagamentos
                            join agendamento in _context.Agendamentos on pagamento.id_agendamento equals agendamento.id_agendamento
                            join cliente in _context.Clientes on agendamento.Cpf_Cliente equals cliente.Cpf_Cliente
                            join procedimento in _context.procedimentos on agendamento.cod_procedimento equals procedimento.cod_procedimento
                            join profissional in _context.profissionais on agendamento.id_profissional equals profissional.id_profissional
                            select new RelatorioPagamentoDTO
                            {
                                NomePaciente = cliente.Nome_Cliente,
                                ValorPago = pagamento.ValorPago,
                                FormaPagamento = pagamento.forma_pagamento,
                                Procedimento = procedimento.procedimento,
                                Profissional = profissional.nome_profissional,
                                HorarioAgendado = agendamento.horario_agendamento,
                                DataHoraPagamento = pagamento.data_pagamento
                            };

            return Ok(relatorio.ToList());
        }


        [HttpGet("relatorio/{cpf}")]
        public ActionResult<IEnumerable<RelatorioPagamentoDTO>> GetRelatorioPagamentosPorCpf(string cpf)
        {
            var relatorio = from pagamento in _context.Pagamentos
                            join agendamento in _context.Agendamentos on pagamento.id_agendamento equals agendamento.id_agendamento
                            join cliente in _context.Clientes on agendamento.Cpf_Cliente equals cliente.Cpf_Cliente
                            join procedimento in _context.procedimentos on agendamento.cod_procedimento equals procedimento.cod_procedimento
                            join profissional in _context.profissionais on agendamento.id_profissional equals profissional.id_profissional
                            where cliente.Cpf_Cliente == cpf
                            select new RelatorioPagamentoDTO
                            {
                                NomePaciente = cliente.Nome_Cliente,
                                ValorPago = pagamento.ValorPago,
                                FormaPagamento = pagamento.forma_pagamento,
                                Procedimento = procedimento.procedimento,
                                Profissional = profissional.nome_profissional,
                                HorarioAgendado = agendamento.horario_agendamento,
                                DataHoraPagamento = pagamento.data_pagamento
                            };

            if (!relatorio.Any())
            {
                return NotFound($"Nenhum pagamento encontrado para o CPF: {cpf}");
            }

            return Ok(relatorio.ToList());
        }
}
