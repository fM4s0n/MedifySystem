using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// 
/// </summary>
public interface IPatientService
{     
    /// <summary>
    /// Get all patients
    /// </summary>
    /// <returns>
    /// List of all patients
    /// </returns>
    List<Patient>? GetAllPatients();

    /// <summary>
    /// Get a patient by their ID
    /// </summary>
    /// <param name="id">The ID of the patient</param>
    /// <returns>
    /// The patient with the given ID
    /// </returns>
    Patient? GetPatientById(string id);

    /// <summary>
    /// Insert a new patient
    /// </summary>
    /// <param name="patient">The patient to insert</param>
    void InsertPatient(Patient patient);

    /// <summary>
    /// Delete a patient
    /// </summary>
    /// <param name="patient">The patient to delete</param>
    void DeletePatient(Patient patient);
}
}
