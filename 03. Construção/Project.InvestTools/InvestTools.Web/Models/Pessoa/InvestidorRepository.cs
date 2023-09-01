using investTools.Web.Utils;

namespace investTools.Web.Models.Pessoa;

public class InvestidorRepository : IInvestidorRepository
{
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Investidor>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Investidor> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Investidor> InsertAsync(Investidor item)
    {
        throw new NotImplementedException();
    }

    public Task<Investidor> UpdateAsync(Investidor item)
    {
        throw new NotImplementedException();
    }
}
