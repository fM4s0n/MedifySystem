namespace MedifySystem.MedifyCommon.Models;

public class Patient : Person 
{
    public Patient(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public bool IsCurrentlyAdmitted { get; set; } = false;
}
