using System;

namespace Empfinder.Workers.Abstract;

interface IWorker : IHostedService
{

}

public abstract class Worker : IWorker
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    abstract protected Task Handle();

    public Task StartAsync(CancellationToken cancellationToken)
    {

        Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Handle();
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message, LogLevel.Error);
                }
            }
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }


}
