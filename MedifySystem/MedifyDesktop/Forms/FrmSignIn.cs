using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Helpers;

namespace MedifySystem.MedifyDesktop.Forms;

/// <summary>
/// Sign in form
/// </summary>
internal partial class FrmSignIn : Form
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    public FrmSignIn()
    {
        InitializeComponent();

        _userService!.LogOutEvent += HandleLogOutEvent;
        _userService.LogInEvent += HandleLogInEvent;
        _userService.ResetPasswordEvent += HandleResetPasswordEvent;

        // listen for enter key press to click the sign in button
        AcceptButton = btnSignIn;
    }

    private void HandleResetPasswordEvent(object sender, EventArgs e)
    {
        ShowPasswordResetControls();
    }

    private void HandleLogInEvent(object sender, EventArgs e) => Close();    

    private void HandleLogOutEvent(object sender, EventArgs e) => Close();

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void btnSignIn_Click(object sender, EventArgs e)
    {
        if (ValidateEmail() == false || ValidatePassword() == false)
            return;

        if (_userService!.AuthenticateUser(txtEmail.Text, txtPassword.Text) == false)
        {
            MessageBox.Show("Invalid email or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResetForm();
            return;
        }

        return;
    }

    private bool ValidateEmail()
    {
        txtEmail.Text = txtEmail.Text.ToLower().Trim();

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

        txtNewPassword.Text = string.Empty;
        txtNewPassword.Visible = false;
        lblNewPassword.Visible = false;
        lblNewPasswordHelp.Visible = false;
        btnConfirmReset.Visible = false;
    }

    private void ShowPasswordResetControls()
    {
        txtNewPassword.Visible = true;
        lblNewPassword.Visible = true;
        lblNewPasswordHelp.Visible = true;
        btnConfirmReset.Visible = true;

        lblEmail.Visible = false;
        txtEmail.Visible = false;
        lblPassword.Visible = false;
        txtPassword.Visible = false;
        btnSignIn.Visible = false;
        btnSignIn.Enabled = false;
    }

    private void btnConfirmReset_Click(object sender, EventArgs e) => ResetPassword();

    private void ResetPassword()
    {
        txtNewPassword.Text = txtNewPassword.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
        {
            MessageBox.Show("New password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        User currentUser = _userService!.GetCurrentUser()!;
        currentUser.PasswordHash = PasswordHelper.HashPassword(currentUser, txtNewPassword.Text);
        currentUser.RequiresPasswordReset = false;

        _userService!.UpdateUser(currentUser);

        _userService!.LogOutUser();
    }

    /// <summary>
    /// overrride close method to remove event handlers
    /// </summary>
    protected override void OnClosed(EventArgs e)
    {
        _userService!.LogOutEvent -= HandleLogOutEvent;
        _userService.LogInEvent -= HandleLogInEvent;
        base.OnClosed(e);
    }
}
