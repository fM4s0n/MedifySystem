namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Abstract person class - not to be implemented directly
/// </summary>
public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
}
