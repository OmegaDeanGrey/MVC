// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using Liberation.Models;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// public class DatabasePollerService : BackgroundService
// {
//     private readonly IServiceProvider _serviceProvider;
//     private readonly ILogger<DatabasePollerService> _logger;
//     private readonly TimeSpan _pollingInterval = TimeSpan.FromMinutes(1); // Adjust as needed

    

//     public DatabasePollerService(IServiceProvider serviceProvider, ILogger<DatabasePollerService> logger)
//     {
//         _serviceProvider = serviceProvider;
//         _logger = logger;
//     }

//     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//     {
//         while (!stoppingToken.IsCancellationRequested)
//         {
//             try
//             {
//                 // Use a new scope to get a fresh DbContext instance
//                 using (var scope = _serviceProvider.CreateScope())
//                 {
//                     var dbContext = scope.ServiceProvider.GetRequiredService<LiberationDbContext>();

//                     // Example: check for pending records
//                     var pendingNotes = await dbContext.Notes
//                     .Where(note => note.Status == "Pending")
//                     .ToListAsync(stoppingToken);

// foreach (var note in pendingNotes)
// {
//     note.Status = "Processed";
// }

// await dbContext.SaveChangesAsync(stoppingToken);

//                 }
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "An error occurred while polling the database.");
//             }

//             // Wait until the next polling interval
//             await Task.Delay(_pollingInterval, stoppingToken);
//         }
//     }
// }
