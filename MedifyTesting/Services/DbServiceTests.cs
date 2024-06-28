using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MedifyTesting.Services;

[TestClass]
public class DbServiceTests
{
    private DBService? _dbService;

    [TestInitialize]
    public void Setup()
    {
        DbContextOptionsBuilder<MedifyDatabaseContext> optionsBuilder = new();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        MedifyDatabaseContext context = new(optionsBuilder.Options);
        _dbService = new DBService(context);
    }
    
    [TestMethod]
    public void InsertEntity_Should_Insert_Entity()
    {
        // Arrange
        Patient patient = new();

        // Act
        _dbService!.InsertEntity(patient);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<Patient>()!.Contains(patient));
    }

    [TestMethod]
    public void DeleteEntity_Should_Delete_Entity()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        _dbService!.DeleteEntity(patient);

        // Assert
        Assert.IsFalse(_dbService!.GetEntitiesByType<Patient>()!.Contains(patient));
    }

    [TestMethod]
    public void GetEntitiesById_Should_Get_Correct_Entities()
    {

       // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        var patients = _dbService!.GetEntitiesById<Patient>(new List<string> { patient.Id });

        // Assert
        Assert.IsTrue(patients!.Contains(patient));
    }

    [TestMethod]
    public void GetEntitiesByType_Should_Return_Entities()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        List<Patient>? patients = _dbService!.GetEntitiesByType<Patient>();

        // Assert
        Assert.IsTrue(patients!.Contains(patient));
    }

    [TestMethod]
    public void GetEntity_Should_Return_Entity()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        Patient? result = _dbService!.GetEntity<Patient>(patient.Id);

        // Assert
        Assert.AreEqual(patient, result);
    }

    [TestMethod]
    public void UpdateEntity_Should_Update_Entity()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        patient.FirstName = "New Name";
        _dbService!.UpdateEntity(patient);

        // Assert
        Assert.AreEqual("New Name", _dbService!.GetEntity<Patient>(patient.Id)!.FirstName);
    }

    [TestMethod]
    public void InsertRange_Should_Insert_All_Entities()
    {
        // Arrange
        Patient patient1 = new();
        Patient patient2 = new();
        List<Patient> patients = new() { patient1, patient2 };

        // Act
        _dbService!.InsertRange(patients);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<Patient>()!.Contains(patient1));
        Assert.IsTrue(_dbService!.GetEntitiesByType<Patient>()!.Contains(patient2));
    }

    [TestCleanup]
    public void Cleanup()
    {
        _dbService = null;
    }
}
