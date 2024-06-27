using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class AppointmentService(IDBService? dBService = null) : IAppointmentService
{
    private readonly IDBService? _dbService = dBService 
        ?? Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

    //<inheritdoc/>
    public void DeleteAppointment(Appointment appointment) => _dbService!.DeleteEntity(appointment);

    //<inheritdoc/>
    public List<Appointment>? GetAllAppointments() => _dbService!.GetEntitiesByType<Appointment>() ?? null;

    //<inheritdoc/>
    public List<Appointment>? GetAppointmentsByUserId(string id) => _dbService!.GetEntitiesByType<Appointment>()?.Where(a => a.Id == id).ToList() ?? null;

    //<inheritdoc/>
    public Appointment? GetAppointmentByUserId(string id) => _dbService?.GetEntity<Appointment>(id) ?? null;

    //<inheritdoc/>
    public void InsertAppointment(Appointment appointment) => _dbService!.InsertEntity(appointment);

    //<inheritdoc/>
    public void UpdateAppointment(Appointment appointment) => _dbService!.UpdateEntity(appointment);
}
