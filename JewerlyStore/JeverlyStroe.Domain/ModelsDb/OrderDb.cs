using System.ComponentModel.DataAnnotations.Schema;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("orders")]
public class OrderDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("idUser")]
    public Guid IdUser { get; set; }
    [Column("idProduct")]
    public Guid IdProduct { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("cost")]
    public double Cost { get; set; }
    [Column("createdAt", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }
}