using System.ComponentModel.DataAnnotations.Schema;

namespace Grinch.Core.DataEntities;

public class Expense : BaseEntity
{
    public string PaidFor { get; set; }

    [ForeignKey("GroupUserId")] public GroupUser GroupUser { get; set; }

    public int GroupUserId { get; set; }

    public decimal Amount { get; set; }
}