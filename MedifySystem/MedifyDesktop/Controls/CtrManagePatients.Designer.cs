


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
        dtpDateOfBirth = new DateTimePicker();
        lblDateOfBirth = new Label();
        lblGPName = new Label();
        txtGPName = new TextBox();
        lblGender = new Label();
        cmbGender = new ComboBox();
        lblNHSNumber = new Label();
        txtNHSNumber = new TextBox();
        btnClearNewPatient = new FontAwesome.Sharp.IconButton();
        btnRegisterPatient = new FontAwesome.Sharp.IconButton();
        txtLastName = new TextBox();
        txtFirstName = new TextBox();
        lblLastName = new Label();
        lblFirstName = new Label();
        lvPatients = new ListView();
        txtSearch = new TextBox();
        btnSearch = new FontAwesome.Sharp.IconButton();
        btnShowAll = new FontAwesome.Sharp.IconButton();
        btnViewPatientDetails = new FontAwesome.Sharp.IconButton();
        btnAdmitPatient = new FontAwesome.Sharp.IconButton();
        btnPatientRecord = new FontAwesome.Sharp.IconButton();
        grpPatientOptions = new GroupBox();
        btnBookAppointment = new FontAwesome.Sharp.IconButton();
        grpRegisterPatient.SuspendLayout();
        grpPatientOptions.SuspendLayout();
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
        grpRegisterPatient.Controls.Add(dtpDateOfBirth);
        grpRegisterPatient.Controls.Add(lblDateOfBirth);
        grpRegisterPatient.Controls.Add(lblGPName);
        grpRegisterPatient.Controls.Add(txtGPName);
        grpRegisterPatient.Controls.Add(lblGender);
        grpRegisterPatient.Controls.Add(cmbGender);
        grpRegisterPatient.Controls.Add(lblNHSNumber);
        grpRegisterPatient.Controls.Add(txtNHSNumber);
        grpRegisterPatient.Controls.Add(btnClearNewPatient);
        grpRegisterPatient.Controls.Add(btnRegisterPatient);
        grpRegisterPatient.Controls.Add(txtLastName);
        grpRegisterPatient.Controls.Add(txtFirstName);
        grpRegisterPatient.Controls.Add(lblLastName);
        grpRegisterPatient.Controls.Add(lblFirstName);
        grpRegisterPatient.Location = new Point(382, 57);
        grpRegisterPatient.Name = "grpRegisterPatient";
        grpRegisterPatient.Size = new Size(312, 269);
        grpRegisterPatient.TabIndex = 2;
        grpRegisterPatient.TabStop = false;
        grpRegisterPatient.Text = "Register new patient";
        // 
        // dtpDateOfBirth
        // 
        dtpDateOfBirth.Location = new Point(98, 95);
        dtpDateOfBirth.Name = "dtpDateOfBirth";
        dtpDateOfBirth.Size = new Size(210, 23);
        dtpDateOfBirth.TabIndex = 15;
        // 
        // lblDateOfBirth
        // 
        lblDateOfBirth.AutoSize = true;
        lblDateOfBirth.Location = new Point(5, 100);
        lblDateOfBirth.Name = "lblDateOfBirth";
        lblDateOfBirth.Size = new Size(91, 16);
        lblDateOfBirth.TabIndex = 14;
        lblDateOfBirth.Text = "Date of Birth";
        // 
        // lblGPName
        // 
        lblGPName.AutoSize = true;
        lblGPName.Location = new Point(6, 158);
        lblGPName.Name = "lblGPName";
        lblGPName.Size = new Size(65, 16);
        lblGPName.TabIndex = 13;
        lblGPName.Text = "GP Name";
        // 
        // txtGPName
        // 
        txtGPName.Location = new Point(98, 155);
        txtGPName.Name = "txtGPName";
        txtGPName.Size = new Size(210, 23);
        txtGPName.TabIndex = 12;
        // 
        // lblGender
        // 
        lblGender.AutoSize = true;
        lblGender.Location = new Point(4, 187);
        lblGender.Name = "lblGender";
        lblGender.Size = new Size(53, 16);
        lblGender.TabIndex = 9;
        lblGender.Text = "Gender";
        // 
        // cmbGender
        // 
        cmbGender.FormattingEnabled = true;
        cmbGender.Location = new Point(98, 184);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new Size(210, 24);
        cmbGender.TabIndex = 8;
        // 
        // lblNHSNumber
        // 
        lblNHSNumber.AutoSize = true;
        lblNHSNumber.Location = new Point(6, 129);
        lblNHSNumber.Name = "lblNHSNumber";
        lblNHSNumber.Size = new Size(88, 16);
        lblNHSNumber.TabIndex = 7;
        lblNHSNumber.Text = "NHS Number";
        // 
        // txtNHSNumber
        // 
        txtNHSNumber.Location = new Point(98, 126);
        txtNHSNumber.Name = "txtNHSNumber";
        txtNHSNumber.Size = new Size(210, 23);
        txtNHSNumber.TabIndex = 6;
        // 
        // btnClearNewPatient
        // 
        btnClearNewPatient.IconChar = FontAwesome.Sharp.IconChar.X;
        btnClearNewPatient.IconColor = Color.Black;
        btnClearNewPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnClearNewPatient.IconSize = 25;
        btnClearNewPatient.ImageAlign = ContentAlignment.MiddleRight;
        btnClearNewPatient.Location = new Point(9, 228);
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
        btnRegisterPatient.Location = new Point(155, 228);
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
        txtLastName.Location = new Point(98, 68);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(210, 23);
        txtLastName.TabIndex = 3;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(98, 39);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(210, 23);
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
        lblFirstName.Location = new Point(5, 42);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(77, 16);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First Name";
        // 
        // lvPatients
        // 
        lvPatients.FullRowSelect = true;
        lvPatients.GridLines = true;
        lvPatients.Location = new Point(3, 95);
        lvPatients.Name = "lvPatients";
        lvPatients.Size = new Size(372, 406);
        lvPatients.TabIndex = 3;
        lvPatients.UseCompatibleStateImageBehavior = false;
        lvPatients.View = View.Details;
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(4, 62);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(251, 23);
        txtSearch.TabIndex = 7;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // btnSearch
        // 
        btnSearch.FlatStyle = FlatStyle.Flat;
        btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
        btnSearch.IconColor = Color.Black;
        btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnSearch.IconSize = 20;
        btnSearch.Location = new Point(261, 57);
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
        btnShowAll.Location = new Point(301, 57);
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
        btnViewPatientDetails.Location = new Point(6, 60);
        btnViewPatientDetails.Name = "btnViewPatientDetails";
        btnViewPatientDetails.Size = new Size(122, 32);
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
        btnAdmitPatient.Location = new Point(6, 22);
        btnAdmitPatient.Name = "btnAdmitPatient";
        btnAdmitPatient.Size = new Size(122, 32);
        btnAdmitPatient.TabIndex = 9;
        btnAdmitPatient.Text = "Admit";
        btnAdmitPatient.TextAlign = ContentAlignment.MiddleLeft;
        btnAdmitPatient.UseVisualStyleBackColor = true;
        btnAdmitPatient.Click += btnAdmitPatient_Click;
        // 
        // btnPatientRecord
        // 
        btnPatientRecord.FlatStyle = FlatStyle.Flat;
        btnPatientRecord.IconChar = FontAwesome.Sharp.IconChar.FileClipboard;
        btnPatientRecord.IconColor = Color.Black;
        btnPatientRecord.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnPatientRecord.IconSize = 30;
        btnPatientRecord.ImageAlign = ContentAlignment.MiddleRight;
        btnPatientRecord.Location = new Point(134, 22);
        btnPatientRecord.Name = "btnPatientRecord";
        btnPatientRecord.Size = new Size(174, 32);
        btnPatientRecord.TabIndex = 10;
        btnPatientRecord.Text = "Patient Record";
        btnPatientRecord.TextAlign = ContentAlignment.MiddleLeft;
        btnPatientRecord.UseVisualStyleBackColor = true;
        btnPatientRecord.Click += btnUpdateRecord_Click;
        // 
        // grpPatientOptions
        // 
        grpPatientOptions.Controls.Add(btnBookAppointment);
        grpPatientOptions.Controls.Add(btnAdmitPatient);
        grpPatientOptions.Controls.Add(btnViewPatientDetails);
        grpPatientOptions.Controls.Add(btnPatientRecord);
        grpPatientOptions.Location = new Point(382, 403);
        grpPatientOptions.Name = "grpPatientOptions";
        grpPatientOptions.Size = new Size(312, 98);
        grpPatientOptions.TabIndex = 11;
        grpPatientOptions.TabStop = false;
        grpPatientOptions.Text = "Patient Options";
        // 
        // btnBookAppointment
        // 
        btnBookAppointment.FlatStyle = FlatStyle.Flat;
        btnBookAppointment.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
        btnBookAppointment.IconColor = Color.Black;
        btnBookAppointment.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnBookAppointment.IconSize = 30;
        btnBookAppointment.ImageAlign = ContentAlignment.MiddleRight;
        btnBookAppointment.Location = new Point(134, 60);
        btnBookAppointment.Name = "btnBookAppointment";
        btnBookAppointment.Size = new Size(172, 32);
        btnBookAppointment.TabIndex = 11;
        btnBookAppointment.Text = "Book Appointment";
        btnBookAppointment.TextAlign = ContentAlignment.MiddleLeft;
        btnBookAppointment.UseVisualStyleBackColor = true;
        btnBookAppointment.Click += btnBookAppointment_Click;
        // 
        // CtrManagePatients
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        Controls.Add(grpPatientOptions);
        Controls.Add(txtSearch);
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
        grpPatientOptions.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblControlTitle;
    private GroupBox grpRegisterPatient;
    private ListView lvPatients;
    private TextBox txtSearch;
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
    private Label lblNHSNumber;
    private TextBox txtNHSNumber;
    private Label lblGender;
    private ComboBox cmbGender;
    private FontAwesome.Sharp.IconButton btnPatientRecord;
    private Label lblGPName;
    private TextBox txtGPName;
    private DateTimePicker dtpDateOfBirth;
    private Label lblDateOfBirth;
    private GroupBox grpPatientOptions;
    private FontAwesome.Sharp.IconButton btnBookAppointment;
}
