using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// 
/// </summary>
public partial class FrmBookAppointment : Form
{
    public FrmBookAppointment(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        ArgumentNullException.ThrowIfNull(patient);

        Init();
    }

    private void Init()
    {

    }
}
