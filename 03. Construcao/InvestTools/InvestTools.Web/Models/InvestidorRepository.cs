using investTools.Web.Data;
using investTools.Web.Utils;
using investTools.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Models;

public class InvestidorRepository : IInvestidorRepository
{
    private readonly ApplicationDbContext _context;
    public InvestidorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteAsync(CreateInvestidorViewModel model)
    {
        var investidor = await _context.Investidores
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.CPF == model.CPF);

        _context.Investidores.Remove(investidor);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExistAsync(CreateInvestidorViewModel model)
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

    public async Task<Investidor> GetByIdAsync(CreateInvestidorViewModel model)
    {
        var investidor = await _context.Investidores
                                .AsNoTracking()
                                .FirstOrDefaultAsync(i => model.Id > 0 ? i.Id == model.Id: i.CPF == model.CPF );
                                
        if (investidor == null)
            throw new Exception("Investidor não encontrado");

        return investidor;
    }

    public async Task<int> InsertAsync(CreateInvestidorViewModel model)
    {
        // try
        // {
        var investidor = new Investidor
        {
            CPF = model.CPF,
            Nome = model.Nome,
            DataNascimento = model.DataNascimento,
            Renda = model.Renda,
            AporteMensal = model.AporteMensal,
            DataInclusao = DateTime.Now,
            Email = model.Email
        };

        await _context.AddAsync(investidor);

        var savechangesresult = await _context.SaveChangesAsync();

        return savechangesresult;
        // }
        // catch( Microsoft.EntityFrameworkCore.DbUpdateException ex)
        // {
        // throw new Exception( ex.Message );
        // }
    }

    public async Task<Investidor> UpdateAsync(CreateInvestidorViewModel item)
    {
        var investidor = await _context.Investidores
                                    .FirstOrDefaultAsync(i => i.Id == item.Id);

        if (investidor == null)
            throw new Exception("Investidor não encontrado");

        investidor.CPF = item.CPF;
        investidor.Nome = item.Nome;
        investidor.DataNascimento = item.DataNascimento;
        investidor.Renda = item.Renda;
        investidor.AporteMensal = item.AporteMensal;
        investidor.Email = item.Email;
        investidor.DataAlteracao = DateTime.Now;

        _context.Investidores.Update(investidor);
        await _context.SaveChangesAsync();

        return investidor;

    }

}
