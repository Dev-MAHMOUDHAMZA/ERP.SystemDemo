using Application.IServices;
using ERP.Domain.Entities.Common;

namespace Application.IUnitOfWork;
public interface IUnitOfWork : IDisposable
{
    IServices<Employee> Employees { get; }


    int Complete();
}
