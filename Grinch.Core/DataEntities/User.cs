using System.ComponentModel.DataAnnotations.Schema;

namespace Grinch.Core.DataEntities;

[Table("User")]
public class User : BaseEntity
{
    public string UserName { get; set; }

    public ICollection<GroupUser> UserGroups { get; set; }
}