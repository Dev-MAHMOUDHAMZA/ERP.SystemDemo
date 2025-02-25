
using Application.IServices;
using Application.IUnitOfWork;
using ERP.Domain.Entities.Common;
using ERP.Infrastructure.Data;
using ERP.Infrastructure.Services;



namespace ERP.Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IServices<Employee> Employees { get; private set; }



    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Employees = new ServicesGeneric<Employee>(_context);
        
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}