using System.ComponentModel.DataAnnotations.Schema;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("complaints")]
public class ComplaintDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("idUser")]
    public Guid IdUser { get; set; }
    [Column("idOrders")]
    public Guid IdOrders { get; set; }
    [Column("description")]
    public string Description { get; set; }
}