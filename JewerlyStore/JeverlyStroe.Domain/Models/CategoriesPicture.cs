namespace JeverlyStroe.Domain.Models;

public class CategoriesPicture
{
    public Guid Id { get; set; }
    public Guid IdCategory { get; set; }
    public string PathImg { get; set; }
    public List<Categories>Categories { get; set; }
}