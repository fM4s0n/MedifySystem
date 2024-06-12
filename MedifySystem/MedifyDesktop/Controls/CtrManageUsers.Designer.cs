namespace MedifySystem.MedifyDesktop.Controls;

partial class CtrManageUsers
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblControlTitle = new Label();
        lvUsers = new ListView();
        btnShowAll = new FontAwesome.Sharp.IconButton();
        btnSearch = new FontAwesome.Sharp.IconButton();
        txtUserSearch = new TextBox();
        grpAddUser = new GroupBox();
        cmbGender = new ComboBox();
        lblGender = new Label();
        lblEmail = new Label();
        txtEmail = new TextBox();
        btnAddNewUser = new FontAwesome.Sharp.IconButton();
        lblRole = new Label();
        lblLastName = new Label();
        lblFirstName = new Label();
        cmbRole = new ComboBox();
        txtLastName = new TextBox();
        txtFirstName = new TextBox();
        grpAddUser.SuspendLayout();
        SuspendLayout();
        // 
        // lblControlTitle
        // 
        lblControlTitle.AutoSize = true;
        lblControlTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblControlTitle.Location = new Point(224, 4);
        lblControlTitle.Name = "lblControlTitle";
        lblControlTitle.Size = new Size(205, 32);
        lblControlTitle.TabIndex = 0;
        lblControlTitle.Text = "Manage Users";
        // 
        // lvUsers
        // 
        lvUsers.GridLines = true;
        lvUsers.Location = new Point(317, 99);
        lvUsers.MultiSelect = false;
        lvUsers.Name = "lvUsers";
        lvUsers.Size = new Size(376, 403);
        lvUsers.TabIndex = 1;
        lvUsers.UseCompatibleStateImageBehavior = false;
        lvUsers.View = View.Details;
        // 
        // btnShowAll
        // 
        btnShowAll.FlatStyle = FlatStyle.Flat;
        btnShowAll.IconChar = FontAwesome.Sharp.IconChar.None;
        btnShowAll.IconColor = Color.Black;
        btnShowAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnShowAll.Location = new Point(593, 61);
        btnShowAll.Name = "btnShowAll";
        btnShowAll.Size = new Size(75, 32);
        btnShowAll.TabIndex = 2;
        btnShowAll.Text = "Show All";
        btnShowAll.UseVisualStyleBackColor = true;
        btnShowAll.Click += btnShowAll_Click;
        // 
        // btnSearch
        // 
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
        btnSearch.IconColor = Color.Black;
        btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnSearch.IconSize = 20;
        btnSearch.Location = new Point(553, 61);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(34, 32);
        btnSearch.TabIndex = 3;
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // txtUserSearch
        // 
        txtUserSearch.Location = new Point(306, 66);
        txtUserSearch.Name = "txtUserSearch";
        txtUserSearch.Size = new Size(241, 23);
        txtUserSearch.TabIndex = 4;
        // 
        // grpAddUser
        // 
        grpAddUser.Controls.Add(cmbGender);
        grpAddUser.Controls.Add(lblGender);
        grpAddUser.Controls.Add(lblEmail);
        grpAddUser.Controls.Add(txtEmail);
        grpAddUser.Controls.Add(btnAddNewUser);
        grpAddUser.Controls.Add(lblRole);
        grpAddUser.Controls.Add(lblLastName);
        grpAddUser.Controls.Add(lblFirstName);
        grpAddUser.Controls.Add(cmbRole);
        grpAddUser.Controls.Add(txtLastName);
        grpAddUser.Controls.Add(txtFirstName);
        grpAddUser.Location = new Point(3, 87);
        grpAddUser.Name = "grpAddUser";
        grpAddUser.Size = new Size(297, 415);
        grpAddUser.TabIndex = 5;
        grpAddUser.TabStop = false;
        grpAddUser.Text = "Add New User";
        // 
        // cmbGender
        // 
        cmbGender.FormattingEnabled = true;
        cmbGender.Location = new Point(87, 154);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new Size(204, 24);
        cmbGender.TabIndex = 10;
        // 
        // lblGender
        // 
        lblGender.AutoSize = true;
        lblGender.Location = new Point(7, 158);
        lblGender.Name = "lblGender";
        lblGender.Size = new Size(53, 16);
        lblGender.TabIndex = 9;
        lblGender.Text = "Gender";
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(6, 97);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(40, 16);
        lblEmail.TabIndex = 8;
        lblEmail.Text = "Email";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(87, 94);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(204, 23);
        txtEmail.TabIndex = 7;
        // 
        // btnAddNewUser
        // 
        btnAddNewUser.FlatStyle = FlatStyle.Flat;
        btnAddNewUser.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
        btnAddNewUser.IconColor = Color.Black;
        btnAddNewUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnAddNewUser.IconSize = 25;
        btnAddNewUser.ImageAlign = ContentAlignment.MiddleRight;
        btnAddNewUser.Location = new Point(191, 193);
        btnAddNewUser.Name = "btnAddNewUser";
        btnAddNewUser.Size = new Size(100, 32);
        btnAddNewUser.TabIndex = 6;
        btnAddNewUser.Text = "Add User";
        btnAddNewUser.TextAlign = ContentAlignment.MiddleLeft;
        btnAddNewUser.UseVisualStyleBackColor = true;
        btnAddNewUser.Click += btnAddNewUser_Click;
        // 
        // lblRole
        // 
        lblRole.AutoSize = true;
        lblRole.Location = new Point(7, 126);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(34, 16);
        lblRole.TabIndex = 5;
        lblRole.Text = "Role";
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(6, 68);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(76, 16);
        lblLastName.TabIndex = 4;
        lblLastName.Text = "Last Name";
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(4, 39);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(77, 16);
        lblFirstName.TabIndex = 3;
        lblFirstName.Text = "First Name";
        // 
        // cmbRole
        // 
        cmbRole.FormattingEnabled = true;
        cmbRole.Location = new Point(87, 123);
        cmbRole.Name = "cmbRole";
        cmbRole.Size = new Size(204, 24);
        cmbRole.TabIndex = 2;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(87, 65);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(204, 23);
        txtLastName.TabIndex = 1;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(87, 36);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(204, 23);
        txtFirstName.TabIndex = 0;
        // 
        // CtrManageUsers
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(grpAddUser);
        Controls.Add(txtUserSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnShowAll);
        Controls.Add(lvUsers);
        Controls.Add(lblControlTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "CtrManageUsers";
        Size = new Size(696, 505);
        grpAddUser.ResumeLayout(false);
        grpAddUser.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblControlTitle;
    private ListView lvUsers;
    private FontAwesome.Sharp.IconButton btnShowAll;
    private FontAwesome.Sharp.IconButton btnSearch;
    private TextBox txtUserSearch;
    private GroupBox grpAddUser;
    private TextBox txtLastName;
    private TextBox txtFirstName;
    private Label lblRole;
    private Label lblLastName;
    private Label lblFirstName;
    private ComboBox cmbRole;
    private FontAwesome.Sharp.IconButton btnAddNewUser;
    private Label lblEmail;
    private TextBox txtEmail;
    private ComboBox cmbGender;
    private Label lblGender;
}
