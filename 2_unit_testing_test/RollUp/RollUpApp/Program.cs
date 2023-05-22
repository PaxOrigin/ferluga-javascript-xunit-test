using RollUpApp.IOC;

namespace RollUpApp;

internal class Program
{
    static void Main(string[] args)
    {
        var host = Startup.CreateHostBuilder().Build();
    }
}