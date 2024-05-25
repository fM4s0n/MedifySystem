namespace MedifySystem.MedifyCommon.Models;

public class Patient : Person 
{
    public Patient(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public bool IsCurrentlyAdmitted 
    {
        get 
        {
            if (Admittances?.Count == 0)
                return false;

            PatientAdmittance lastAdmittance = Admittances!.OrderByDescending(a => a.StartDate).First();

            return lastAdmittance.EndDate == null;
        }
    }

    public List<PatientAdmittance> Admittances { get; set; } = [];

    public void AdmitPatient(string hospitalOfficialId, string admissionReason)
    {
        PatientAdmittance admittance = new (Id, DateTime.Now, admissionReason);
    }
}
