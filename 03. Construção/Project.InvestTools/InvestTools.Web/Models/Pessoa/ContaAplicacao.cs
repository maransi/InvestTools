using investTools.Web.Models.Pessoa;
using investTools.Web.Utils;

namespace investTools.Web.Models.Aplicacao;

public class ContaAplicacao: BaseEntity
{
    public string? NrBanco { get; set; }    

    public string? Banco { get; set; }

    public string? Agencia { get; set; }

    public string? Conta { get; set; }

    public Investidor Investidor { get; set; } = default!;
}
