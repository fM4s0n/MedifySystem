using MedifySystem.MedifyCommon.Models;

namespace MedifyTesting.Models;

[TestClass]
public class PatientAdmittanceTests
{
    [TestMethod]
    public void DischargePatient_Should_Set_EndDate_And_DischargeReason()
    {
        // Arrange
        PatientAdmittance admittance = new() { PatientId = "1", StartDate = DateTime.Now, AdmittanceReason = "Test", HospitalOfficialId = "1" };
        string reason = "Test";
        DateTime endDate = DateTime.Now;

        // Act
        admittance.DischargePatient(reason, endDate);

        // Assert
        Assert.AreEqual(reason, admittance.DischargeReason);
        Assert.AreEqual(endDate, admittance.EndDate);
    }
}
