using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services.Implementations;
using MedifySystem.MedifyCommon.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedifyTesting.Services;

[TestClass]  
public class PatientRecordServiceTests
{
    private DBService? _dbService;
    private PatientRecordService? _patientRecordService;

    [TestInitialize]
    public void Setup()
    {
        DbContextOptionsBuilder<MedifyDatabaseContext> optionsBuilder = new();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        MedifyDatabaseContext context = new(optionsBuilder.Options);
        _dbService = new DBService(context);
        _patientRecordService = new PatientRecordService(_dbService);
    }

    [TestMethod]
    public void DeletePatientRecord_Should_Delete_PatientRecord()
    {
        // Arrange
        PatientRecord patientRecord = new("1", "2");

        // Act
        _patientRecordService!.InsertPatientRecord(patientRecord);
        _patientRecordService!.DeletePatientRecord(patientRecord);

        // Assert
        Assert.IsFalse(_dbService!.GetEntitiesByType<PatientRecord>()!.Contains(patientRecord));
    }

    [TestMethod]
    public void GetPatientRecordByPatientId_Should_Get_Correct_PatientRecord()
    {
        // Arrange
        PatientRecord patientRecord = new("1", "2");
        _patientRecordService!.InsertPatientRecord(patientRecord);

        // Act
        PatientRecord? result = _patientRecordService!.GetPatientRecordByPatientId("1");

        // Assert
        Assert.AreEqual(patientRecord, result);
    }

    [TestMethod]
    public void InsertPatientRecord_Should_Insert_PatientRecord()
    {
        // Arrange
        PatientRecord patientRecord = new("1", "2");

        // Act
        _patientRecordService!.InsertPatientRecord(patientRecord);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<PatientRecord>()!.Contains(patientRecord));
    }

    [TestMethod]
    public void UpdatePatientRecord_Should_Update_PatientRecord()
    {
        // Arrange
        PatientRecord patientRecord = new("1", "2");
        _patientRecordService!.InsertPatientRecord(patientRecord);

        // Act
        patientRecord.AdmittanceId = "3";
        _patientRecordService!.UpdatePatientRecord(patientRecord);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<PatientRecord>()!.Contains(patientRecord));
    }
}
