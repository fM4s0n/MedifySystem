﻿using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyCommon.Services.Implementations;

///<inheritdoc/>
public class PatientAdmittanceService(IDBService? dBService = null) : IPatientAdmittanceService
{
    private readonly IDBService? _dbService = dBService 
        ?? Program.ServiceProvider!.GetService(typeof(IDBService)) as IDBService;

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

    //<inheritdoc/>
    public List<PatientAdmittance>? GetAllPatientAdmittances()
    {
        return _dbService!.GetEntitiesByType<PatientAdmittance>();
    }

    //<inheritdoc/>
    public List<PatientAdmittance>? GetAllPatientAdmittanceByHospitalOfficialId(string hospitalOfficialId)
    {
        return GetAllPatientAdmittances()?
            .Where(pa => pa.HospitalOfficialId == hospitalOfficialId).ToList() ?? null;
    }

    public List<PatientAdmittance>? GetAllAdmittancesForPatient(string patientId)
    {
        return GetAllPatientAdmittances()?
            .FindAll(pa => pa.PatientId == patientId);
    }
}
