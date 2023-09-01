using investTools.Web.Models.Pessoa;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public DbSet<Investidor>? Investidores{ get; set; }
    public DbSet<ContaAplicacao>? ContaAplicacoes{ get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
        optionsBuilder.LogTo(Console.WriteLine);
    }

}
