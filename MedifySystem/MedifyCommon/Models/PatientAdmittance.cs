namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// 
/// </summary>
/// <param name="patientId"></param>
/// <param name="startDate"></param>
/// <param name="reason"></param>
public class PatientAdmittance (string patientId, DateTime startDate, string reason)
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientId { get; private set; } = patientId;
    public DateTime StartDate { get; private set; } = startDate;
    public DateTime? EndDate { get; private set; } = null;
    public string Reason { get; private set; } = reason;
}
