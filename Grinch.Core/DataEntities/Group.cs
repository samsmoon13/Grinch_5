using System.ComponentModel.DataAnnotations.Schema;

namespace Grinch.Core.DataEntities;

[Table("Group")]
public class Group : BaseEntity
{
    public string Name { get; set; }

    public string Currency { get; set; }

    public ICollection<GroupUser> GroupUsers { get; set; }
}