using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancesManager.Operations.Core.Entities;
public class Operation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public bool Earning { get; set; }
    public DateTime EffectedDate { get; set; }
    public float Ammount { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Categories { get; set; } = string.Empty;
}
