using TemplateDDD.Domain.Interfaces.Services;

namespace TemplateDDD.WebApi.Worker
{
    public class Worker : BackgroundService
	{
        private readonly IServiceProvider _serviceProvider;

		public Worker(IServiceProvider serviceProvider)
		{
            _serviceProvider = serviceProvider;
		}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using IServiceScope scope = _serviceProvider.CreateScope();
                await scope.ServiceProvider.GetRequiredService<IProcessoService>().Executar();
            }
        }
    }
}

