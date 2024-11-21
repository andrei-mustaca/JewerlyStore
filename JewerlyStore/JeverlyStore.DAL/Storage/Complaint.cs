using JeverlyStore.DAL.Interfaces;
using JeverlyStroe.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace JeverlyStore.DAL.Storage;

public class Complaint:IBaseStorage<ComplaintDb>
{
    public readonly ApplicationDbContext _context;

    public Complaint(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(ComplaintDb complaintDb)
    {
        await _context.AddAsync(complaintDb);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ComplaintDb complaintDb)
    {
        _context.Remove(complaintDb);
        await _context.SaveChangesAsync();
    }

    public async Task<ComplaintDb> Get(Guid id)
    {
        return await _context.ComplaintDbs.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<ComplaintDb> GetAll()
    {
        return _context.ComplaintDbs;
    }

    public async Task<ComplaintDb> Update(ComplaintDb complaintDb)
    {
        _context.ComplaintDbs.Update(complaintDb);
        await _context.SaveChangesAsync();
        return complaintDb;
    } 
}