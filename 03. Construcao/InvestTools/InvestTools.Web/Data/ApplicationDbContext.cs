using investTools.Web.Models;
using investTools.Web.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace investTools.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{

    private readonly IConfiguration _config;
    public DbSet<Investidor>? Investidores { get; set; }    // Linha inserida

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                IConfiguration config)
        : base(options)
    {
        _config = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var connectionString = "server=localhost;port=3306;database=investTools;uid=root;pwd=root;Persist Security Info=false;Connect Timeout=300;SSL Mode=None;AllowPublicKeyRetrieval=True;";

        var connectionString = _config.GetConnectionString("default");

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        optionsBuilder.LogTo(Console.WriteLine);
    }

    public override int SaveChanges()                   // Método Incluido
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((AuditEntity)entityEntry.Entity).DataAlteracao = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((AuditEntity)entityEntry.Entity).DataInclusao = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)   // Método Incluido
    {
        var insertedEntries = this.ChangeTracker.Entries()
                            .Where(x => x.State == EntityState.Added)
                            .Select(x => x.Entity);

        foreach (var insertedEntry in insertedEntries)
        {
            var auditableEntity = insertedEntry as AuditEntity;
            //If the inserted object is an Auditable. 
            if (auditableEntity != null)
            {
                auditableEntity.DataInclusao = DateTime.Now;
            }
        }


        var modifiedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

        foreach (var modifiedEntry in modifiedEntries)
        {
            //If the inserted object is an Auditable. 
            var auditableEntity = modifiedEntry as AuditEntity;
            if (auditableEntity != null)
            {
                auditableEntity.DataAlteracao = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
