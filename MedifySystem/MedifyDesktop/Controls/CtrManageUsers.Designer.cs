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
        SuspendLayout();
        // 
        // lblControlTitle
        // 
        lblControlTitle.AutoSize = true;
        lblControlTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblControlTitle.Location = new Point(226, 16);
        lblControlTitle.Name = "lblControlTitle";
        lblControlTitle.Size = new Size(205, 32);
        lblControlTitle.TabIndex = 0;
        lblControlTitle.Text = "Manage Users";
        // 
        // lvUsers
        // 
        lvUsers.Location = new Point(306, 95);
        lvUsers.Name = "lvUsers";
        lvUsers.Size = new Size(362, 327);
        lvUsers.TabIndex = 1;
        lvUsers.UseCompatibleStateImageBehavior = false;
        lvUsers.GridLines = true;
        lvUsers.View = View.Details;
        lvUsers.MultiSelect  = false;
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
        // CtrManageUsers
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(txtUserSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnShowAll);
        Controls.Add(lvUsers);
        Controls.Add(lblControlTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "CtrManageUsers";
        Size = new Size(671, 425);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblControlTitle;
    private ListView lvUsers;
    private FontAwesome.Sharp.IconButton btnShowAll;
    private FontAwesome.Sharp.IconButton btnSearch;
    private TextBox txtUserSearch;
}
