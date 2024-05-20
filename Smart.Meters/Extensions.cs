using Microsoft.EntityFrameworkCore;
using Smart.Meters.Data;

namespace Smart.Meters
{
    public static class Extensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                const int maxRetries = 30;
                const int delayMilliseconds = 5000;

                for (int retry = 0; retry <= maxRetries; retry++)
                {
                    try
                    {

                        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                        context!.Database.Migrate();
                        break; // Successful configuration, exit the loop
                    }
                    catch (Exception)
                    {
                        if (retry == maxRetries)
                        {
                            Console.WriteLine("Max. retries reached");
                            throw; // Retried max number of times, throw the exception
                        }

                        Console.WriteLine($"connection fail {retry}: retrying");
                        Thread.Sleep(delayMilliseconds);
                    }
                }
            }
        }
    }
}
