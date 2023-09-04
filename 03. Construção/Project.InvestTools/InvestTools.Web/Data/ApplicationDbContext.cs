using investTools.Web.Models.Pessoa;
using investTools.Web.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public DbSet<Investidor>? Investidores { get; set; }
    public DbSet<ContaAplicacao>? ContaAplicacoes { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
        optionsBuilder.LogTo(Console.WriteLine);
    }

/*
    // https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).DataAlteracao = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).DataInclusao = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    // https://dotnetcoretutorials.com/auto-updating-created-updated-and-deleted-timestamps-in-entity-framework/?expand_article=1
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var insertedEntries = this.ChangeTracker.Entries()
                               .Where(x => x.State == EntityState.Added)
                               .Select(x => x.Entity);

        foreach (var insertedEntry in insertedEntries)
        {
            var auditableEntity = insertedEntry as BaseEntity;
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
            var auditableEntity = modifiedEntry as BaseEntity;
            if (auditableEntity != null)
            {
                auditableEntity.DateUpdated = DateTimeOffset.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
*/
}
