﻿namespace MedifySystem.MedifyDesktop.Controls;

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
        btnClearNewPatient = new FontAwesome.Sharp.IconButton();
        btnRegisterPatient = new FontAwesome.Sharp.IconButton();
        txtLastName = new TextBox();
        txtFirstName = new TextBox();
        lblLastName = new Label();
        lblFirstName = new Label();
        lvPatients = new ListView();
        txtUserSearch = new TextBox();
        btnSearch = new FontAwesome.Sharp.IconButton();
        btnShowAll = new FontAwesome.Sharp.IconButton();
        btnViewPatientDetails = new FontAwesome.Sharp.IconButton();
        btnAdmitPatient = new FontAwesome.Sharp.IconButton();
        grpRegisterPatient.SuspendLayout();
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
        grpRegisterPatient.Controls.Add(btnClearNewPatient);
        grpRegisterPatient.Controls.Add(btnRegisterPatient);
        grpRegisterPatient.Controls.Add(txtLastName);
        grpRegisterPatient.Controls.Add(txtFirstName);
        grpRegisterPatient.Controls.Add(lblLastName);
        grpRegisterPatient.Controls.Add(lblFirstName);
        grpRegisterPatient.Location = new Point(3, 87);
        grpRegisterPatient.Name = "grpRegisterPatient";
        grpRegisterPatient.Size = new Size(312, 163);
        grpRegisterPatient.TabIndex = 2;
        grpRegisterPatient.TabStop = false;
        grpRegisterPatient.Text = "Register new patient";
        // 
        // btnClearNewPatient
        // 
        btnClearNewPatient.IconChar = FontAwesome.Sharp.IconChar.X;
        btnClearNewPatient.IconColor = Color.Black;
        btnClearNewPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnClearNewPatient.IconSize = 25;
        btnClearNewPatient.ImageAlign = ContentAlignment.MiddleRight;
        btnClearNewPatient.Location = new Point(8, 106);
        btnClearNewPatient.Name = "btnClearNewPatient";
        btnClearNewPatient.Size = new Size(87, 32);
        btnClearNewPatient.TabIndex = 5;
        btnClearNewPatient.Text = "Clear";
        btnClearNewPatient.TextAlign = ContentAlignment.MiddleLeft;
        btnClearNewPatient.UseVisualStyleBackColor = true;
        btnClearNewPatient.Click += btnClearNewPatient_Click;
        // 
        // btnRegisterPatient
        // 
        btnRegisterPatient.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
        btnRegisterPatient.IconColor = Color.Black;
        btnRegisterPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnRegisterPatient.IconSize = 30;
        btnRegisterPatient.ImageAlign = ContentAlignment.MiddleRight;
        btnRegisterPatient.Location = new Point(152, 106);
        btnRegisterPatient.Name = "btnRegisterPatient";
        btnRegisterPatient.Size = new Size(151, 32);
        btnRegisterPatient.TabIndex = 4;
        btnRegisterPatient.Text = "Register Patient";
        btnRegisterPatient.TextAlign = ContentAlignment.MiddleLeft;
        btnRegisterPatient.UseVisualStyleBackColor = true;
        btnRegisterPatient.Click += btnRegisterPatient_Click;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(89, 68);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(214, 23);
        txtLastName.TabIndex = 3;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(89, 33);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(214, 23);
        txtFirstName.TabIndex = 2;
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(6, 71);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(76, 16);
        lblLastName.TabIndex = 1;
        lblLastName.Text = "Last Name";
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(6, 36);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(77, 16);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First Name";
        // 
        // lvPatients
        // 
        lvPatients.GridLines = true;
        lvPatients.Location = new Point(321, 96);
        lvPatients.Name = "lvPatients";
        lvPatients.Size = new Size(372, 368);
        lvPatients.TabIndex = 3;
        lvPatients.UseCompatibleStateImageBehavior = false;
        lvPatients.View = View.Details;
        // 
        // txtUserSearch
        // 
        txtUserSearch.Location = new Point(321, 67);
        txtUserSearch.Name = "txtUserSearch";
        txtUserSearch.Size = new Size(251, 23);
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
        // btnViewPatientDetails
        // 
        btnViewPatientDetails.FlatStyle = FlatStyle.Flat;
        btnViewPatientDetails.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
        btnViewPatientDetails.IconColor = Color.Black;
        btnViewPatientDetails.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnViewPatientDetails.IconSize = 30;
        btnViewPatientDetails.ImageAlign = ContentAlignment.MiddleRight;
        btnViewPatientDetails.Location = new Point(558, 470);
        btnViewPatientDetails.Name = "btnViewPatientDetails";
        btnViewPatientDetails.Size = new Size(135, 32);
        btnViewPatientDetails.TabIndex = 8;
        btnViewPatientDetails.Text = "View Details";
        btnViewPatientDetails.TextAlign = ContentAlignment.MiddleLeft;
        btnViewPatientDetails.UseVisualStyleBackColor = true;
        btnViewPatientDetails.Click += btnViewPatientDetails_Click;
        // 
        // btnAdmitPatient
        // 
        btnAdmitPatient.FlatStyle = FlatStyle.Flat;
        btnAdmitPatient.IconChar = FontAwesome.Sharp.IconChar.HospitalUser;
        btnAdmitPatient.IconColor = Color.Black;
        btnAdmitPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnAdmitPatient.IconSize = 30;
        btnAdmitPatient.ImageAlign = ContentAlignment.MiddleRight;
        btnAdmitPatient.Location = new Point(321, 470);
        btnAdmitPatient.Name = "btnAdmitPatient";
        btnAdmitPatient.Size = new Size(135, 32);
        btnAdmitPatient.TabIndex = 9;
        btnAdmitPatient.Text = "Admit Patient";
        btnAdmitPatient.TextAlign = ContentAlignment.MiddleLeft;
        btnAdmitPatient.UseVisualStyleBackColor = true;
        btnAdmitPatient.Click += btnAdmitPatient_Click;
        // 
        // CtrManagePatients
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        Controls.Add(btnAdmitPatient);
        Controls.Add(btnViewPatientDetails);
        Controls.Add(txtUserSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnShowAll);
        Controls.Add(lvPatients);
        Controls.Add(grpRegisterPatient);
        Controls.Add(lblControlTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "CtrManagePatients";
        Size = new Size(696, 505);
        grpRegisterPatient.ResumeLayout(false);
        grpRegisterPatient.PerformLayout();
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
    private FontAwesome.Sharp.IconButton btnViewPatientDetails;
    private Label lblLastName;
    private Label lblFirstName;
    private TextBox txtLastName;
    private TextBox txtFirstName;
    private FontAwesome.Sharp.IconButton btnAdmitPatient;
    private FontAwesome.Sharp.IconButton btnRegisterPatient;
    private FontAwesome.Sharp.IconButton btnClearNewPatient;
}