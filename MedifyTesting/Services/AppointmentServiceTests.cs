
using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MedifyTesting.Services;

[TestClass]
public class AppointmentServiceTests
{
    private DBService? _dbService;
    private AppointmentService? _appointmentService;

    [TestInitialize]
    public void Initialize()
    {
        DbContextOptionsBuilder<MedifyDatabaseContext> optionsBuilder = new();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        MedifyDatabaseContext context = new(optionsBuilder.Options);
        _dbService = new DBService(context);

        _appointmentService = new AppointmentService(_dbService);
    }

    [TestMethod]
    public void DeleteAppointment_Should_Delete_Appointment()
    {
        // Arrange
        Appointment appointment = new();

        // Act
        _appointmentService!.InsertAppointment(appointment);
        _appointmentService!.DeleteAppointment(appointment);

        // Assert
        Assert.IsFalse(_dbService!.GetEntitiesByType<Appointment>()!.Contains(appointment));
    }

    [TestMethod]
    public void GetAllAppointments_Should_Get_All_Appointments()
    {
        // Arrange
        Appointment appointment1 = new();
        _appointmentService!.InsertAppointment(appointment1);

        Appointment appointment2 = new();
        _appointmentService!.InsertAppointment(appointment2);

        // Act
        List<Appointment>? appointments = _appointmentService!.GetAllAppointments();

        // Assert
        Assert.IsTrue(appointments!.Contains(appointment1));
        Assert.IsTrue(appointments!.Contains(appointment2));
        Assert.AreEqual(2, appointments!.Count);
    }

    [TestMethod]
    public void GetAppointmentsByUserId_Should_Get_Correct_Appointments()
    {
        // Arrange
        User user = new() { Role = UserRole.Doctor };

        Appointment appointment1 = new() { HospitalOfficialId = user.Id };
        _appointmentService!.InsertAppointment(appointment1);

        Appointment appointment2 = new() { HospitalOfficialId = user.Id };
        _appointmentService!.InsertAppointment(appointment2);

        Appointment appointment3 = new() { HospitalOfficialId = user.Id };

        // Act
        List<Appointment>? appointments = _appointmentService!.GetAppointmentsByUserId(user.Id);

        // Assert
        Assert.IsTrue(appointments!.Contains(appointment1));
        Assert.IsTrue(appointments!.Contains(appointment2));
        Assert.IsFalse(appointments!.Contains(appointment3));
        Assert.AreEqual(2, appointments!.Count);
    }

    [TestMethod]
    public void GetAppointmentByUserId_Should_Get_Correct_Appointment()
    {
        // Arrange
        Appointment appointment = new();
        _appointmentService!.InsertAppointment(appointment);

        // Act
        Appointment? result = _appointmentService!.GetAppointmentByUserId(appointment.Id);

        // Assert
        Assert.AreEqual(appointment, result);
    }

    [TestMethod]
    public void InsertAppointment_Should_Insert_Appointment()
    {
        // Arrange
        Appointment appointment = new();

        // Act
        _appointmentService!.InsertAppointment(appointment);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<Appointment>()!.Contains(appointment));
    }

    [TestMethod]
    public void UpdateAppointment_Should_Update_Appointment()
    {
        // Arrange
        Appointment appointment = new();
        _appointmentService!.InsertAppointment(appointment);

        // Act
        appointment.Cancel();
        _appointmentService!.UpdateAppointment(appointment);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<Appointment>()!.Contains(appointment));
        Assert.IsTrue(_dbService!.GetEntity<Appointment>(appointment.Id)!.IsCancelled);
    }
}
