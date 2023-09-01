using investTools.Web.Utils;

namespace investTools.Web.Models.Ativo;

public class CarteiraAlocacaoAtivo: BaseEntity
{
    public int Id { get; set; }

    public CarteiraInvestimentoComposicao CarteiraInvestimentoComposicao { get; set; } = default!;

    public string? MesAno { get; set; }

    public Ativo Ativo { get; set; } = default!;

    public decimal Dividendos {get; set;}

    public decimal JCP { get; set; }
    
    public decimal OutroRendimento { get; set; }
}
