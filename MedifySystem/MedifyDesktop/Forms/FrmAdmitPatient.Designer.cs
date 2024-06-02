namespace MedifySystem.MedifyDesktop.Forms;

partial class FrmAdmitPatient
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
        lblFormTitle = new Label();
        btnCancel = new FontAwesome.Sharp.IconButton();
        btnAdmitPatient = new FontAwesome.Sharp.IconButton();
        lblPatientName = new Label();
        dtpAdmittance = new DateTimePicker();
        lblAdmittanceDate = new Label();
        lblHospitalOfficial = new Label();
        cmbHospitalOfficial = new ComboBox();
        lblReason = new Label();
        txtReason = new TextBox();
        SuspendLayout();
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.Location = new Point(134, 9);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(196, 32);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "Admit Pateint";
        // 
        // btnCancel
        // 
        btnCancel.IconChar = FontAwesome.Sharp.IconChar.X;
        btnCancel.IconColor = Color.Black;
        btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnCancel.IconSize = 25;
        btnCancel.ImageAlign = ContentAlignment.BottomRight;
        btnCancel.Location = new Point(12, 339);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(92, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.TextAlign = ContentAlignment.MiddleLeft;
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnAdmitPatient
        // 
        btnAdmitPatient.IconChar = FontAwesome.Sharp.IconChar.Hospital;
        btnAdmitPatient.IconColor = Color.Black;
        btnAdmitPatient.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnAdmitPatient.IconSize = 30;
        btnAdmitPatient.ImageAlign = ContentAlignment.MiddleRight;
        btnAdmitPatient.Location = new Point(337, 339);
        btnAdmitPatient.Name = "btnAdmitPatient";
        btnAdmitPatient.Size = new Size(135, 35);
        btnAdmitPatient.TabIndex = 2;
        btnAdmitPatient.Text = "Admit Patient";
        btnAdmitPatient.TextAlign = ContentAlignment.MiddleLeft;
        btnAdmitPatient.UseVisualStyleBackColor = true;
        btnAdmitPatient.Click += btnAdmitPatient_Click;
        // 
        // lblPatientName
        // 
        lblPatientName.AutoSize = true;
        lblPatientName.Location = new Point(184, 48);
        lblPatientName.Name = "lblPatientName";
        lblPatientName.Size = new Size(95, 16);
        lblPatientName.TabIndex = 3;
        lblPatientName.Text = "Patient Name";
        // 
        // dtpAdmittance
        // 
        dtpAdmittance.Location = new Point(217, 79);
        dtpAdmittance.Name = "dtpAdmittance";
        dtpAdmittance.Size = new Size(255, 23);
        dtpAdmittance.TabIndex = 4;
        // 
        // lblAdmittanceDate
        // 
        lblAdmittanceDate.AutoSize = true;
        lblAdmittanceDate.Location = new Point(12, 86);
        lblAdmittanceDate.Name = "lblAdmittanceDate";
        lblAdmittanceDate.Size = new Size(136, 16);
        lblAdmittanceDate.TabIndex = 5;
        lblAdmittanceDate.Text = "Date of Admittance";
        // 
        // lblHospitalOfficial
        // 
        lblHospitalOfficial.AutoSize = true;
        lblHospitalOfficial.Location = new Point(12, 119);
        lblHospitalOfficial.Name = "lblHospitalOfficial";
        lblHospitalOfficial.Size = new Size(190, 16);
        lblHospitalOfficial.TabIndex = 6;
        lblHospitalOfficial.Text = "Responsible Hospital Official";
        // 
        // cmbHospitalOfficial
        // 
        cmbHospitalOfficial.FormattingEnabled = true;
        cmbHospitalOfficial.Location = new Point(217, 116);
        cmbHospitalOfficial.Name = "cmbHospitalOfficial";
        cmbHospitalOfficial.Size = new Size(255, 24);
        cmbHospitalOfficial.TabIndex = 7;
        // 
        // lblReason
        // 
        lblReason.AutoSize = true;
        lblReason.Location = new Point(12, 164);
        lblReason.Name = "lblReason";
        lblReason.Size = new Size(157, 16);
        lblReason.TabIndex = 8;
        lblReason.Text = "Reason for Admittance";
        // 
        // txtReason
        // 
        txtReason.Location = new Point(217, 161);
        txtReason.Multiline = true;
        txtReason.Name = "txtReason";
        txtReason.Size = new Size(255, 172);
        txtReason.TabIndex = 9;
        // 
        // FrmAdmitPatient
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        ClientSize = new Size(481, 386);
        Controls.Add(txtReason);
        Controls.Add(lblReason);
        Controls.Add(cmbHospitalOfficial);
        Controls.Add(lblHospitalOfficial);
        Controls.Add(lblAdmittanceDate);
        Controls.Add(dtpAdmittance);
        Controls.Add(lblPatientName);
        Controls.Add(btnAdmitPatient);
        Controls.Add(btnCancel);
        Controls.Add(lblFormTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmAdmitPatient";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Medify | Admit Pateint";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFormTitle;
    private FontAwesome.Sharp.IconButton btnCancel;
    private FontAwesome.Sharp.IconButton btnAdmitPatient;
    private Label lblPatientName;
    private DateTimePicker dtpAdmittance;
    private Label lblAdmittanceDate;
    private Label lblHospitalOfficial;
    private ComboBox cmbHospitalOfficial;
    private Label lblReason;
    private TextBox txtReason;
}