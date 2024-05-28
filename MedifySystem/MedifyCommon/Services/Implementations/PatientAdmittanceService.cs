using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

///<inheritdoc/>
public class PatientAdmittanceService : IPatientAdmittanceService
{
    private readonly IDBService? _dbService = Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

    //<inheritdoc/>
    public void InsertPatientAdmittance(PatientAdmittance patientAdmittance)
    {
        _dbService?.InsertEntity(patientAdmittance);
    }

    //<inheritdoc/>
    public void DeletePatientAdmittance(PatientAdmittance patientAdmittance)
    {
        _dbService!.DeleteEntity(patientAdmittance);
    }

    //<inheritdoc/>
    public void UpdatePatientAdmittance(PatientAdmittance patientAdmittance)
    {
        _dbService!.UpdateEntity(patientAdmittance);
    }
}
