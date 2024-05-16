namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Data entry for a patient record
/// Cannot be modified once created
/// Generic data entry - data property is to be used by official to enter all relevant data
/// </summary>
public class PatientRecordDataEntry (string patientRecordId, string data)
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientRecordId { get; private set; } = patientRecordId;
    public DateTime EntryDate { get; private set; } = DateTime.Now;
    public string Data { get; private set; } = data; 
}
