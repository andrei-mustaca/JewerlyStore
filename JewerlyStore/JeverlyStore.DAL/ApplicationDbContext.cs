using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using JeverlyStroe.Domain.ModelsDb;

namespace JeverlyStore.DAL;

public class ApplicationDbContext:DbContext
{
    public DbSet<UserDb>UserDbs { get; set; }
    public DbSet<RequestDb>RequestDbs { get; set; }
    public DbSet<ProductDb>ProductDbs { get; set; }
    public DbSet<PicturesProductDb>PicturesProductDbs { get; set; }
    public DbSet<OrderDb>OrderDbs { get; set; }
    public DbSet<ComplaintDb>ComplaintDbs { get; set; }
    public DbSet<CategoriesDb>CategoriesDbs { get; set; }
    protected readonly IConfiguration Configuration;

   

     

    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    
}