namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Appointment for a patient
/// </summary>
public class Appointment
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string PatientId { get; private set; } = string.Empty;
    public DateTime StartDate { get; private set; } = DateTime.Now;
    public TimeSpan Duration { get; private set; } = TimeSpan.FromMinutes(60);
    public DateTime EndDate => StartDate.Add(Duration);
    public string HospitalOfficialId { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public bool IsCancelled { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public DateTime UpdatedDate { get; private set; } = DateTime.Now;
    public bool PatientAttended { get; private set; } = false;

    public Appointment(string patientId, DateTime appointmentStartDate, TimeSpan duration, string doctorId, string notes)
    {
        PatientId = patientId;
        StartDate = appointmentStartDate;
        Duration = duration;
        HospitalOfficialId = doctorId;
        Notes = notes;
        CreatedDate = DateTime.Now;
    }

    public Appointment() { }

    public void Cancel()
    {
        IsCancelled = true;
        UpdatedDate = DateTime.Now;
        PatientAttended = false;
    }

    public void ConfirmAttendance()
    {
        PatientAttended = true;
        UpdatedDate = DateTime.Now;
    }

    public void Reschedule(DateTime newAppointmentDate)
    {
        StartDate = newAppointmentDate;
        UpdatedDate = DateTime.Now;
    }
}
