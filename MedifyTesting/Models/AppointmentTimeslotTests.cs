using MedifySystem.MedifyCommon.Models;

namespace MedifyTesting.Models;

[TestClass]
public class AppointmentTimeslotTests
{
    [TestMethod]
    public void ToStringOverride_ReturnsCorrectString()
    {
        // Arrange
        var start = new DateTime(2021, 1, 1, 9, 0, 0);
        var duration = new TimeSpan(0, 30, 0);
        var timeslot = new AppointmentTimeslot(start, duration);

        // Act
        var result = timeslot.ToString();

        // Assert
        Assert.AreEqual("09:00 - 09:30", result);
    }

    [TestMethod]
    public void GetHashCodeOverride_ReturnsCorrectHashCode()
    {
        // Arrange
        var start = new DateTime(2021, 1, 1, 9, 0, 0);
        var duration = new TimeSpan(0, 30, 0);
        var timeslot = new AppointmentTimeslot(start, duration);

        // Act
        var result = timeslot.GetHashCode();

        // Assert
        Assert.AreEqual(HashCode.Combine(start, duration), result);
    }

    [TestMethod]
    public void EqualsOverride_ReturnsTrueForEqualObjects()
    {
        // Arrange
        var start = new DateTime(2021, 1, 1, 9, 0, 0);
        var duration = new TimeSpan(0, 30, 0);
        var timeslot1 = new AppointmentTimeslot(start, duration);
        var timeslot2 = new AppointmentTimeslot(start, duration);

        // Act
        var result = timeslot1.Equals(timeslot2);

        // Assert
        Assert.IsTrue(result);
    }
}
