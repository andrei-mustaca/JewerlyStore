namespace JeverlyStroe.Domain.ViewModel;

public class ListOfProductViewModel
{
    public List<ProductForListOfProductViewModel>Products { get; set; }
    public Guid IdCategories { get; set; }
}

public class ProductForListOfProductViewModel
{
    public Guid Id { get; set; }
    public Guid IdCategories { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PathImage { get; set; }
}