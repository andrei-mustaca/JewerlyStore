using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class Request:IBaseStorage<RequestDb>
{
    public readonly ApplicationDbContext _context;

    public Request(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(RequestDb requestDb)
    {
        await _context.AddAsync(requestDb);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(RequestDb requestDb)
    {
        _context.Remove(requestDb);
        await _context.SaveChangesAsync();
    }

    public async Task<RequestDb> Get(Guid id)
    {
        return await _context.RequestDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<RequestDb> GetAll()
    {
        return _context.RequestDbs;
    }

    public async Task<RequestDb> Update(RequestDb requestDb)
    {
        _context.RequestDbs.Update(requestDb);
        await _context.SaveChangesAsync();
        return requestDb;
    } 
}