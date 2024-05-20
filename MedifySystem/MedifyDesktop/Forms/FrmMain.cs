using FontAwesome.Sharp;
using MedifySystem.MedifyDesktop.Forms;

namespace MedifySystem;

/// <summary>
/// 
/// </summary>
public partial class FrmMain : Form
{
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
    }

    private void AddSignInButton()
    {
        AddMenuButton(BTN_SIGN_IN_TEXT, BTN_SIGN_IN_NAME, IconChar.SignInAlt);
    }

    private void AddSignOutButton()
    {
        AddMenuButton(BTN_SIGN_OUT_TEXT, BTN_SIGN_OUT_NAME, IconChar.SignOutAlt);
    }

    private void RemoveMenuButton(string text)
    {
        Control[] controls = flpMainMenu.Controls.Find($"btn{text}", false);
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
            Size = new Size(180, 23),
            TextAlign = ContentAlignment.MiddleLeft,
            UseVisualStyleBackColor = true            
        };

        // these have to be added outside of the initializer
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;

        button.Click += HandleClickMainMenuClickEvent;
        flpMainMenu.Controls.Add(button);
    }

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
}
