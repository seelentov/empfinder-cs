using System.Linq.Expressions;
using cardscore_api.Data;
using Empfinder.Models;
using Microsoft.EntityFrameworkCore;

namespace Empfinder.Services;

public interface IEmployeeService : IEntityGetter<Employee>, IEntitySetter<Employee>
{

}

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _dbContext;
    public EmployeeService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Employee?> GetAsync(Expression<Func<Employee, bool>> predicate)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(predicate);
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await GetAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetRangeAsync(Expression<Func<Employee, bool>> predicate)
    {
        return await _dbContext.Employees.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task RemoveAsync(Expression<Func<Employee, bool>> predicate)
    {
        var data = await _dbContext.Employees.FirstOrDefaultAsync(predicate);
        if (data != null)
        {
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveRangeAsync(Expression<Func<Employee, bool>> predicate)
    {
        var data = await _dbContext.Employees.Where(predicate).ToListAsync();
        if (data != null)
        {
            _dbContext.RemoveRange(data);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task AddAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Expression<Func<Employee, bool>> predicate, Employee employee)
    {
        var data = await _dbContext.Employees.Where(predicate).ToListAsync();
        if (data.Any())
        {
            foreach (var item in data)
            {
                _dbContext.Entry(item).CurrentValues.SetValues(employee);
            }
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateOrAddAsync(Expression<Func<Employee, bool>> predicate, Employee employee)
    {
        var data = await _dbContext.Employees.FirstOrDefaultAsync(predicate);
        if (data != null)
        {
            _dbContext.Entry(data).CurrentValues.SetValues(employee);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}

