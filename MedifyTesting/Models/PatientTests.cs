using MedifySystem.MedifyCommon.Models;

namespace MedifyTesting.Models;

[TestClass]
public class PatientTests
{
    [TestMethod]
    public void IsCurrentlyAdmitted_Should_Return_True()
    {
        // Arrange
        Patient patient = new() { Admittances = [new() { StartDate = DateTime.Now, EndDate = null }] };

        // Act
        bool result = patient.IsCurrentlyAdmitted();

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsCurrentlyAdmitted_Should_Return_False()
    {
        // Arrange
        Patient patient = new() { Admittances = [new() { StartDate = DateTime.Now, EndDate = DateTime.Now }] };

        // Act
        bool result = patient.IsCurrentlyAdmitted();

        // Assert
        Assert.IsFalse(result);
    }
}
