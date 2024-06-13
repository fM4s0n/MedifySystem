using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyCommon.Models;

public class Patient : Person 
{
    public Patient() { }

    public Patient(string firstName, string lastName, string nhsNumber, Gender gender, string gpName, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        NHSNumber = nhsNumber;
        Gender = gender;
        GPName = gpName;
        DateOfBirth = dateOfBirth;
    }

    public DateTime DateOfBirth { get; set; }
    public string GPName { get; set; } = string.Empty;
    public string NHSNumber { get; set; } = string.Empty;
    public List<PatientAdmittance> Admittances { get; set; } = [];

    /// <summary>
    /// Checks if the patient is currently admitted
    /// </summary>
    public bool IsCurrentlyAdmitted()
    {
        if (Admittances == null)
            return false;

        return Admittances?.OrderByDescending(a => a.StartDate)
                           .FirstOrDefault()?.EndDate == null;
    }
}
