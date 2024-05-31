using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Forms;
public partial class FrmAdmitPatient : Form
{
    private readonly Patient? _patient;

    public FrmAdmitPatient(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;

        Init();
    }

    private void Init()
    {

    }
}
