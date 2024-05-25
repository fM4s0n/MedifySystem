using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class PatientService : IPatientService
{
    private readonly IDBService? _dbService = Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

    //<inheritdoc/>
    public void DeletePatient(Patient patient)
    {
        _dbService!.DeleteEntity(patient);
    }

    //<inheritdoc/>
    public List<Patient>? GetAllPatients()
    {
        return _dbService!.GetEntitiesByType<Patient>()!;
    }

    //<inheritdoc/>
    public Patient? GetPatientById(string id)
    {
        return _dbService?.GetEntity<Patient>(id);
    }

    //<inheritdoc/>
    public void InsertPatient(Patient patient)
    {
        _dbService?.InsertEntity(patient);
    }
}
