using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// Service for the patient model
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

    void UpdatePatient(Patient patient);

    /// <summary>
    /// Retrieve all patients for a given user
    /// </summary>
    /// <param name="userId">user id</param>
    /// <returns>List of active patients for a user</returns>
    List<Patient>? GetActivePatientsByUserId(string userId);

    /// <summary>
    /// Discharges a patient
    /// </summary>
    /// <param name="patient">Patient being discharged</param>
    /// <param name="patientAdmittanceId">if of the relevent admittance</param>
    /// <param name="dischargeReason">reason for being discharged</param>
    /// <returns>Original patient object with updates adnittances property<returns>
    Patient? DischargePatient(Patient patient, string patientAdmittanceId, string dischargeReason);

    /// <summary>
    /// Admit a patient
    /// </summary>
    /// <param name="patient">patient being admitted</param>
    /// <param name="hospitalOfficialId">Id of the HospitalOfficial responsible for the care of the pateint</param>
    /// <param name="admissionReason">reason for the admittance</param>
    /// <returns>Original patient object with updates adnittances property<returns>
    Patient? AdmitPatient(Patient patient, string hospitalOfficialId, string admissionReason);
}
