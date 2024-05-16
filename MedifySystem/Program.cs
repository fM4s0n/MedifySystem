using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MedifySystem.MedifyCommon.DataAccess;

namespace MedifySystem;

internal static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();


        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        Application.Run(new FrmMain());
    }

    /// <summary>
    /// WinForms dependency injection code using the following StackOverflow code 
    /// https://stackoverflow.com/questions/70475830/how-to-use-dependency-injection-in-winforms
    /// </summary>
    /// <returns></returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddSingleton<IUserService, UserService>();
                services.AddDbContext<MedifyDatabaseContext>(options =>
                    options.UseSqlite("Data Source=VotifyDB.db"));
                services.AddSingleton<IDbService>(provider =>
                {
                    var dbContext = provider.GetRequiredService<MedifyDatabaseContext>();
                    return new DbService(dbContext);
                });
            });
    }
}