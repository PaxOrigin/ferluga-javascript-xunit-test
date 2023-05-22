using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace RollUpApp.IOC;

public static class Startup
{
    public static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddSingleton<RollUpMethod>();
        });
    }
}
