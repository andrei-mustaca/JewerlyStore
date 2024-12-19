namespace JeverlyStroe.Domain;

public class ProductFilter
{
    public Guid IdProduct { get; set; }
    public double PriceMax { get; set; }
    public double PriceMin { get; set; }
}