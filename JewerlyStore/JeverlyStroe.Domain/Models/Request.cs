using JeverlyStroe.Domain.Enum;

namespace JeverlyStroe.Domain.Models;

public class Request
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdOrder { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public User User { get; set; }
}