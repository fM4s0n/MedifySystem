﻿namespace MedifySystem.MedifyCommon.Models;

public class Patient : Person 
{
    public Patient(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

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
