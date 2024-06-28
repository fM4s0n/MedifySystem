using System.ComponentModel.DataAnnotations.Schema;

namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// 
/// </summary>
public class PatientRecord(string patientId, string admittanceId = "")
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string PatientId { get; set; } = patientId;
    public string AdmittanceId { get; set; } = admittanceId;

    [NotMapped]
    public List<PatientRecordDataEntry> DataEntries { get; set; } = [];
}
