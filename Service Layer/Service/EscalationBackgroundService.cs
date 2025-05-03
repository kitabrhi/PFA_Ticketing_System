using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ticketing_System.Service_Layer.Interfaces;

namespace Ticketing_System.Services
{
    public class EscalationBackgroundService : BackgroundService
    {
        private readonly ILogger<EscalationBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(15); // Check every 15 minutes

        public EscalationBackgroundService(
            ILogger<EscalationBackgroundService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Escalation Background Service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CheckAndEscalateTicketsAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while checking tickets for escalation.");
                }

                await Task.Delay(_interval, stoppingToken);
            }

            _logger.LogInformation("Escalation Background Service is stopping.");
        }

        private async Task CheckAndEscalateTicketsAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var escalationService = scope.ServiceProvider.GetRequiredService<IEscalationRuleService>();
                
                try
                {
                    var ticketsNeedingEscalation = await escalationService.GetTicketsNeedingEscalationAsync();
                    
                    foreach (var ticket in ticketsNeedingEscalation)
                    {
                        try
                        {
                            var escalated = await escalationService.CheckAndEscalateTicketAsync(ticket.TicketID);
                            if (escalated)
                            {
                                _logger.LogInformation($"Successfully escalated ticket #{ticket.TicketID}");
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"Failed to escalate ticket #{ticket.TicketID}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while processing tickets for escalation");
                }
            }
        }
    }
}
