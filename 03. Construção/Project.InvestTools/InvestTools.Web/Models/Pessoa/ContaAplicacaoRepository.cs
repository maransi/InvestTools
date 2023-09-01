using investTools.Web.Utils;

namespace investTools.Web.Models.Pessoa;

public class ContaAplicacaoRepository : IContaAplicacaoRepository
{
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ContaAplicacao>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ContaAplicacao> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ContaAplicacao> InsertAsync(ContaAplicacao item)
    {
        throw new NotImplementedException();
    }

    public Task<ContaAplicacao> UpdateAsync(ContaAplicacao item)
    {
        throw new NotImplementedException();
    }
}
