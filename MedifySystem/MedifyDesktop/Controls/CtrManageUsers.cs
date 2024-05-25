using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Controls;

/// <summary>
/// 
/// </summary>
public partial class CtrManageUsers : UserControl
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private readonly List<User>? _allUsers;

    private List<User> lvUsersDataSource = [];

    public CtrManageUsers()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _allUsers = _userService!.GetAllUsers();

        Init();
    }

    private void Init()
    {
        lvUsers.Columns.Add("Full Name");
        lvUsers.Columns.Add("Role");
    }

    private void ShowAllUsers()
    {

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
        lvUsersDataSource.Clear();

        lvUsersDataSource.AddRange(_allUsers!.Where(u => u.FirstName.Contains(searchText) || u.LastName.Contains(searchText)));
    }

    private void RefreshUsersListView()
    {
        lvUsers.Items.Clear();

        foreach (User user in lvUsersDataSource)
        {
            ListViewItem item = new (user.FullName);
            item.SubItems.Add(user.Role.ToString());

            lvUsers.Items.Add(item);
        }
    }

    private void btnAddNewUser_Click(object sender, EventArgs e)
    {
        if (ValidateAddUserFields() == false)
            return;

        ClearAddUserFields();
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

        if (cmbRole.SelectedIndex == -1)
        {
            MessageBox.Show("Role is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}
