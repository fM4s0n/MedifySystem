namespace MedifySystem.MedifyCommon.Models;

public class Patient : Person
{
    public bool IsCurrentlyAdmitted { get; set; } = false;
}
