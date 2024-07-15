using MedifySystem.MedifyCommon.Models;

namespace MedifyTesting.Models;

[TestClass]
public class AppointmentTimeslotTests
{
    [TestMethod]
    public void ToStringOverride_ReturnsCorrectString()
    {
        // Arrange
        DateTime start = new(2024, 1, 1, 9, 0, 0);
        TimeSpan duration = new(1, 0, 0);
        AppointmentTimeslot timeslot = new(start, duration);

        // Act
        var result = timeslot.ToString();

        // Assert
        Assert.AreEqual("09:00 - 10:00", result);
    }

    [TestMethod]
    public void GetHashCodeOverride_ReturnsCorrectHashCode()
    {
        // Arrange
        DateTime start = new(2024, 1, 1, 9, 0, 0);
        TimeSpan duration = new(1, 0, 0);
        AppointmentTimeslot timeslot = new(start, duration);

        // Act
        var result = timeslot.GetHashCode();

        // Assert
        Assert.AreEqual(HashCode.Combine(start, duration), result);
    }

    [TestMethod]
    public void EqualsOverride_ReturnsTrueForEqualObjects()
    {
        // Arrange
        DateTime start = new(2024, 1, 1, 9, 0, 0);
        TimeSpan duration = new(1, 0, 0);
        AppointmentTimeslot timeslot1 = new(start, duration);
        AppointmentTimeslot timeslot2 = new(start, duration);

        // Act
        var result = timeslot1.Equals(timeslot2);

        // Assert
        Assert.IsTrue(result);
    }
}
