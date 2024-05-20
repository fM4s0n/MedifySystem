namespace MedifySystem.MedifyCommon.Models;

public class Patient(string firstName, string lastName) : Person (firstName, lastName)
{
    public bool IsCurrentlyAdmitted { get; set; } = false;
}
