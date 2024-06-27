using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyCommon.Services.Implementations;
using MedifySystem.MedifyCommon.Enums;
using Microsoft.EntityFrameworkCore;
using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Helpers;

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

    [TestMethod]
    public void DeleteUser_Should_Delete_User()
    {
        // Arrange
        User user = new();
        _dbService!.InsertEntity(user);

        // Act
        _userService!.DeleteUser(user);

        // Assert
        Assert.IsNull(_dbService.GetEntity<User>(user.Id));
    }

    [TestMethod]
    public void DeleteUser_Should_Not_Delete_User_If_User_Is_Null()
    {
        // Arrange
        User user = new();
        _dbService!.InsertEntity(user);

        // Act
        _userService!.DeleteUser(null);

        // Assert
        Assert.IsNotNull(_dbService.GetEntity<User>(user.Id));
    }

    [TestMethod]
    public void GetAllUsers_Should_Return_All_Users()
    {
        // Arrange
        User user1 = new();
        User user2 = new();
        User user3 = new();
        _dbService!.InsertEntity(user1);
        _dbService!.InsertEntity(user2);
        _dbService!.InsertEntity(user3);

        // Act
        List<User>? actual = _userService!.GetAllUsers();

        // Assert
        Assert.AreEqual(3, actual!.Count);
        Assert.AreEqual(user1, actual[0]);
        Assert.AreEqual(user2, actual[1]);
        Assert.AreEqual(user3, actual[2]);
    }

    [TestMethod]
    public void GetAllUsers_Should_Return_Empty_List_If_No_Users_Are_Found()
    {
        // Arrange & Act
        List<User>? actual = _userService!.GetAllUsers();

        // Assert
        Assert.AreEqual(0, actual!.Count);
    }

    [TestMethod]
    public void GetUserById_Should_Return_User()
    {
        // Arrange
        User expected = new();
        _dbService!.InsertEntity(expected);

        // Act
        User? actual = _userService!.GetUserById(expected.Id);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetUserById_Should_Return_Null_If_Id_Is_Empty()
    {
        // Arrange
        User expected = new();
        _dbService!.InsertEntity(expected);

        // Act
        User? actual = _userService!.GetUserById(string.Empty);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    public void GetUserById_Should_Return_Null_If_Id_Is_Null()
    {
        // Arrange
        User expected = new();
        _dbService!.InsertEntity(expected);

        // Act
        User? actual = _userService!.GetUserById(null);

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    public void GetUserById_Should_Return_Null_If_Id_Is_Whitespace()
    {
        // Arrange
        User expected = new();
        _dbService!.InsertEntity(expected);

        // Act
        User? actual = _userService!.GetUserById(" ");

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    public void GetUserById_Should_Return_Null_If_User_Is_Not_Found()
    {
        // Arrange
        User expected = new();
        _dbService!.InsertEntity(expected);

        // Act
        User? actual = _userService!.GetUserById(Guid.NewGuid().ToString());

        // Assert
        Assert.IsNull(actual);
    }

    [TestMethod]
    public void InsertUser_Should_Insert_User()
    {
        // Arrange
        User user = new();

        // Act
        _userService!.InsertUser(user);

        // Assert
        Assert.IsNotNull(_dbService!.GetEntity<User>(user.Id));
    }

    [TestMethod]
    public void InsertUser_Should_Throw_Exception_If_User_With_Same_Email_Exists()
    {
        // Arrange
        User user = new();
        _dbService!.InsertEntity(user);

        // Act & Assert
        Assert.ThrowsException<Exception>(() => _userService!.InsertUser(user));
    }

    [TestMethod]
    public void InsertUser_Should_Not_Insert_User_If_User_Is_Null()
    {
        // Arrange
        User user = new();

        // Act
        _userService!.InsertUser(null);

        // Assert
        Assert.IsNull(_dbService!.GetEntity<User>(user.Id));
    }

    [TestMethod]
    public void LogInUser_Should_Log_In_User()
    {
        // Arrange
        User user = new();

        // Act
        _userService!.LogInUser(user);

        // Assert
        Assert.AreEqual(user, _userService.GetCurrentUser());
    }

    [TestMethod]
    public void LogInUser_Should_Not_Log_In_User_If_User_Is_Null()
    {
        // Arrange
        User user = new();

        // Act
        _userService!.LogInUser(null);

        // Assert
        Assert.IsNull(_userService.GetCurrentUser());
    }

    [TestMethod]
    public void LogOutUser_Should_Log_Out_User()
    {
        // Arrange
        User user = new();
        _userService!.LogInUser(user);

        // Act
        _userService!.LogOutUser();

        // Assert
        Assert.IsNull(_userService.GetCurrentUser());
    }

    [TestMethod]
    public void UpdateUser_Should_Update_User()
    {
        // Arrange
        User user = new();
        _dbService!.InsertEntity(user);

        // Act
        user.FirstName = "Test";
        _userService!.UpdateUser(user);

        // Assert
        Assert.AreEqual("Test", _dbService.GetEntity<User>(user.Id)!.FirstName);
    }

    [TestMethod]
    public void UpdateUser_Should_Not_Update_User_If_User_Is_Null()
    {
        // Arrange
        User user = new();
        _dbService!.InsertEntity(user);

        // Act
        _userService!.UpdateUser(null);

        // Assert
        Assert.AreNotEqual("Test", _dbService.GetEntity<User>(user.Id)!.FirstName);
    }

    [TestMethod]
    public void AuthenticateUser_Should_Return_True_If_User_Is_Has_Correct_Password()
    {
        // Arrange
        User user = new();
        user.PasswordHash = PasswordHelper.HashPassword(user, "test");
        _dbService!.InsertEntity(user);

        // Act
        bool actual = _userService!.AuthenticateUser(user.Email, "test");

        // Assert
        Assert.IsTrue(actual);
    }

    [TestMethod]
    public void AuthenticateUser_Should_Return_False_If_User_Is_Has_Incorrect_Password()
    {
        // Arrange
        User user = new();
        user.PasswordHash = PasswordHelper.HashPassword(user, "test");
        _dbService!.InsertEntity(user);

        // Act
        bool actual = _userService!.AuthenticateUser(user.Email, "test1");

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void AuthenticateUser_Should_Return_False_If_User_Is_Null()
    {
        // Arrange
        User user = new();
        user.PasswordHash = PasswordHelper.HashPassword(user, "test");
        _dbService!.InsertEntity(user);

        // Act
        bool actual = _userService!.AuthenticateUser(null, "test");

        // Assert
        Assert.IsFalse(actual);
    }

    [TestCleanup]
    public void TearDown()
    {
        _dbService = null;
    }
}