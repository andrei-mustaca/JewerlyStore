using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class Categories:IBaseStorage<CategoriesDb>
{
    public readonly ApplicationDbContext _context;

    public Categories(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(CategoriesDb categories)
    {
        await _context.AddAsync(categories);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(CategoriesDb categories)
    {
        _context.Remove(categories);
        await _context.SaveChangesAsync();
    }

    public async Task<CategoriesDb> Get(Guid id)
    {
        return await _context.CategoriesDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<CategoriesDb> GetAll()
    {
        return _context.CategoriesDbs;
    }

    public async Task<CategoriesDb> Update(CategoriesDb categories)
    {
        _context.CategoriesDbs.Update(categories);
        await _context.SaveChangesAsync();
        return categories;
    }
}