using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class CategoriesPictureS:IBaseStorage<CategoriesPictureDb>
{
    public readonly ApplicationDbContext _context;

    public CategoriesPictureS(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(CategoriesPictureDb categoriesPicture)
    {
        await _context.AddAsync(categoriesPicture);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(CategoriesPictureDb categoriesPicture)
    {
        _context.Remove(categoriesPicture);
        await _context.SaveChangesAsync();
    }

    public async Task<CategoriesPictureDb> Get(Guid id)
    {
        return await _context.CategoriesPicturesDb.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<CategoriesPictureDb> GetAll()
    {
        return _context.CategoriesPicturesDb;
    }

    public async Task<CategoriesPictureDb> Update(CategoriesPictureDb categoriesPicture)
    {
        _context.CategoriesPicturesDb.Update(categoriesPicture);
        await _context.SaveChangesAsync();
        return categoriesPicture;
    }
}