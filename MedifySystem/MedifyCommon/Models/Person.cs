using MedifySystem.MedifyCommon.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedifySystem.MedifyCommon.Models;

/// <summary>
/// Abstract person class - not to be implemented directly
/// </summary>
public abstract class Person()
{    
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;    
    public Gender Gender { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}
