using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using teste.Models;
using teste.Data;

namespace teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> Get()
        {
            try
            {
                var clientes = _context.Clientes.ToList();
                return Ok(clientes);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao obter os clientes");
            }
        }

        [HttpGet("{cpf}")]
        public ActionResult<ClienteModel> Get(string cpf)
        {
            try
            {
                var cliente = _context.Clientes.Find(cpf);
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter o cliente: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClienteModel cliente)
        {
            try
            {
                // Configurar as opções do serializador JSON
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                // Converter o objeto ClienteModel de volta para JSON
                var clienteJson = JsonSerializer.Serialize(cliente, options);

                Console.WriteLine(clienteJson);

                _context.Add(cliente);
                _context.SaveChanges();

                // Retornar o JSON como resposta
                return Ok(clienteJson);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retornar uma resposta de erro com uma mensagem apropriada
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
