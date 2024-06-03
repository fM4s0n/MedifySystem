using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// Patient record service
/// </summary>
public interface IPatientRecordService
{
    void DeletePatientRecord(PatientRecord patientRecord);

    void InsertPatientRecord(PatientRecord patientRecord);

    void UpdatePatientRecord(PatientRecord patientRecord);

    PatientRecord? GetPatientRecordByPatientId(string patientId);
}