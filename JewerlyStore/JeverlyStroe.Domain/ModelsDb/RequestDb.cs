using System.ComponentModel.DataAnnotations.Schema;
using JeverlyStroe.Domain.Enum;

namespace JeverlyStroe.Domain.ModelsDb;
[Table("requests")]
public class RequestDb
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("idUser")]
    public Guid IdUser { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("status")]
    public Status Status { get; set; }
    [Column("createdAt", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }
}