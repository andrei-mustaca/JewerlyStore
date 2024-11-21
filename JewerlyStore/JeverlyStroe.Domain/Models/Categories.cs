namespace JeverlyStroe.Domain.Models;

public class Categories
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid IdImg { get; set; }
    public List<Product>Products { get; set; }
}