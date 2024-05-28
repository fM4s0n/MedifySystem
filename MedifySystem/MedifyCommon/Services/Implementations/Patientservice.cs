using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class PatientService : IPatientService
{
    private readonly IDBService? _dbService = Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;

    //<inheritdoc/>
    public void DeletePatient(Patient patient)
    {
        _dbService!.DeleteEntity(patient);
    }

    //<inheritdoc/>
    public List<Patient>? GetActivePatientsByUserId(string userId)
    {
        return _dbService!.GetEntitiesByType<Patient>()?
            .Where(p => p.IsCurrentlyAdmitted()).ToList() ?? null;
    }

    //<inheritdoc/>
    public List<Patient>? GetAllPatients()
    {
        return _dbService!.GetEntitiesByType<Patient>()!;
    }

    //<inheritdoc/>
    public Patient? GetPatientById(string id)
    {
        return _dbService?.GetEntity<Patient>(id);
    }

    //<inheritdoc/>
    public void InsertPatient(Patient patient)
    {
        _dbService?.InsertEntity(patient);
    }

    //<inheritdoc/>
    public void UpdatePatient(Patient patient)
    {
        _dbService?.UpdateEntity(patient);
    }

    //<inheritdoc/>
    public Patient? AdmitPateint(Patient patient, string hospitalOfficialId, string admissionReason)
    {
        PatientAdmittance admittance = new(patient.Id, DateTime.Now, admissionReason, hospitalOfficialId);
        patient.Admittances.Add(admittance);

        UpdatePatient(patient);
        _patientAdmittanceService?.InsertPatientAdmittance(admittance);

        return patient;
    }
}
