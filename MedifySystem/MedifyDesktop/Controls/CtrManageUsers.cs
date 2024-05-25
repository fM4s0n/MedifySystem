using MedifySystem.MedifyCommon.Services;

namespace MedifySystem.MedifyDesktop.Controls;

/// <summary>
/// 
/// </summary>
public partial class CtrManageUsers : UserControl
{
    private readonly IUserService? _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

    public CtrManageUsers()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        Init();
    }

    private void Init()
    {
        lvUsers.Columns.Add("Full Name");
        lvUsers.Columns.Add("Role");
    }

    // handle double click of selected row in lvUsers
    private void lvUsers_DoubleClick(object sender, EventArgs e)
    {
        // get the selected user

        // open user details form
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {

    }

    private void btnShowAll_Click(object sender, EventArgs e)
    {

    }
}
