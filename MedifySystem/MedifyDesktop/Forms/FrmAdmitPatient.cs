using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;
public partial class FrmAdmitPatient : Form
{
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;

    private readonly Patient? _patient;

    public FrmAdmitPatient(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        if (patient == null)
        {
            MessageBox.Show("Patient not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        _patient = patient;

        Init();
    }

    private void Init()
    {
        if (_patient!.IsCurrentlyAdmitted())
        {
            MessageBox.Show("Patient is already admitted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        lblPatientName.Text = _patient.FullName;
        dtpAdmittance.MaxDate = DateTime.Now;
    }
}
