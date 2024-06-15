using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.Data;

public class AppDbContext   : DbContext
{

    
    public DbSet<ClienteModel> Clientes { get; set; }

    public DbSet<ProfissionalModel> profissionais { get; set; }

    public DbSet<ProcedimentoModel> procedimentos { get; set; }

    public DbSet<AgendamentoModel> Agendamentos { get; set; }

    public DbSet<PagamentoModel> Pagamentos { get; set; }

    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
