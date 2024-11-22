using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class PicturesProductS:IBaseStorage<PicturesProductDb>
{
    public readonly ApplicationDbContext _context;

    public PicturesProductS(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(PicturesProductDb picturesProductDb)
    {
        await _context.AddAsync(picturesProductDb);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(PicturesProductDb picturesProductDb)
    {
        _context.Remove(picturesProductDb);
        await _context.SaveChangesAsync();
    }

    public async Task<PicturesProductDb> Get(Guid id)
    {
        return await _context.PicturesProductDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<PicturesProductDb> GetAll()
    {
        return _context.PicturesProductDbs;
    }

    public async Task<PicturesProductDb> Update(PicturesProductDb picturesProductDb)
    {
        _context.PicturesProductDbs.Update(picturesProductDb);
        await _context.SaveChangesAsync();
        return picturesProductDb;
    } 
}