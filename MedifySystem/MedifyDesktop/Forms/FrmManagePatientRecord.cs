﻿using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyDesktop.Controls;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// Patient record management form.
/// </summary>
public partial class FrmManagePatientRecord : Form
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IPatientRecordService? _patientRecordService = Program.ServiceProvider!.GetService(typeof(IPatientRecordService)) as IPatientRecordService;

    private readonly Patient? _patient;
    private PatientRecord? _patientRecord;

    public FrmManagePatientRecord(Patient patient)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _patient = patient;

        if (_patient == null)
        {
            MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        Init();
    }

    private void Init()
    {
        SetPatientRecord();
        SetPanelItems();
        InitNewEntryTypeComboBox();
        InitFilterComboBox();

        lblPatientName.Text = _patient!.FullName;

        txtData.Focus();
    }

    private void InitNewEntryTypeComboBox()
    {
        cmbNewEntryType.Items.Clear();
        cmbNewEntryType.Items.AddRange(Enum.GetValues(typeof(PatientRecordDataEntryType)).Cast<object>().ToArray());
        cmbNewEntryType.SelectedIndex = 0;
    }

    private void InitFilterComboBox()
    {
        cmbFilterType.Items.Clear();
        cmbFilterType.Items.Add("All");
        cmbFilterType.Items.AddRange(Enum.GetValues(typeof(PatientRecordDataEntryType)).Cast<object>().ToArray());
        cmbFilterType.SelectedIndex = 0;
    }

    private void SetPatientRecord()
    {
        _patientRecord = _patientService!.GetPatientRecord(_patient!.Id);

        if (_patientRecord == null)
        {
            _patientRecord = new(_patient.Id);
            _patientRecordService!.InsertPatientRecord(_patientRecord);
        }
    }

    private void SetPanelItems(string search = "")
    {
        search = search.Trim();

        flpPatientRecordDataEntries.Controls.Clear();

        if (_patientRecord!.DataEntries.Count == 0)
        {
            SetNoDataEntriesLabel();
            return;
        }

        List<PatientRecordDataEntry> filteredDataEntries = [];

        filteredDataEntries = _patientRecord!.DataEntries;

        if (cmbFilterType.SelectedItem is PatientRecordDataEntryType type)
        {
            filteredDataEntries = _patientRecord.DataEntries.Where(d => d.Type == type).ToList();            
        }
        else
        {
           filteredDataEntries = _patientRecord.DataEntries;
        }

        if (filteredDataEntries.Count == 0)
        {
            SetNoDataEntriesLabel();
            return;
        }    

        if (string.IsNullOrWhiteSpace(search) == false)
        {
            filteredDataEntries = filteredDataEntries
                .Where(d => d.Data.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (filteredDataEntries.Count == 0)
        {
            SetNoDataEntriesLabel();
            return;
        }

        for (int i = 0; i < filteredDataEntries.Count; i++)
        {
            PatientRecordDataEntry dataEntry = filteredDataEntries[i];

            CtrPatientRecordDataEntryPanelItem panelItem = new(i, dataEntry);
            flpPatientRecordDataEntries.Controls.Add(panelItem);
        }
    }

    private void SetNoDataEntriesLabel()
    {
        Label label = new()
        {
            Text = "No data entries found.",
            AutoSize = true,
            Font = new Font("Arial", 12, FontStyle.Bold),
            ForeColor = Color.Gray
        };

        flpPatientRecordDataEntries.Controls.Add(label);
    }

    private void btnAddDataEntry_Click(object sender, EventArgs e)
    {
        if (cmbNewEntryType.SelectedItem is PatientRecordDataEntryType type
            && ValidateDataEntry())
        {
            PatientRecordDataEntry dataEntry = new(_patientRecord!.Id, txtData.Text, type, DateTime.Now);

            _patientRecord.DataEntries.Add(dataEntry);

            _patientRecordService!.UpdatePatientRecord(_patientRecord);

            RefreshForm();
        }
    }

    private bool ValidateDataEntry()
    {
        if (string.IsNullOrWhiteSpace(txtData.Text))
        {
            MessageBox.Show("Data field cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private void ClearAddDataEntryGroupBox() => cmbNewEntryType.SelectedIndex = 0;

    private void RefreshForm()
    {
        ClearAddDataEntryGroupBox();

        RefreshPatientRecord();
        _patientRecord!.DataEntries = _patientRecord.DataEntries.OrderByDescending(d => d.EntryDate).ToList();

        flpPatientRecordDataEntries.Controls.Clear();
        SetPanelItems();

        txtData.Text = string.Empty;
        txtSearch.Text = string.Empty;
        cmbNewEntryType.SelectedIndex = 0;
        cmbFilterType.SelectedIndex = 0;

        txtData.Focus();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        txtSearch.Text = txtSearch.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            RefreshForm();
            return;
        }

        SetPanelItems(txtSearch.Text);
    }

    private void btnReset_Click(object sender, EventArgs e) => RefreshForm();

    private void RefreshPatientRecord()
    {
        _patientRecord ??= _patientService!.GetPatientRecord(_patient!.Id);
    }

    private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e) => SetPanelItems(txtSearch.Text);
}
