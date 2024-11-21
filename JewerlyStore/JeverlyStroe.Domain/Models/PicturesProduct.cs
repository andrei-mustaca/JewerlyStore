namespace JeverlyStroe.Domain.Models;

public class PicturesProduct
{
    public Guid Id { get; set; }
    public Guid IdProduct { get; set; }
    public string PathImg { get; set; }
    public Product Product { get; set; }
}