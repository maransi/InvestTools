using investTools.Web.Utils;

namespace investTools.Web.Models.Ativo;

public class Ativo: BaseEntity
{
    public string? Ticker { get; set; }

    public string? Descricao { get; set; }

}
