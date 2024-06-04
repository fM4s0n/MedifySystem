using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Data entry for a patient record
/// Cannot be modified once created
/// Generic data entry - data property is to be used by official to enter all relevant data
/// </summary>
public class PatientRecordDataEntry
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientRecordId { get; private set; } = string.Empty;
    public DateTime EntryDate { get; private set; }
    public string Data { get; private set; } = string.Empty; 
    public PatientRecordDataEntryType Type { get; private set; } = PatientRecordDataEntryType.Generic;

    public PatientRecordDataEntry() { }

    public PatientRecordDataEntry(string patientRecordId, string data, PatientRecordDataEntryType type, DateTime entryDate)
    {
        PatientRecordId = patientRecordId;
        Data = data;
        Type = type;
        EntryDate = entryDate;
    }
}
