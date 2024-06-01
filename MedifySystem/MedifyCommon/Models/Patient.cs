namespace MedifySystem.MedifyCommon.Models;

public class Patient : Person 
{
    public Patient() { }

    public Patient(string firstName, string lastName, string nhsNumber, string gender, string gpName)
    {
        FirstName = firstName;
        LastName = lastName;
        NHSNumber = nhsNumber;
        Gender = gender;
        GPName = gpName;
    }

    public string GPName { get; set; } = string.Empty;
    public string NHSNumber { get; set; } = string.Empty;
    public List<PatientAdmittance> Admittances { get; set; } = [];

    /// <summary>
    /// Checks if the patient is currently admitted
    /// </summary>
    public bool IsCurrentlyAdmitted()
    {
        return Admittances?.OrderByDescending(a => a.StartDate)
                           .FirstOrDefault()?.EndDate == null;
    }
}
