using MedifySystem.MedifyCommon.Models;

namespace MedifyTesting.Models;

[TestClass]
public class AppointmentTests
{
    [TestMethod]
    public void Cancel_Should_Set_IsCancelled_To_True()
    {
        // Arrange
        Appointment appointment = new() { IsCancelled = false };

        // Act
        appointment.Cancel();

        // Assert
        Assert.IsTrue(appointment.IsCancelled);
    }

    [TestMethod]
    public void ConfirmAttendance_Should_Set_PatientAttended_To_True()
    {
        // Arrange
        Appointment appointment = new() { PatientAttended = false };

        // Act
        appointment.ConfirmAttendance();

        // Assert
        Assert.IsTrue(appointment.PatientAttended);
    }

    [TestMethod]
    public void Reschedule_Should_Set_StartDate()
    {
        // Arrange
        Appointment appointment = new() { StartDate = DateTime.Now };
        DateTime newAppointmentDate = DateTime.Now.AddDays(1);

        // Act
        appointment.Reschedule(newAppointmentDate);

        // Assert
        Assert.AreEqual(newAppointmentDate, appointment.StartDate);
    }
}
