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
        if (ValidateEmailAndPassword() == false)
            return;

        _userService!.AuthenticateUser(txtEmail.Text, txtPassword.Text);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

    }

    private void btnCreateAccount_Click(object sender, EventArgs e)
    {

    }

    private bool ValidateEmailAndPassword()
    {
        foreach (Control control in Controls)
        {
            if (control is TextBox textBox)
            {
                control.Text = control.Text.Trim();

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    control.Focus();
                    control.BackColor = Color.Red;
                    return false;
                }
            }
        }

        return true;
    }
}
