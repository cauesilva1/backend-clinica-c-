using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProcedimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcedimentoModel>> Get()
        {
            return _context.procedimentos.ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProcedimentoModel procedimento)
        {
            try
            {
                // Verifica se já existe um procedimento com o mesmo nome
                var existingProcedimento = _context.procedimentos.FirstOrDefault(p => p.procedimento == procedimento.procedimento);

                if (existingProcedimento != null)
                {
                    return Conflict($"Já existe um procedimento com o nome '{procedimento.procedimento}'.");
                }

                var procedimentoJson = JsonSerializer.Serialize(procedimento);
                Console.WriteLine(procedimentoJson);

                _context.Add(procedimento);
                _context.SaveChanges();

                return Ok(procedimento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o procedimento: {ex.Message}");
            }
        }
    }
}
