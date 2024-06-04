
using MedifySystem.MedifyCommon.Models;

namespace MedifySystem.MedifyDesktop.Controls;
public partial class CtrPatientRecordDataEntryPanelItem : UserControl
{
    private readonly PatientRecordDataEntry? _dataEntry;

    private int _listIndex
    {
        set
        {
            _listIndex = value;

            if (int.IsEvenInteger(value))
                BackColor = Color.White;
            else
                BackColor = Color.LightGray;
        }
    }

    public CtrPatientRecordDataEntryPanelItem(int listIndex, PatientRecordDataEntry dataEntry)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _listIndex = listIndex;
        _dataEntry = dataEntry;
    }
}
