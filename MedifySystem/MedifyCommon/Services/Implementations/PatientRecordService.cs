using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class PatientRecordService : IPatientRecordService
{
    private readonly IDBService? _dbService = Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

    //<inheritdoc/>
    public void DeletePatientRecord(PatientRecord patientRecord) => _dbService!.DeleteEntity(patientRecord);

    //<inheritdoc/>
    public PatientRecord? GetPatientRecordByPatientId(string patientId)
    {
        return _dbService?.GetEntitiesByType<PatientRecord>()?
            .Find(p => p.PatientId == patientId);
    }

    //<inheritdoc/>
    public void InsertPatientRecord(PatientRecord patientRecord) => _dbService?.InsertEntity(patientRecord);

    //<inheritdoc/>
    public void UpdatePatientRecord(PatientRecord patientRecord) => _dbService?.UpdateEntity(patientRecord);

}
