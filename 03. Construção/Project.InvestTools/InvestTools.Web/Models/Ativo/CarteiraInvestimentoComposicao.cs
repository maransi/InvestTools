using investTools.Web.Utils;

namespace investTools.Web.Models.Ativo;

public class CarteiraInvestimentoComposicao: BaseEntity
{
    public CarteiraInvestimento CarteiraInvestimento { get; set; } = default!;

    public string? descricao { get; set; }

    public decimal? PercentualComposicao { get; set; }
    
}
