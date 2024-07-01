using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Enums;

namespace MedifyTesting.Models;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void IsHospitalOfficial_Should_Return_True()
    {
        // Arrange
        User? receptionist = new() { Role = UserRole.Receptionist };
        User? doctor = new() { Role = UserRole.Doctor };
        User? nurse = new() { Role = UserRole.Nurse };

        // Act
        bool result1 = receptionist.IsHospitalOfficial();
        bool result2 = doctor.IsHospitalOfficial();
        bool result3 = nurse.IsHospitalOfficial();

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
    }

    [TestMethod]
    public void IsHospitalOfficial_Should_Return_False()
    {
        // Arrange
        User? user = new() { Role = UserRole.SystemAdmin };

        // Act
        var result = user.IsHospitalOfficial();

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsDoctorOrNurse_Should_Return_True()
    {
        // Arrange
        User? doctor = new() { Role = UserRole.Doctor };
        User? nurse = new() { Role = UserRole.Nurse };

        // Act
        bool result1 = doctor.IsDoctorOrNurse();
        bool result2 = nurse.IsDoctorOrNurse();

        // Assert
        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
    }

    [TestMethod]
    public void IsDoctorOrNurse_Should_Return_False()
    {
        // Arrange
        User? user = new() { Role = UserRole.SystemAdmin };

        // Act
        bool result = user.IsDoctorOrNurse();

        // Assert
        Assert.IsFalse(result);
    }
}
