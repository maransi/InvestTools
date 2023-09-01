using investTools.Web.Utils;

namespace investTools.Web.Models.Ativo;

public class Ativo: BaseEntity
{
    public int Id { get; set; }

    public string? Ticker { get; set; }

    public string? Descricao { get; set; }

}
