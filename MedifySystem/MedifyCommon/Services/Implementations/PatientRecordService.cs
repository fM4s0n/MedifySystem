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
        PatientRecord? record = _dbService?.GetEntitiesByType<PatientRecord>()?
            .Find(p => p.PatientId == patientId);

        if (record == null)
            return null;

        record.DataEntries = SetDataEntries(record.Id) ?? [];

        return record;
    }

    //<inheritdoc/>
    public void InsertPatientRecord(PatientRecord patientRecord) => _dbService?.InsertEntity(patientRecord);

    //<inheritdoc/>
    public void UpdatePatientRecord(PatientRecord patientRecord) => _dbService?.UpdateEntity(patientRecord);

    /// <summary>
    /// Set data entries for a patient record
    /// </summary>
    /// <param name="patientRecordId">PatientRecordId</param>
    /// <returns>List of PatientRecordData entries or null</returns>
    private List<PatientRecordDataEntry>? SetDataEntries(string patientRecordId)
    {
        List<PatientRecordDataEntry>? entries = _dbService?.GetEntitiesByType<PatientRecordDataEntry>()?
            .FindAll(p => p.PatientRecordId == patientRecordId);

        return entries;
    }

}
