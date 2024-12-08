namespace JeverlyStroe.Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    public Guid IdCategories { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PathImage { get; set; }
    
   // public Categories Categories { get; set; } 
    //public List<PicturesProduct> PicturesProducts { get; set; }
}