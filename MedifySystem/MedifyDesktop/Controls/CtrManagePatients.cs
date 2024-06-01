﻿using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyDesktop.Forms;

namespace MedifySystem.MedifyDesktop.Controls;
public partial class CtrManagePatients : UserControl
{
    private readonly IPatientService? _patientService = Program.ServiceProvider!.GetService(typeof(IPatientService)) as IPatientService;
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    private readonly IPatientAdmittanceService? _patientAdmittanceService = Program.ServiceProvider!.GetService(typeof(IPatientAdmittanceService)) as IPatientAdmittanceService;

    private readonly List<Patient> _allPatients = [];
    private readonly List<User> _allHospitalOfficials = [];

    public CtrManagePatients()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _allPatients = _patientService!.GetAllPatients() ?? [];

        Init();
    }

    private void Init()
    {
        InitListView();
        InitGenderComboBox();
    }

    private void InitGenderComboBox()
    {
        foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            cmbGender.Items.Add(gender);

        cmbGender.SelectedIndex = -1;
    }

    private void InitListView()
    {
        lvPatients.Columns.Add("Full Name");
        lvPatients.Columns.Add("Assigned Hospital Official");
    }

    private void btnShowAll_Click(object sender, EventArgs e)
    {

    }

    private void btnSearch_Click(object sender, EventArgs e)
    {

    }

    private void btnViewPatientDetails_Click(object sender, EventArgs e)
    {
        if (lvPatients.SelectedItems.Count == 0)
            MessageBox.Show("Please select a patient to view details", "No patient selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        Patient? selectedPatient = (Patient)lvPatients.SelectedItems[0].Tag;

        if (selectedPatient == null)
            return;


    }

    private void btnRegisterPatient_Click(object sender, EventArgs e)
    {
        if (ValidateNewPatientFields())
        {
            Gender? gender = GetGenderFromComboBox()!;
            string genderString;

            if (gender == Gender.NonBinary)
            {
                genderString = txtGender.Text;
            }
            else
            {
                genderString = gender.ToString()!;
            }

            Patient newPatient = new(txtFirstName.Text, txtLastName.Text, txtNHSNumber.Text, genderString);

            _patientService!.InsertPatient(newPatient);
        }
    }

    private bool ValidateNewPatientFields()
    {
        foreach (TextBox tb in new[] { txtFirstName, txtLastName, txtNHSNumber })
        {
            tb.Text = tb.Text.Trim();

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Please fill in all fields", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        if (ValidateGender() == false)
            return false;

        return true;
    }

    private bool ValidateGender()
    {
        Gender? gender = GetGenderFromComboBox();

        if (gender == null)
        {
            MessageBox.Show("Please select a gender", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (gender == Gender.NonBinary)
        {
            txtGender.Text = txtGender.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtGender.Text))
            {
                MessageBox.Show("Please specify Patient's gender", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        return true;
    }

    private void btnClearNewPatient_Click(object sender, EventArgs e) => ClearNewPatientFields();

    private void ClearNewPatientFields()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
    }

    private void btnAdmitPatient_Click(object sender, EventArgs e)
    {
        Patient? patient = GetSelectedPatientFromListView();

        if (patient == null)
            return;

        if (patient.IsCurrentlyAdmitted())
        {
            MessageBox.Show("Patient is already admitted", "Patient already admitted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FrmAdmitPatient frmAdmitPatient = new(patient);
    }

    private Patient? GetSelectedPatientFromListView()
    {
        if (lvPatients.SelectedItems.Count == 0)
            return null;

        return lvPatients.SelectedItems[0]?.Tag as Patient ?? null;
    }

    private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbGender.SelectedIndex == -1)
            return;

        Gender? gender = GetGenderFromComboBox();

        if (gender == Gender.NonBinary)
        {
            txtGender.Visible = true;
            lblGenderMessage.Visible = true;
        }
        else
        {
            txtGender.Text = string.Empty;
            txtGender.Visible = false;
            lblGenderMessage.Visible = false;
        }
    }

    private Gender? GetGenderFromComboBox()
    {
        if (cmbGender.SelectedIndex == -1)
            return null;

        if (cmbGender.SelectedItem is Gender selectedOption)        
            return selectedOption;

        return null;
    } 
}
