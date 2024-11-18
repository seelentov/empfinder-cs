using System.Linq.Expressions;
using cardscore_api.Data;
using Empfinder.Models;
using Microsoft.EntityFrameworkCore;

namespace Empfinder.Services;

public interface IParserInstructorService : IEntityGetter<ParserInstructor>
{

}
public class ParserInstructorService : IParserInstructorService
{
    private readonly DataContext _dbContext;
    public ParserInstructorService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ParserInstructor?> GetAsync(Expression<Func<ParserInstructor, bool>> predicate)
    {
        return await _dbContext.ParserInstructors.FirstOrDefaultAsync(predicate);
    }

    public async Task<ParserInstructor?> GetByIdAsync(int id)
    {
        return await GetAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<ParserInstructor>> GetRangeAsync(Expression<Func<ParserInstructor, bool>> predicate)
    {
        return await _dbContext.ParserInstructors.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<ParserInstructor>> GetAllAsync()
    {
        return await _dbContext.ParserInstructors.ToListAsync();
    }
}
