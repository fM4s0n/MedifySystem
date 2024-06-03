using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

//<inheritdoc/>
public class PatientService : IPatientService
{
    private readonly IDBService? _dbService = Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;
    private readonly IPatientRecordService? _patientRecordService = Program.ServiceProvider!.GetService(typeof(IPatientRecordService)) as IPatientRecordService;

    //<inheritdoc/>
    public void DeletePatient(Patient patient) => _dbService!.DeleteEntity(patient);

    //<inheritdoc/>
    public List<Patient>? GetAllPatients() => _dbService!.GetEntitiesByType<Patient>()!;

    //<inheritdoc/>
    public Patient? GetPatientById(string id) => _dbService?.GetEntity<Patient>(id);

    //<inheritdoc/>
    public void InsertPatient(Patient patient) => _dbService?.InsertEntity(patient);    

    //<inheritdoc/>
    public void UpdatePatient(Patient patient) => _dbService?.UpdateEntity(patient);

    //<inheritdoc/>
    public List<Patient>? GetActivePatientsByUserId(string userId)
    {
        return _dbService!.GetEntitiesByType<Patient>()?
            .Where(p => p.IsCurrentlyAdmitted()).ToList() ?? null;
    }

    //<inheritdoc/>
    public Patient? AdmitPatient(Patient patient, string hospitalOfficialId, string admissionReason)
    {
        PatientAdmittance admittance = new(patient.Id, DateTime.Now, admissionReason, hospitalOfficialId);
        patient.Admittances.Add(admittance);

        UpdatePatient(patient);
        _patientAdmittanceService?.InsertPatientAdmittance(admittance);

        return patient;
    }

    //<inheritdoc/>
    public Patient? DischargePatient(Patient patient, string patientAdmittanceId, string dischargeReason)
    {
        PatientAdmittance? admittance = patient.Admittances.Find(a => a.Id == patientAdmittanceId);
        int index = patient.Admittances.FindIndex(a => a.Id == patientAdmittanceId);

        if (admittance == null || index == -1)        
            return null;

        // update the patient admittance for the db
        DateTime endDate = DateTime.Now;
        admittance.DischargePatient(dischargeReason, endDate);
        _patientAdmittanceService?.UpdatePatientAdmittance(admittance);

        // update the patient admittance for the patient object
        patient.Admittances[index].DischargePatient(dischargeReason, endDate);
        patient.Admittances[index].EndDate = DateTime.Now; 
        UpdatePatient(patient);

        return patient;
    }

    //<inheritdoc/>
    public PatientRecord? GetPatientRecord(string id)
    {
        Patient? patient = GetPatientById(id);

        if (patient == null)
            return null;

        return _patientRecordService?.GetPatientRecordByPatientId(patient.Id);
    }

}
