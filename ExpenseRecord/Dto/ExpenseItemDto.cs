using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseRecord.Dto
{
  public class ExpenseItemDto
  {
    [Column("exp_desc")]
    public string? Description { get; set; }
    [Column("exp_type")]
    public string? Type { get; set; }
    [Column("exp_amount")]
    public int Amount { get; set; }
    [Column("exp_date")]
    public DateTime Date { get; set; }
  }
}
