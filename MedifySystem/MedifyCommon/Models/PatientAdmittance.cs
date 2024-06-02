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

    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientId { get; private set; } = string.Empty;
    public string HospitalOfficialId { get; private set; } = string.Empty;
    public DateTime? StartDate { get; private set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public string AdmittanceReason { get; private set; } = string.Empty;
    public string? DischargeReason { get; set; } = null;

    public void DischargePatient(string reason, DateTime endDate)
    {
        EndDate = DateTime.Now;
        DischargeReason = reason;
    }
}
