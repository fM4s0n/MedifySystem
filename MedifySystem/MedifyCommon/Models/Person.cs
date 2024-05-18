namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Abstract person class - not to be implemented directly
/// </summary>
public abstract class Person(string firstName, string lastName)
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string FullName => $"{FirstName} {LastName}";
}
