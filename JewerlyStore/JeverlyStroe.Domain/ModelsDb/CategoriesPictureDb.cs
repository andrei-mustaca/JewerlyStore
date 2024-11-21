using System.ComponentModel.DataAnnotations.Schema;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("categoriesPicture")]
public class CategoriesPictureDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("idCategories")]
    public Guid IdCategory { get; set; }
    [Column("pathImg")]
    public string PathImg { get; set; }
    public CategoriesDb Categories { get; set; } 
}