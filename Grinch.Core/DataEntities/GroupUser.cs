namespace Grinch.Core.DataEntities;

using System.ComponentModel.DataAnnotations.Schema;

public class GroupUser : BaseEntity
{
    [ForeignKey("GroupId")] public Group Group { get; set; }

    public int GroupId { get; set; }

    [ForeignKey("UserId")] public User User { get; set; }

    public int UserId { get; set; }

    public ICollection<Expense>? Expenses { get; set; }
}