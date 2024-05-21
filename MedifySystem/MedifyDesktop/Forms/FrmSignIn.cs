using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// 
/// </summary>
public partial class FrmSignIn : Form
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    public FrmSignIn()
    {
        InitializeComponent();
    }

    private void btnSignIn_Click(object sender, EventArgs e)
    {
        if (ValidateEmail() == false)
            return;

        if (ValidatePassword() == false)
            return;

        if (_userService!.AuthenticateUser(txtEmail.Text, txtPassword.Text) == false)
        {
            MessageBox.Show("Invalid email or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {

    }

    private bool ValidateEmail()
    {
        txtEmail.Text = txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            lblWarnEmail.Visible = true;
            return false;
        }

        return true;
    }

    /// <summary>
    /// Reset the warning label when the user starts typing in the email text box
    /// </summary>
    private void txtEmail_TextChanged(object sender, EventArgs e) => lblWarnEmail.Visible = false;

    private bool ValidatePassword()
    {
        txtPassword.Text = txtPassword.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblWarnPassword.Visible = true;
            return false;
        }

        return true;
    }

    private void txtPassword_TextChanged(object sender, EventArgs e) => lblWarnPassword.Visible = false;

    private void ResetForm()
    {
        txtEmail.Text = string.Empty;
        txtPassword.Text = string.Empty;
        lblWarnEmail.Visible = false;
        lblWarnPassword.Visible = false;
    }

    private void lblWarnEmail_Click(object sender, EventArgs e)
    {

    }
}
