namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// 
/// </summary>
public class PatientAdmittance
{
    public PatientAdmittance() { }

    public PatientAdmittance(string patientId, DateTime startDate, string reason, string hospitalOfficialId)
    {
        PatientId = patientId;
        StartDate = startDate;
        AdmittanceReason = reason;
        HospitalOfficialId = hospitalOfficialId;
    }

    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string PatientId { get; set; } = string.Empty;
    public string HospitalOfficialId { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public string AdmittanceReason { get; set; } = string.Empty;
    public string? DischargeReason { get; set; } = null;

    public void DischargePatient(string reason, DateTime endDate)
    {
        EndDate = endDate;
        DischargeReason = reason;
    }
}
