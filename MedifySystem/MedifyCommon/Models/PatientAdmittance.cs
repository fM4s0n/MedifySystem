namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// 
/// </summary>
/// <param name="patientId"></param>
/// <param name="startDate"></param>
/// <param name="reason"></param>
public class PatientAdmittance
{
    public PatientAdmittance() { }

    public PatientAdmittance(string patientId, DateTime startDate, string reason, string hospitalOfficialId)
    {
        PatientId = patientId;
        StartDate = startDate;
        Reason = reason;
        HospitalOfficialId = hospitalOfficialId;
    }

    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientId { get; private set; } = string.Empty;
    public string HospitalOfficialId { get; private set; } = string.Empty;
    public DateTime? StartDate { get; private set; } = null;
    public DateTime? EndDate { get; private set; } = null;
    public string Reason { get; private set; } = string.Empty;
}
