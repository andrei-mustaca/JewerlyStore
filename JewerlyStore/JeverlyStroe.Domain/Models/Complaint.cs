namespace JeverlyStroe.Domain.Models;

public class Complaint
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdOrders { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
    public Order Order { get; set; }
}