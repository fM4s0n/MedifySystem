namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Appiontment for a patient
/// </summary>
public class Appointment
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientId { get; private set; } = string.Empty;
    public DateTime? AppointmentDate { get; private set; } = null;
    public string HospitalOfficialId { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public bool IsCancelled { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime UpdatedDate { get; private set; } = DateTime.Now;
    public bool PateintAttended { get; private set; } = false;

    public Appointment(string patientId, DateTime appointmentDate, string doctorId, string notes)
    {
        PatientId = patientId;
        AppointmentDate = appointmentDate;
        HospitalOfficialId = doctorId;
        Notes = notes;
        CreatedDate = DateTime.Now;
    }

    public Appointment() { }

    public void Cancel()
    {
        IsCancelled = true;
        UpdatedDate = DateTime.Now;
        AppointmentDate = null;
    }

    public void Reschedule(DateTime newAppointmentDate)
    {
        AppointmentDate = newAppointmentDate;
        UpdatedDate = DateTime.Now;
    }
}
