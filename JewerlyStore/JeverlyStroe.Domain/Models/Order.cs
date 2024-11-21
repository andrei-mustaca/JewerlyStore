namespace JeverlyStroe.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdProduct { get; set; }
    public Guid IdRequest { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Product>Product { get; set; }
    public User User { get; set; }
    public Request Request { get; set; }
}