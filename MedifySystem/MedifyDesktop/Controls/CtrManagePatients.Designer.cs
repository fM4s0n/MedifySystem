namespace MedifySystem.MedifyDesktop.Controls;

partial class CtrManagePatients
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
        grpRegisterPatient = new GroupBox();
        lvPatients = new ListView();
        txtUserSearch = new TextBox();
        btnSearch = new FontAwesome.Sharp.IconButton();
        btnShowAll = new FontAwesome.Sharp.IconButton();
        SuspendLayout();
        // 
        // lblControlTitle
        // 
        lblControlTitle.AutoSize = true;
        lblControlTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblControlTitle.Location = new Point(206, 9);
        lblControlTitle.Name = "lblControlTitle";
        lblControlTitle.Size = new Size(236, 32);
        lblControlTitle.TabIndex = 1;
        lblControlTitle.Text = "Manage Patients";
        // 
        // grpRegisterPatient
        // 
        grpRegisterPatient.Location = new Point(3, 87);
        grpRegisterPatient.Name = "grpRegisterPatient";
        grpRegisterPatient.Size = new Size(297, 415);
        grpRegisterPatient.TabIndex = 2;
        grpRegisterPatient.TabStop = false;
        grpRegisterPatient.Text = "Register new patient";
        // 
        // lvPatients
        // 
        lvPatients.GridLines = true;
        lvPatients.Location = new Point(321, 96);
        lvPatients.Name = "lvPatients";
        lvPatients.Size = new Size(372, 406);
        lvPatients.TabIndex = 3;
        lvPatients.UseCompatibleStateImageBehavior = false;
        lvPatients.View = View.Details;
        // 
        // txtUserSearch
        // 
        txtUserSearch.Location = new Point(331, 67);
        txtUserSearch.Name = "txtUserSearch";
        txtUserSearch.Size = new Size(241, 23);
        txtUserSearch.TabIndex = 7;
        // 
        // btnSearch
        // 
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
        btnSearch.IconColor = Color.Black;
        btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnSearch.IconSize = 20;
        btnSearch.Location = new Point(578, 62);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(34, 32);
        btnSearch.TabIndex = 6;
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // btnShowAll
        // 
        btnShowAll.FlatStyle = FlatStyle.Flat;
        btnShowAll.IconChar = FontAwesome.Sharp.IconChar.None;
        btnShowAll.IconColor = Color.Black;
        btnShowAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnShowAll.Location = new Point(618, 62);
        btnShowAll.Name = "btnShowAll";
        btnShowAll.Size = new Size(75, 32);
        btnShowAll.TabIndex = 5;
        btnShowAll.Text = "Show All";
        btnShowAll.UseVisualStyleBackColor = true;
        btnShowAll.Click += btnShowAll_Click;
        // 
        // CtrManagePatients
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(txtUserSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnShowAll);
        Controls.Add(lvPatients);
        Controls.Add(grpRegisterPatient);
        Controls.Add(lblControlTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "CtrManagePatients";
        Size = new Size(696, 505);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblControlTitle;
    private GroupBox grpRegisterPatient;
    private ListView lvPatients;
    private TextBox txtUserSearch;
    private FontAwesome.Sharp.IconButton btnSearch;
    private FontAwesome.Sharp.IconButton btnShowAll;
}
