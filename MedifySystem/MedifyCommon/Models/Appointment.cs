namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Appointment for a patient
/// </summary>
public class Appointment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string PatientId { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(60);
    public DateTime EndDate => StartDate.Add(Duration);
    public string HospitalOfficialId { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public bool IsCancelled { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public bool PatientAttended { get; set; } = false;

    public Appointment(string patientId, DateTime appointmentStartDateTime, TimeSpan duration, string doctorId, string notes)
    {
        PatientId = patientId;
        StartDate = appointmentStartDateTime;
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
