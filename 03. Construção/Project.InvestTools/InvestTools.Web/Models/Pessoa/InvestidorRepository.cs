using investTools.Web.Data;
using investTools.Web.Utils;
using investTools.Web.ViewModels;
using investTools.Web.ViewModels.Pessoa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Models.Pessoa;

public class InvestidorRepository : IInvestidorRepository
{
    private readonly ApplicationDbContext _context;
    public InvestidorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Investidor>> GetAllAsync()
    {
        var investidores = await _context.Investidores
                                         .AsNoTracking()
                                         .ToListAsync();

        return investidores;
    }

    public Task<Investidor> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> InsertAsync(CreateInvestidorViewModel model)
    {
        // try
        // {
            var investidor = new Investidor
            {
                CPF = model.CPF,
                Nome = model.Nome,
                Renda = model.Renda,
                AporteMensal = model.AporteMensal,
                DataInclusao = DateTime.Now
            };

            await _context.AddAsync( investidor );

            var savechangesresult = await _context.SaveChangesAsync();

            return savechangesresult;
        // }
        // catch( Microsoft.EntityFrameworkCore.DbUpdateException ex)
        // {
            // throw new Exception( ex.Message );
        // }
    }

    public Task<Investidor> UpdateAsync(Investidor item)
    {
        throw new NotImplementedException();
    }

}
