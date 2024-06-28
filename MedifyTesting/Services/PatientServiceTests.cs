using MedifySystem.MedifyCommon.DataAccess;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MedifyTesting.Services;

[TestClass]
public class PatientServiceTests
{
    private DBService? _dbService;
    private PatientAdmittanceService? _patientAdmittanceService;
    private PatientRecordService? _patientRecordService;
    private PatientService? _patientService;

    [TestInitialize]
    public void Setup()
    {
        DbContextOptionsBuilder<MedifyDatabaseContext> optionsBuilder = new();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        MedifyDatabaseContext context = new(optionsBuilder.Options);
        _dbService = new DBService(context);
        _patientAdmittanceService = new PatientAdmittanceService(_dbService);
        _patientRecordService = new PatientRecordService(_dbService);
        _patientService = new PatientService(_dbService, _patientAdmittanceService, _patientRecordService);
    }

    [TestMethod]
    public void GetAllPatients_Should_Return_All_Patients()
    {
        // Arrange
        Patient patient1 = new();
        _dbService!.InsertEntity(patient1);
        Patient patient2 = new();
        _dbService!.InsertEntity(patient2);

        // Act
        List<Patient>? patients = _patientService!.GetAllPatients();

        // Assert
        Assert.IsTrue(patients!.Contains(patient1));
    }

    [TestMethod]
    public void GetPatientById_Should_Return_Correct_Patient()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        Patient? result = _patientService!.GetPatientById(patient.Id);

        // Assert
        Assert.AreEqual(patient, result);
    }

    [TestMethod]
    public void InsertPatient_Should_Insert_Patient()
    {
        // Arrange
        Patient patient = new();

        // Act
        _patientService!.InsertPatient(patient);

        // Assert
        Assert.IsTrue(_dbService!.GetEntitiesByType<Patient>()!.Contains(patient));
    }

    [TestMethod]
    public void UpdatePatient_Should_Update_Patient()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        patient.FirstName = "John";
        _patientService!.UpdatePatient(patient);

        // Assert
        Assert.AreEqual("John", _dbService!.GetEntity<Patient>(patient.Id)!.FirstName);
    }

    [TestMethod]
    public void GetActivePatientsByUserId_Should_Return_Active_Patients()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        _patientService!.AdmitPatient(patient, "HospitalOfficialId", "AdmissionReason");

        // Act
        List<Patient>? patients = _patientService!.GetActivePatientsByUserId(patient.Id);

        // Assert
        Assert.IsTrue(patients!.Contains(patient));
    }

    [TestMethod]
    public void AdmitPatient_Should_Admit_Patient()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        // Act
        _patientService!.AdmitPatient(patient, "HospitalOfficialId", "AdmissionReason");

        // Assert
        Assert.IsTrue(patient.Admittances.Count > 0);
    }

    [TestMethod]
    public void DischargePatient_Should_Discharge_Patient()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        _patientService!.AdmitPatient(patient, "HospitalOfficialId", "AdmissionReason");

        // Act
        _patientService!.DischargePatient(patient, "HospitalOfficialId", "DischargeReason");

        // Assert
        Assert.IsTrue(patient.IsCurrentlyAdmitted());
    }

    [TestMethod]
    public void GetPatientRecord_Should_Return_Patient_Record()
    {
        // Arrange
        Patient patient = new();
        _dbService!.InsertEntity(patient);

        PatientRecord patientRecord = new(patient.Id);
        _dbService!.InsertEntity(patientRecord);

        // Act
        PatientRecord? actual = _patientService!.GetPatientRecord(patient.Id);

        // Assert
        Assert.AreEqual(patient.Id, actual!.PatientId);
    }

    [TestMethod]
    public void GetPatientByNHSNumber_Should_Return_Patient()
    {
        // Arrange
        Patient patient = new() { NHSNumber = "1234567890" };
        _dbService!.InsertEntity(patient);

        // Act
        Patient? actual = _patientService!.GetPatientByNHSNumber(patient.NHSNumber);

        // Assert
        Assert.AreEqual(patient, actual);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _dbService = null;
        _patientAdmittanceService = null;
        _patientRecordService = null;
        _patientService = null;
    }
}
