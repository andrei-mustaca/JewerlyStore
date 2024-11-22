using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class UserS:IBaseStorage<UserDb>
{
    public readonly ApplicationDbContext _context;

    public UserS(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(UserDb user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(UserDb user)
    {
        _context.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDb> Get(Guid id)
    {
        return await _context.UserDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<UserDb> GetAll()
    {
        return _context.UserDbs;
    }

    public async Task<UserDb> Update(UserDb user)
    {
        _context.UserDbs.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}