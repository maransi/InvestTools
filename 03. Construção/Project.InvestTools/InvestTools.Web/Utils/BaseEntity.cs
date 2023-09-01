using System.ComponentModel.DataAnnotations.Schema;

namespace investTools.Web.Utils;

public abstract class BaseEntity
{

    private DateTime? _createAt;

    [Column("dataAlteracao", TypeName = "DATETIME")]
    public DateTime? UpdateAt { get; set; }

    [Column("dataInclusao", TypeName = "DATETIME")]
    public DateTime? CreateAt
    {
        get { return _createAt; }
        set { _createAt = (value == null ? DateTime.UtcNow : value); }
    }


}
