using investTools.Web.Models.Pessoa;
using investTools.Web.Utils;

namespace investTools.Web.Models.Ativo;

public class PrecoMedio : BaseEntity
{
    public Investidor Investidor { get; set; } = default!;
    
    public Ativo Ativo { get; set; } = default!;

    public decimal Preco { get; set; }

}
