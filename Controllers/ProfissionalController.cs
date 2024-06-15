using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;

namespace teste.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfissionalController : ControllerBase
{

    private readonly AppDbContext _context;

    public ProfissionalController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProfissionalModel>> Get()
    {
        return _context.profissionais.ToList();
    }

    [HttpGet("especialidade/{especialidade}")]
    public ActionResult<ProfissionalModel> GetPelaEspecialidade(string especialidade)
    {
        var profissional = _context.profissionais.FirstOrDefault(p => p.especialidade == especialidade);
        if (profissional == null)
        {
            return NotFound("Profissional não encontrado");
        }
        return Ok(profissional);
    }

    [HttpGet("nome/{nome_profissional}")]
    public ActionResult<ProfissionalModel> GetPeloNome(string nome_profissional)
    {
        var profissional = _context.profissionais.FirstOrDefault(p => p.nome_profissional == nome_profissional);
        if (profissional == null)
        {
            return NotFound("Profissional não encontrado");
        }
        return Ok(profissional);
    }

    [HttpPost]
    public ActionResult Post([FromBody] ProfissionalModel profissional)
    {
        Console.WriteLine(profissional);
        _context.Add(profissional);
        _context.SaveChanges();
        return Ok(profissional);
    }


}
