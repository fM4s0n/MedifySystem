﻿using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Helpers;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Controls;

/// <summary>
/// 
/// </summary>
public partial class CtrManageUsers : UserControl
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private List<User>? _allUsers;

    private readonly List<User> _lvUsersDataSource = [];

    public CtrManageUsers()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        RefreshAllUsers();

        Init();
    }

    private void Init()
    {
        cmbRole.DataSource = Enum.GetValues(typeof(UserRole));

        InitListView();
        InitGenderComboBox();
    }

    private void InitListView()
    {
        int width = lvUsers.Width / 3;
        lvUsers.Columns.Add("Full Name", width);
        lvUsers.Columns.Add("Role", width);
        lvUsers.Columns.Add("Active Patients", width);
    }

    private void InitGenderComboBox()
    {
       cmbGender.DataSource = Enum.GetValues(typeof(UserRole));
    }

    private void ShowAllUsers() => Search(string.Empty);    

    private void RefreshAllUsers()
    {
        _allUsers = _userService!.GetAllUsers();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        string searchText = txtUserSearch.Text = txtUserSearch.Text.Trim();

        if (string.IsNullOrWhiteSpace(searchText))
            ShowAllUsers();

        Search(searchText);
    }

    private void btnShowAll_Click(object sender, EventArgs e)
    {
        ShowAllUsers();
    }

    private void ClearAddUserFields()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        cmbRole.SelectedIndex = 0;
    }

    private void Search(string searchText)
    {
        _lvUsersDataSource.Clear();

        // if search text is empty, show all users
        if (string.IsNullOrWhiteSpace(searchText))
        {
            _lvUsersDataSource.AddRange(_allUsers!);
            RefreshUsersListView();
            return;
        }

        _lvUsersDataSource.AddRange(_allUsers!.Where(u => u.FirstName.Contains(searchText) || u.LastName.Contains(searchText)));
        RefreshUsersListView();
    }

    private void RefreshUsersListView()
    {
        lvUsers.Items.Clear();

        foreach (User user in _lvUsersDataSource)
        {
            int activePatients = _userService!.GetAllAdmittedPatientsForUser(user.Id)?.Count ?? 0;

            ListViewItem item = new (user.FullName);

            item.SubItems.Add(user.Role.ToString());
            item.SubItems.Add(activePatients.ToString());

            lvUsers.Items.Add(item);
        }
    }

    private void btnAddNewUser_Click(object sender, EventArgs e)
    {
        if (AddNewUserFromFields())
        {
            RefreshAllUsers();
            RefreshUsersListView();
        }
        else
        {
            MessageBox.Show("Failed to add new user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool AddNewUserFromFields()
    {
        if (ValidateAddUserFields() == false)
            return false;

        if (cmbRole.SelectedItem is UserRole role == false)
            return false;

        if (cmbGender.SelectedItem is Gender gender == false)
            return false;

        User newUser = new(txtEmail.Text, role, txtFirstName.Text, txtLastName.Text, gender);

        // default password for new user is "password" - will force user to change password on first login
        newUser.PasswordHash = PasswordHelper.HashPassword(newUser, "password");

        _userService!.InsertUser(newUser);

        ClearAddUserFields();

        return true;
    }

    private bool ValidateAddUserFields()
    {
        txtFirstName.Text = txtFirstName.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("First Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        txtLastName.Text = txtLastName.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("Last Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        txtEmail.Text = txtEmail.Text.ToLower().Trim();
        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Email is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (cmbRole.SelectedIndex == -1)
        {
            MessageBox.Show("Role is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}
