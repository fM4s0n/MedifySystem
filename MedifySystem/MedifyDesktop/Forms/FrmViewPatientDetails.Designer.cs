namespace MedifySystem.MedifyDesktop.Forms;

partial class FrmViewPatientDetails
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblGPName = new Label();
        txtNewGPName = new TextBox();
        lblGender = new Label();
        cmbNewGender = new ComboBox();
        lblNHSNumber = new Label();
        txtNewNHSNumber = new TextBox();
        txtNewLastName = new TextBox();
        txtNewFirstName = new TextBox();
        lblLastName = new Label();
        lblFirstName = new Label();
        lblCurrentGPName = new Label();
        lblCurrentGender = new Label();
        lblCurrentNHSNumber = new Label();
        lblCurrentLastName = new Label();
        lblCurrentFirstName = new Label();
        lblTitle = new Label();
        btnSave = new FontAwesome.Sharp.IconButton();
        btnCancel = new FontAwesome.Sharp.IconButton();
        lblNewDetailsHeading = new Label();
        lblCurrentDetails = new Label();
        SuspendLayout();
        // 
        // lblGPName
        // 
        lblGPName.AutoSize = true;
        lblGPName.Location = new Point(17, 190);
        lblGPName.Name = "lblGPName";
        lblGPName.Size = new Size(65, 16);
        lblGPName.TabIndex = 25;
        lblGPName.Text = "GP Name";
        // 
        // txtNewGPName
        // 
        txtNewGPName.Location = new Point(327, 187);
        txtNewGPName.Name = "txtNewGPName";
        txtNewGPName.Size = new Size(244, 23);
        txtNewGPName.TabIndex = 24;
        // 
        // lblGender
        // 
        lblGender.AutoSize = true;
        lblGender.Location = new Point(15, 221);
        lblGender.Name = "lblGender";
        lblGender.Size = new Size(53, 16);
        lblGender.TabIndex = 21;
        lblGender.Text = "Gender";
        // 
        // cmbNewGender
        // 
        cmbNewGender.FormattingEnabled = true;
        cmbNewGender.Location = new Point(327, 218);
        cmbNewGender.Name = "cmbNewGender";
        cmbNewGender.Size = new Size(244, 24);
        cmbNewGender.TabIndex = 20;
        // 
        // lblNHSNumber
        // 
        lblNHSNumber.AutoSize = true;
        lblNHSNumber.Location = new Point(17, 159);
        lblNHSNumber.Name = "lblNHSNumber";
        lblNHSNumber.Size = new Size(88, 16);
        lblNHSNumber.TabIndex = 19;
        lblNHSNumber.Text = "NHS Number";
        // 
        // txtNewNHSNumber
        // 
        txtNewNHSNumber.Location = new Point(327, 156);
        txtNewNHSNumber.Name = "txtNewNHSNumber";
        txtNewNHSNumber.Size = new Size(244, 23);
        txtNewNHSNumber.TabIndex = 18;
        // 
        // txtNewLastName
        // 
        txtNewLastName.Location = new Point(327, 127);
        txtNewLastName.Name = "txtNewLastName";
        txtNewLastName.Size = new Size(244, 23);
        txtNewLastName.TabIndex = 17;
        // 
        // txtNewFirstName
        // 
        txtNewFirstName.Location = new Point(327, 96);
        txtNewFirstName.Name = "txtNewFirstName";
        txtNewFirstName.Size = new Size(244, 23);
        txtNewFirstName.TabIndex = 16;
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(17, 130);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(76, 16);
        lblLastName.TabIndex = 15;
        lblLastName.Text = "Last Name";
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(16, 99);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(77, 16);
        lblFirstName.TabIndex = 14;
        lblFirstName.Text = "First Name";
        // 
        // lblCurrentGPName
        // 
        lblCurrentGPName.AutoSize = true;
        lblCurrentGPName.Location = new Point(129, 187);
        lblCurrentGPName.Name = "lblCurrentGPName";
        lblCurrentGPName.Size = new Size(119, 16);
        lblCurrentGPName.TabIndex = 30;
        lblCurrentGPName.Text = "Current GP Name";
        // 
        // lblCurrentGender
        // 
        lblCurrentGender.AutoSize = true;
        lblCurrentGender.Location = new Point(129, 221);
        lblCurrentGender.Name = "lblCurrentGender";
        lblCurrentGender.Size = new Size(107, 16);
        lblCurrentGender.TabIndex = 29;
        lblCurrentGender.Text = "Current Gender";
        // 
        // lblCurrentNHSNumber
        // 
        lblCurrentNHSNumber.AutoSize = true;
        lblCurrentNHSNumber.Location = new Point(129, 159);
        lblCurrentNHSNumber.Name = "lblCurrentNHSNumber";
        lblCurrentNHSNumber.Size = new Size(142, 16);
        lblCurrentNHSNumber.TabIndex = 28;
        lblCurrentNHSNumber.Text = "Current NHS Number";
        // 
        // lblCurrentLastName
        // 
        lblCurrentLastName.AutoSize = true;
        lblCurrentLastName.Location = new Point(129, 130);
        lblCurrentLastName.Name = "lblCurrentLastName";
        lblCurrentLastName.Size = new Size(130, 16);
        lblCurrentLastName.TabIndex = 27;
        lblCurrentLastName.Text = "Current Last Name";
        // 
        // lblCurrentFirstName
        // 
        lblCurrentFirstName.AutoSize = true;
        lblCurrentFirstName.Location = new Point(129, 99);
        lblCurrentFirstName.Name = "lblCurrentFirstName";
        lblCurrentFirstName.Size = new Size(131, 16);
        lblCurrentFirstName.TabIndex = 26;
        lblCurrentFirstName.Text = "Current First Name";
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(188, 9);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(209, 32);
        lblTitle.TabIndex = 31;
        lblTitle.Text = "Patient Details";
        // 
        // btnSave
        // 
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
        btnSave.IconColor = Color.Black;
        btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnSave.IconSize = 25;
        btnSave.ImageAlign = ContentAlignment.MiddleRight;
        btnSave.Location = new Point(496, 260);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 32);
        btnSave.TabIndex = 32;
        btnSave.Text = "Save";
        btnSave.TextAlign = ContentAlignment.MiddleLeft;
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.IconChar = FontAwesome.Sharp.IconChar.X;
        btnCancel.IconColor = Color.Black;
        btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnCancel.IconSize = 25;
        btnCancel.ImageAlign = ContentAlignment.MiddleRight;
        btnCancel.Location = new Point(325, 260);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(87, 32);
        btnCancel.TabIndex = 33;
        btnCancel.Text = "Cancel";
        btnCancel.TextAlign = ContentAlignment.MiddleLeft;
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblNewDetailsHeading
        // 
        lblNewDetailsHeading.AutoSize = true;
        lblNewDetailsHeading.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNewDetailsHeading.Location = new Point(383, 57);
        lblNewDetailsHeading.Name = "lblNewDetailsHeading";
        lblNewDetailsHeading.Size = new Size(138, 25);
        lblNewDetailsHeading.TabIndex = 34;
        lblNewDetailsHeading.Text = "New Details";
        // 
        // lblCurrentDetails
        // 
        lblCurrentDetails.AutoSize = true;
        lblCurrentDetails.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblCurrentDetails.Location = new Point(117, 57);
        lblCurrentDetails.Name = "lblCurrentDetails";
        lblCurrentDetails.Size = new Size(172, 25);
        lblCurrentDetails.TabIndex = 35;
        lblCurrentDetails.Text = "Current Details";
        // 
        // FrmViewPatientDetails
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        ClientSize = new Size(585, 303);
        Controls.Add(lblCurrentDetails);
        Controls.Add(lblNewDetailsHeading);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(lblTitle);
        Controls.Add(lblCurrentGPName);
        Controls.Add(lblCurrentGender);
        Controls.Add(lblCurrentNHSNumber);
        Controls.Add(lblCurrentLastName);
        Controls.Add(lblCurrentFirstName);
        Controls.Add(lblGPName);
        Controls.Add(txtNewGPName);
        Controls.Add(lblGender);
        Controls.Add(cmbNewGender);
        Controls.Add(lblNHSNumber);
        Controls.Add(txtNewNHSNumber);
        Controls.Add(txtNewLastName);
        Controls.Add(txtNewFirstName);
        Controls.Add(lblLastName);
        Controls.Add(lblFirstName);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmViewPatientDetails";
        Text = "Medify | Patient Details";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblGPName;
    private TextBox txtNewGPName;
    private Label lblGender;
    private ComboBox cmbNewGender;
    private Label lblNHSNumber;
    private TextBox txtNewNHSNumber;
    private TextBox txtNewLastName;
    private TextBox txtNewFirstName;
    private Label lblLastName;
    private Label lblFirstName;
    private Label lblCurrentGPName;
    private Label lblCurrentGender;
    private Label lblCurrentNHSNumber;
    private Label lblCurrentLastName;
    private Label lblCurrentFirstName;
    private Label lblTitle;
    private FontAwesome.Sharp.IconButton btnSave;
    private FontAwesome.Sharp.IconButton btnCancel;
    private Label lblNewDetailsHeading;
    private Label lblCurrentDetails;
}