using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services;
public interface IAppointmentService
{
    void DeleteAppointment(Appointment appointment);
    List<Appointment>? GetAllAppointments();
    Appointment? GetAppointmentByUserId(string id);
    List<Appointment>? GetAppointmentsByUserId(string id);
    void InsertAppointment(Appointment appointment);
    void UpdateAppointment(Appointment appointment);
}