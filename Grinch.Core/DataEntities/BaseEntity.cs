using System.ComponentModel.DataAnnotations;

namespace Grinch.Core.DataEntities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }
}