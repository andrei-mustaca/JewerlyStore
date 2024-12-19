using System.ComponentModel.DataAnnotations.Schema;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("pictures_product")]
public class PicturesProductDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("idProduct")]
    public Guid IdProduct { get; set; }
    [Column("pathImg")]
    public string PathImg { get; set; }
    //public ProductDb Product { get; set; }
}