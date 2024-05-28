using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services;

/// <summary>
/// 
/// </summary>
public interface IPatientAdmittanceService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientAdmittance"></param>
    void DeletePatientAdmittance(PatientAdmittance patientAdmittance);
    List<PatientAdmittance>? GetAllPatientAdmittances();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientAdmittance"></param>
    void InsertPatientAdmittance(PatientAdmittance patientAdmittance);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientAdmittance"></param>
    void UpdatePatientAdmittance(PatientAdmittance patientAdmittance);
}