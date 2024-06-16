using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyCommon.Services.Implementations;

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
        ApplicationConfiguration.Initialize();

        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        DataSeeder dataSeeder = new();
        dataSeeder.SeedData();

        Application.ThreadException += CatchUnhandledException;

        Application.Run(new FrmMain());
    }

    private static void CatchUnhandledException(object sender, ThreadExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        IUserService? userService = ServiceProvider!.GetService<IUserService>();
        userService?.LogOutUser();
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IUserService, UserService>();
                services.AddSingleton<IPatientService, PatientService>();
                services.AddSingleton<IPatientAdmittanceService, PatientAdmittanceService>();
                services.AddSingleton<IPatientRecordService, PatientRecordService>();
                services.AddSingleton<IAppointmentService, AppointmentService>();
                services.AddDbContext<MedifyDatabaseContext>(options =>
                    options.UseSqlite("Data Source=MedifyDB.db"));
                services.AddSingleton<IDBService>(provider =>
                {
                    var dbContext = provider.GetRequiredService<MedifyDatabaseContext>();
                    return new DBService(dbContext);
                });
            });
    }
}
