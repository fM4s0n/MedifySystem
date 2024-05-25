using FontAwesome.Sharp;
using MedifySystem.MedifyCommon.Enums;
using MedifySystem.MedifyCommon.Models;
using MedifySystem.MedifyCommon.Services;
using MedifySystem.MedifyDesktop.Forms;

namespace MedifySystem;

/// <summary>
/// Main form
/// </summary>
public partial class FrmMain : Form
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    private const string BTN_SIGN_IN_TEXT = "Sign In";
    private const string BTN_SIGN_IN_NAME = "btnSignIn";
    private const string BTN_SIGN_OUT_TEXT = "Sign Out";
    private const string BTN_SIGN_OUT_NAME = "btnSignOut";

    public FrmMain()
    {
        InitializeComponent();

        if (DesignMode)        
            return;
        
        Init();
    }

    private void Init()
    {
        AddSignInButton();

        _userService!.LogInEvent += HandleLogInEvent;
        _userService!.LogOutEvent += HandleLogOutEvent;
    }

    private void HandleLogInEvent(object sender, EventArgs e)
    {
        User? user = _userService!.GetCurrentUser();

        if (user != null)
        {
            RemoveMenuButton(BTN_SIGN_IN_NAME);
            AddSignOutButton();

            switch (user.Role)
            {
                case UserRole.SystemAdmin:
                    ShowSystemAdminControl();
                    break;
                case UserRole.Doctor:
                case UserRole.Receptionist:
                case UserRole.Nurse:
                    ShowHospitalOfficialControl();
                    break;
            }
        }
        else
        {
            // something went wrong
            _userService.LogoutUser();
        }
    }

    private void HandleLogOutEvent(object sender, EventArgs e)
    {
        RemoveMenuButton(BTN_SIGN_OUT_NAME);
        AddSignInButton();
    }

    private void AddSignInButton()
    {
        AddMenuButton(BTN_SIGN_IN_TEXT, BTN_SIGN_IN_NAME, IconChar.SignInAlt);
    }

    private void AddSignOutButton()
    {
        Reset();
        AddMenuButton(BTN_SIGN_OUT_TEXT, BTN_SIGN_OUT_NAME, IconChar.SignOutAlt);
    }

    private void RemoveMenuButton(string name)
    {
        Control[] controls = flpMainMenu.Controls.Find($"btn{name}", false);

        if (controls.Length > 0)        
            flpMainMenu.Controls.Remove(controls[0]);        
    }    

    private void AddMenuButton(string text, string name, IconChar iconChar)
    {
        IconButton button = new()
        {
            Text = text,
            Font = new Font("Verdana", 10F),
            ForeColor = Color.White,
            IconChar = iconChar,
            IconColor = Color.White,
            IconFont = IconFont.Auto,
            IconSize = 35,
            ImageAlign = ContentAlignment.MiddleRight,
            Name = name,
            Size = new Size(180, 35),
            TextAlign = ContentAlignment.MiddleLeft,
            UseVisualStyleBackColor = true            
        };

        // these have to be added outside of the initializer
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;

        button.Click += HandleClickMainMenuClickEvent;
        flpMainMenu.Controls.Add(button);
    }

    /// <summary>
    /// Generic handler for the main menu buttons
    /// as they are implemented programmatically
    /// </summary>
    private void HandleClickMainMenuClickEvent(object? sender, EventArgs e)
    {
        if (sender is IconButton button)
        {
            switch (button.Name)
            {
                case BTN_SIGN_IN_NAME:
                    FrmSignIn frmSignIn = new();
                    frmSignIn.ShowDialog();
                    break;
                case BTN_SIGN_OUT_NAME:

                    break;
            }
        }
    }

    private void ShowSystemAdminControl()
    {

    }

    private void ShowHospitalOfficialControl()
    {

    }

    /// <summary>
    /// Reset the form
    /// </summary>
    private void Reset()
    {
        foreach (Control control in flpMainMenu.Controls)
        {
            if (control is IconButton button)
            {
                button.Dispose();
            }
        }
    }
}
