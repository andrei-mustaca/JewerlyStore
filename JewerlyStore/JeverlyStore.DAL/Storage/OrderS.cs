using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class OrderS:IBaseStorage<OrderDb>
{
    public readonly ApplicationDbContext _context;

    public OrderS(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(OrderDb order)
    {
        await _context.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(OrderDb order)
    {
        _context.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderDb> Get(Guid id)
    {
        return await _context.OrderDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<OrderDb> GetAll()
    {
        return _context.OrderDbs;
    }

    public async Task<OrderDb> Update(OrderDb order)
    {
        _context.OrderDbs.Update(order);
        await _context.SaveChangesAsync();
        return order;
    } 
}