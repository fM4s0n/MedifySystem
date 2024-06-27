using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyCommon.Services.Implementations;
using MedifySystem.MedifyCommon.Enums;
using Microsoft.EntityFrameworkCore;
using MedifySystem.MedifyCommon.DataAccess;

namespace MedifyTesting.Services;

[TestClass]
public class UserServiceTests
{
    private IDBService? _dbService;
    private IUserService? _userService;
    private IPatientService? _patientService;
    private IPatientAdmittanceService? _patientAdmittanceService;
    private IPatientRecordService? _patientRecordService;

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
        _patientRecordService = new PatientRecordService(_dbService);
        _patientService = new PatientService(_dbService, _patientAdmittanceService, _patientRecordService);
        _userService = new UserService(_dbService, _patientService, _patientAdmittanceService);
    }

    [TestMethod]
    public void GetCurrentUser_Should_Return_Current_User()
    {
        // Arrange
        User expected = new ("Test", UserRole.SystemAdmin, "test", "test", Gender.Male);
        _userService!.LogInUser(expected);

        // Act
        User actual = _userService.GetCurrentUser()!;
        
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetCurrentUser_Should_Return_Null_If_No_User_Is_Logged_In()
    {
        // Arrange & Act
        User? actual = _userService!.GetCurrentUser();
        
        // Assert
        Assert.IsNull(actual);
    }

    [TestCleanup]
    public void TearDown()
    {
        _dbService = null;
    }
}