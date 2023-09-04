using investTools.Web.Utils;
using investTools.Web.ViewModels.Pessoa;

namespace investTools.Web.Models.Pessoa;

public interface IInvestidorRepository: IRepository<Investidor,int, CreateInvestidorViewModel>
{
    
}
