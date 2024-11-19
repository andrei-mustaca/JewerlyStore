using System.ComponentModel.DataAnnotations.Schema;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("products")]
public class ProductDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("idCategories")]
    public Guid IdCategories { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("cost")]
    public double Cost { get; set; }
    [Column("createdAt", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }
    
    public CategoriesDb Categories { get; set; } 
    public List<PicturesProductDb> PicturesProducts { get; set; }
    
    
}