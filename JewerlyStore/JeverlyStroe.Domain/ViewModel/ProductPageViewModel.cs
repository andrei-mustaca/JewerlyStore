namespace JeverlyStroe.Domain.ViewModel;

public class ProductPageViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Cost { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PathImage { get; set; }
    public List<PictureViewModel> PictureViewModels { get; set; }
}

public class PictureViewModel
{
    public string PathImg { get; set; }
}