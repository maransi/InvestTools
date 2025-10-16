using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace investTools.Web.Utils;

public abstract class AuditEntity
{

    [Column("dataInclusao", TypeName = "DATETIME")]
    // [DefaultValue("current_timestamp")]
    // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? DataInclusao { get; set; }


    [Column("dataAlteracao", TypeName = "DATETIME")]
    public DateTime? DataAlteracao { get; set; }
}

