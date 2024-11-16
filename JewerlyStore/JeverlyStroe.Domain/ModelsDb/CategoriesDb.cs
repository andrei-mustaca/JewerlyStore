using System.ComponentModel.DataAnnotations.Schema;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("categories")]
public class CategoriesDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("createdAt", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }
    [Column("idImg")]
    public Guid IdImg { get; set; }
}