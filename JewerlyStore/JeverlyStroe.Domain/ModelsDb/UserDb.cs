using System.ComponentModel.DataAnnotations.Schema;
using JeverlyStroe.Domain.Enum;
namespace JeverlyStroe.Domain.ModelsDb;
[Table( "users")]
public class UserDb
{
    
    [Column("id")]
    public Guid Id { get; set; }
    [Column( "login")]
    public string Login { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("role")]
    public Role Role { get; set; }
    [Column("pathImage")]
    public string PathImage { get; set; }
    [Column("createdAt", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }
}