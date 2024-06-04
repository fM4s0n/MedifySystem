namespace MedifySystem.MedifyCommon.Enums;

public enum PatientRecordDataEntryType
{
    /// <summary>
    /// Data entry for a patient record
    /// Cannot be modified once created
    /// Generic data entry - data property is to be used by official to enter all relevant data
    /// </summary>
    Generic = 0,
    LabResult = 1,
    AppintmentRecord = 2,
    Prescription = 3,
    Diagnosis = 4
}
