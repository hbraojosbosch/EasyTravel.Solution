using EasyTravel.Solution.Contracts.Interfaces;

namespace EasyTravel.Solution.AirportsAndCities.Worker
{
    public class AirportsAndCitiesLoderWorker : BackgroundService
    {
        private readonly ILogger<AirportsAndCitiesLoderWorker> _logger;
        private readonly IAirportsAndCityService _airportsAndCityService;

        public AirportsAndCitiesLoderWorker(ILogger<AirportsAndCitiesLoderWorker> logger, IAirportsAndCityService airportsAndCityService)
        {
            _logger = logger;
            _airportsAndCityService = airportsAndCityService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _airportsAndCityService.SetLocationToMemoryCacheAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching Amadeus data.");
                }

                var nextRun = GetNextRunTime();
                var delay = nextRun - DateTimeOffset.Now;

                _logger.LogInformation("Next run scheduled at: {NextRun}", nextRun);
                await Task.Delay(delay, stoppingToken);
            }
        }
        private DateTimeOffset GetNextRunTime()
        {
            var now = DateTimeOffset.Now;
            var next = now.Date.AddDays(7 - (int)now.DayOfWeek + (int)DayOfWeek.Monday).AddHours(2); // Next Monday at 2 AM
            if (next <= now)
            {
                next = next.AddDays(7);
            }
            return next;
        }
    }
}
