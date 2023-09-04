using investTools.Web.Utils;
using investTools.Web.ViewModels.Pessoa;

namespace investTools.Web.Models.Pessoa;
                                                                                // Alterar para CreateContaAplicacoesModel
public interface IContaAplicacaoRepository : IRepository<ContaAplicacao, int, CreateInvestidorViewModel>
{
}
