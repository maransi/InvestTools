using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using investTools.Web.Models.Pessoa;
using investTools.Web.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Models.Pessoa;

[Table("contaAplicacao")]
// [Index("idxContaAplicacao_InvestidorId", nameof(InvestidorId))]
public class ContaAplicacao: BaseEntity
{

    [Key]
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    [Column("contaAplicacaoId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [MaxLength(4, ErrorMessage = "Este Campo de Conter 4 Caracteres")]
    [Column("nrBanco", TypeName = "VARCHAR(4)")]
    public string? NrBanco { get; set; }    

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [MaxLength(50, ErrorMessage = "Este Campo de Conter 50 Caracteres")]
    [MinLength(5, ErrorMessage = "Este Campo de Conter 5 Caracteres")]
    [Column("banco", TypeName = "VARCHAR(50)")]
    public string? Banco { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [MaxLength(4, ErrorMessage = "Este Campo de Conter 50 Caracteres")]
    [MinLength(1, ErrorMessage = "Este Campo de Conter 5 Caracteres")]
    [Column("agencia", TypeName = "VARCHAR(4)")]
    public string? Agencia { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [MaxLength(10, ErrorMessage = "Este Campo de Conter 50 Caracteres")]
    [MinLength(5, ErrorMessage = "Este Campo de Conter 5 Caracteres")]
    [Column("conta", TypeName = "VARCHAR(4)")]
    public string? Conta { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [Column("digitoConta", TypeName = "CHAR(1)")]
    public string? digitoConta { get; set; }

    [Column("InvestidorId", TypeName="INTEGER")]
    public int InvestidorId{ get;set; }

    [ForeignKey("InvestidorId")]
    public Investidor Investidor { get; set; } = default!;
}
