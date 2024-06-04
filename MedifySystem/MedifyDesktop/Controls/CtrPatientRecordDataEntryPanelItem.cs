using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Controls;

/// <summary>
/// Control to display a patient record data entry
/// used in the patient record management form
/// </summary>
public partial class CtrPatientRecordDataEntryPanelItem : UserControl
{
    private readonly PatientRecordDataEntry? _dataEntry;

    private int _listIndex;

    public int ListIndex
    {
        get => _listIndex;
        set
        {
            _listIndex = value;
            BackColor = (value % 2 == 0) ? Color.White : Color.LightGray;
        }
    }

    public CtrPatientRecordDataEntryPanelItem(int listIndex, PatientRecordDataEntry dataEntry)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _listIndex = listIndex;
        _dataEntry = dataEntry;

        Init();
    }

    private void Init()
    {
        lblType.Text = _patientRecordDataEntryTypeNames[_dataEntry!.Type];
        lblDate.Text = _dataEntry.EntryDate.ToLongDateString();
        txtData.Text = _dataEntry.Data;

        SetPictureBox();
    }

    private void SetPictureBox()
    {
        switch (_dataEntry!.Type)
        {
            case PatientRecordDataEntryType.Generic:
                pbTitleImage.IconChar = FontAwesome.Sharp.IconChar.Pen;
                break;

            case PatientRecordDataEntryType.LabResult:
                pbTitleImage.IconChar = FontAwesome.Sharp.IconChar.Flask;
                break;

            case PatientRecordDataEntryType.Prescription:
                pbTitleImage.IconChar = FontAwesome.Sharp.IconChar.PrescriptionBottleAlt;
                break;

            case PatientRecordDataEntryType.Diagnosis:
                pbTitleImage.IconChar = FontAwesome.Sharp.IconChar.Diagnoses;
                break;
        }
    }

    private static readonly Dictionary<PatientRecordDataEntryType, string> _patientRecordDataEntryTypeNames = new()
    {
        { PatientRecordDataEntryType.Generic, "Generic" },
        { PatientRecordDataEntryType.LabResult, "Lab Result" },
        { PatientRecordDataEntryType.Prescription, "Prescription" },
        { PatientRecordDataEntryType.Diagnosis, "Diagnosis" }
    };
}
