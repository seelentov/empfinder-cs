using cardscore_api.Data;
using Empfinder.Factories;
using Empfinder.Models;
using Empfinder.Services;
using Empfinder.Workers.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Empfinder.Workers;

public class ParserWorker : Worker
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IParserFactory _parserFactory;

    public ParserWorker(
        ILogger<ParserWorker> logger,
        IServiceScopeFactory scopeFactory,
        IParserFactory parserFactory
        ) : base(logger)
    {
        _scopeFactory = scopeFactory;
        _parserFactory = parserFactory;
    }
    override protected async Task Handle()
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var _employeeService = scope.ServiceProvider.GetRequiredService<IEmployeeService>();
            var _instructorService = scope.ServiceProvider.GetRequiredService<IParserInstructorService>();

            var instructors = (await _instructorService.GetAllAsync()).ToList();

            foreach (ParserInstructor instructor in instructors)
            {
                var parser = _parserFactory.Get(instructor.Type);

                List<Employee> employees = parser.GetEmployees(instructor.Url);
            }

        }
    }
}
