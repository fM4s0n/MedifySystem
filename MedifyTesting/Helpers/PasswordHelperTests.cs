using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Helpers;
using Microsoft.AspNetCore.Identity;

namespace MedifyTesting.Helpers;

[TestClass]
public class PasswordHelperTests
{
    [TestMethod]
    public void TestHashPassword_Should_Hash_Password()
    {
        // Arrange
        User user = new();
        string password = "password";

        // Act
        string hashedPassword = PasswordHelper.HashPassword(user, password);

        // Assert
        Assert.IsNotNull(hashedPassword);
        Assert.AreNotEqual(password, hashedPassword);
    }

    [TestMethod]
    public void TestVerifyPassword_Should_Return_Success()
    {
        // Arrange
        User user = new();
        string password = "password";
        string hashedPassword = PasswordHelper.HashPassword(user, password);

        user.PasswordHash = hashedPassword;

        // Act
        PasswordVerificationResult result = PasswordHelper.VerifyPassword(user, password);

        // Assert
        Assert.AreEqual(PasswordVerificationResult.Success, result);
    }

    [TestMethod]
    public void TestVerifyPassword_Should_Return_Failure()
    {
        // Arrange
        User user = new();
        string password = "password";
        string hashedPassword = PasswordHelper.HashPassword(user, password);

        user.PasswordHash = hashedPassword;

        // Act
        PasswordVerificationResult result = PasswordHelper.VerifyPassword(user, "wrongpassword");

        // Assert
        Assert.AreEqual(PasswordVerificationResult.Failed, result);
    }
}
