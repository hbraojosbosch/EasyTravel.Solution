using EasyTravel.Solution.Contracts.Interfaces;

namespace EasyTravel.Solution.AirportsAndCities.Worker
{
    public class AirportsAndCitiesLoderWorker : BackgroundService
    {
        private readonly ILogger<AirportsAndCitiesLoderWorker> _logger;
        private readonly IServiceProvider _serviceProvider;


        public AirportsAndCitiesLoderWorker(ILogger<AirportsAndCitiesLoderWorker> logger,
                                            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var _airportsAndCityService = scope.ServiceProvider.GetRequiredService<IAirportsAndCityService>();
                    await _airportsAndCityService.SetLocationToMemoryCacheAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching Amadeus data.");
                }

                var nextRun = GetNextRunTime();
                var delay = nextRun - DateTimeOffset.UtcNow;

                _logger.LogInformation("Next run scheduled at: {NextRun}", nextRun);
                
                await Task.Delay(delay, stoppingToken);
            }
        }
        private DateTimeOffset GetNextRunTime()
        {
            var now = DateTimeOffset.UtcNow;
            var next = now.AddMinutes(1);  
            if (next <= now)
            {
                next = now.AddMinutes(1);
            }
            return next;
        }
    }
}
