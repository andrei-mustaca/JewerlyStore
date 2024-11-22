using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class ProductS:IBaseStorage<ProductDb>
{
    public readonly ApplicationDbContext _context;

    public ProductS(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(ProductDb productDb)
    {
        await _context.AddAsync(productDb);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ProductDb productDb)
    {
        _context.Remove(productDb);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductDb> Get(Guid id)
    {
        return await _context.ProductDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<ProductDb> GetAll()
    {
        return _context.ProductDbs;
    }

    public async Task<ProductDb> Update(ProductDb productDb)
    {
        _context.ProductDbs.Update(productDb);
        await _context.SaveChangesAsync();
        return productDb;
    }  
}