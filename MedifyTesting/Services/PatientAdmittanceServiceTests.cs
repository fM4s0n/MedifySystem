using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MedifyTesting.Services;

[TestClass]
public class PatientAdmittanceServiceTests
{
    private DBService? _dbService;
    private PatientAdmittanceService? _patientAdmittanceService;

    [TestInitialize]
    public void Setup()
    {
        DbContextOptionsBuilder<MedifyDatabaseContext> optionsBuilder = new();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        MedifyDatabaseContext context = new(optionsBuilder.Options);
        _dbService = new DBService(context);
        _patientAdmittanceService = new PatientAdmittanceService(_dbService);
    }

    [TestMethod]
    public void InsertPatientAdmittance_Should_Insert_PatientAdmittance()
    {
        // Arrange
        PatientAdmittance patientAdmittance = new();

        // Act
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<PatientAdmittance>()!.Contains(patientAdmittance));
    }

    [TestMethod]
    public void DeletePatientAdmittance_Should_Delete_PatientAdmittance()
    {
        // Arrange
        PatientAdmittance patientAdmittance = new();
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance);

        // Act
        _patientAdmittanceService!.DeletePatientAdmittance(patientAdmittance);

        // Assert
        Assert.IsFalse(_dbService!.GetEntitiesByType<PatientAdmittance>()!.Contains(patientAdmittance));
    }

    [TestMethod]
    public void UpdatePatientAdmittance_Should_Update_PatientAdmittance()
    {
        // Arrange
        PatientAdmittance patientAdmittance = new();
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance);

        // Act
        patientAdmittance.HospitalOfficialId = "123";
        _patientAdmittanceService!.UpdatePatientAdmittance(patientAdmittance);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<PatientAdmittance>()!.Contains(patientAdmittance));
    }

    [TestMethod]
    public void GetAllPatientAdmittances_Should_Return_All_PatientAdmittances()
    {
        // Arrange
        PatientAdmittance patientAdmittance1 = new();
        PatientAdmittance patientAdmittance2 = new();
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance1);
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance2);

        // Act
        var patientAdmittances = _patientAdmittanceService!.GetAllPatientAdmittances();

        // Assert
        Assert.IsTrue(patientAdmittances!.Contains(patientAdmittance1));
        Assert.IsTrue(patientAdmittances!.Contains(patientAdmittance2));
    }

    [TestMethod]
    public void GetAllPatientAdmittanceByHospitalOfficialId_Should_Return_All_PatientAdmittances_By_HospitalOfficialId()
    {
        // Arrange
        PatientAdmittance patientAdmittance1 = new() { HospitalOfficialId = "123" };
        PatientAdmittance patientAdmittance2 = new() { HospitalOfficialId = "123" };
        PatientAdmittance patientAdmittance3 = new() { HospitalOfficialId = "456" };
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance1);
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance2);
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance3);

        // Act
        var patientAdmittances = _patientAdmittanceService!.GetAllPatientAdmittanceByHospitalOfficialId("123");

        // Assert
        Assert.IsTrue(patientAdmittances!.Contains(patientAdmittance1));
        Assert.IsTrue(patientAdmittances!.Contains(patientAdmittance2));
        Assert.IsFalse(patientAdmittances!.Contains(patientAdmittance3));
    }

    [TestMethod]
    public void GetAllAdmittancesForPatient_Should_Return_All_Admittances_For_Patient()
    {
        // Arrange
        PatientAdmittance patientAdmittance1 = new() { PatientId = "123" };
        PatientAdmittance patientAdmittance2 = new() { PatientId = "123" };
        PatientAdmittance patientAdmittance3 = new() { PatientId = "456" };
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance1);
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance2);
        _patientAdmittanceService!.InsertPatientAdmittance(patientAdmittance3);

        // Act
        var patientAdmittances = _patientAdmittanceService!.GetAllAdmittancesForPatient("123");

        // Assert
        Assert.IsTrue(patientAdmittances!.Contains(patientAdmittance1));
        Assert.IsTrue(patientAdmittances!.Contains(patientAdmittance2));
        Assert.IsFalse(patientAdmittances!.Contains(patientAdmittance3));
    }
}
