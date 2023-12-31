using investTools.Web.Models.Pessoa;
using investTools.Web.Utils;

namespace investTools.Web.Models.Ativo;

public class CarteiraInvestimento : BaseEntity
{
    public int Id { get; set; }

    public Investidor Investidor { get; set; } = default!;

    public string? nome { get; set; }
}
