using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using investTools.Web.Utils;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Models;

[Table("Investidor")]
[Index(nameof(CPF), IsUnique = true)]
// [CheckConstraint("chkInvestidorDatNascPassado",  "dataNascimento < CURDATE()")]
public class Investidor : AuditEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    [Column("dataNascimento", TypeName = "DATE")]
    public DateTime DataNascimento { get; set; }

    [Range(1540, 1000000, ErrorMessage = "Renda deve ser maior que R$ 1.540,00")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Column("renda", TypeName = "DECIMAL(13,2)")]
    [DefaultValue(0)]
    public decimal? Renda { get; set; }

    [Range(1540, 1000000, ErrorMessage = "Salário deve ser maior que R$ 1.540,00")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Column("aporteMensal", TypeName = "DECIMAL(13,2)")]
    [DefaultValue(0)]
    public decimal? AporteMensal { get; set; }

    [Required(ErrorMessage = "E-Mail é obrigatório")]
    [EmailAddress(ErrorMessage = "Invalido endereço de E-Mail")]
    [Column("email", TypeName = "VARCHAR(100)")]
    public string? Email { get; set; }
}
