using cardscore_api.Data;
using Empfinder.Factories;
using Empfinder.Services;
using Empfinder.Workers;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        });

        builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($"Data Source=db.db"));

        builder.Services.AddTransient<IEmployeeService, EmployeeService>();
        builder.Services.AddTransient<IParserInstructorService, ParserInstructorService>();

        builder.Services.AddSingleton<IYandexMapsParser, YandexMapsParser>();

        builder.Services.AddSingleton<ISeleniumFactory, SeleniumFactory>();

        builder.Services.AddHostedService<ParserWorker>();

        var app = builder.Build();

        app.Run();
    }
}