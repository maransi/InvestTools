using System.ComponentModel.DataAnnotations;

namespace investTools.Web.ViewModels;

public class CreateInvestidorViewModel
{
    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [MaxLength(11, ErrorMessage = "Este Campo de Conter 11 Caracteres")]
    [MinLength(11, ErrorMessage = "Este Campo de Conter 11 Caracteres")]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [StringLength(50)]
    public string? Nome { get; set; }

    public decimal? Renda { get; set; }

    public decimal AporteMensal { get; set; }

}

