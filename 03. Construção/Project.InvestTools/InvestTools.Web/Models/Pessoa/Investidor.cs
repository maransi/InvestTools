using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using investTools.Web.Utils;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Models.Pessoa;

[Table("Investidor")]
[Index( nameof(CPF),  IsUnique=true )]
public class Investidor  : BaseEntity
{
    [Key]
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    [Column("investidorId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [MaxLength(11, ErrorMessage = "Este Campo de Conter 11 Caracteres")]
    [MinLength(11, ErrorMessage = "Este Campo de Conter 11 Caracteres")]
    [Column("cpf", TypeName = "VARCHAR(11)")]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "Este Campo é Obrigatório")]
    [StringLength(50)]
    [Column("nome", TypeName = "VARCHAR(50)")]
    public string? Nome { get; set; }

    [Precision(15, 2)]
    [Column("renda", TypeName = "DECIMAL(15,2)")]
    public decimal? Renda { get; set; }

    [Precision(15, 2)]
    [Column("aporteMensal", TypeName = "DECIMAL(15,2)")]
    public decimal AporteMensal{ get; set; }
}
