

using System.ComponentModel.DataAnnotations;

namespace Infrastracture.Entities;

public class CategoryEnitity
{

    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
