namespace MedifySystem.MedifyDesktop.Forms;

partial class FrmBookAppointment
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
        btnFormTitle = new Label();
        lblPatientFullName = new Label();
        cmbSelectHospitalOfficial = new ComboBox();
        lblSelectHospitalOfficial = new Label();
        btnConfirm = new FontAwesome.Sharp.IconButton();
        btnCancel = new FontAwesome.Sharp.IconButton();
        SuspendLayout();
        // 
        // btnFormTitle
        // 
        btnFormTitle.AutoSize = true;
        btnFormTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnFormTitle.Location = new Point(79, 9);
        btnFormTitle.Name = "btnFormTitle";
        btnFormTitle.Size = new Size(264, 32);
        btnFormTitle.TabIndex = 0;
        btnFormTitle.Text = "Book Appointment";
        // 
        // lblPatientFullName
        // 
        lblPatientFullName.AutoSize = true;
        lblPatientFullName.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPatientFullName.Location = new Point(123, 49);
        lblPatientFullName.Name = "lblPatientFullName";
        lblPatientFullName.Size = new Size(178, 23);
        lblPatientFullName.TabIndex = 1;
        lblPatientFullName.Text = "Pateint Full Name";
        // 
        // cmbSelectHospitalOfficial
        // 
        cmbSelectHospitalOfficial.FormattingEnabled = true;
        cmbSelectHospitalOfficial.Location = new Point(176, 95);
        cmbSelectHospitalOfficial.Name = "cmbSelectHospitalOfficial";
        cmbSelectHospitalOfficial.Size = new Size(194, 24);
        cmbSelectHospitalOfficial.TabIndex = 2;
        // 
        // lblSelectHospitalOfficial
        // 
        lblSelectHospitalOfficial.AutoSize = true;
        lblSelectHospitalOfficial.Location = new Point(18, 103);
        lblSelectHospitalOfficial.Name = "lblSelectHospitalOfficial";
        lblSelectHospitalOfficial.Size = new Size(152, 16);
        lblSelectHospitalOfficial.TabIndex = 5;
        lblSelectHospitalOfficial.Text = "Select Doctor/ Nurse:";
        // 
        // btnConfirm
        // 
        btnConfirm.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
        btnConfirm.IconColor = Color.Black;
        btnConfirm.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnConfirm.IconSize = 25;
        btnConfirm.ImageAlign = ContentAlignment.MiddleRight;
        btnConfirm.Location = new Point(305, 436);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Size = new Size(97, 39);
        btnConfirm.TabIndex = 6;
        btnConfirm.Text = "Confirm";
        btnConfirm.TextAlign = ContentAlignment.MiddleLeft;
        btnConfirm.UseVisualStyleBackColor = true;
        btnConfirm.Click += btnConfirm_Click;
        // 
        // btnCancel
        // 
        btnCancel.IconChar = FontAwesome.Sharp.IconChar.X;
        btnCancel.IconColor = Color.Black;
        btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnCancel.IconSize = 25;
        btnCancel.ImageAlign = ContentAlignment.BottomRight;
        btnCancel.Location = new Point(12, 436);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 39);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Cancel";
        btnCancel.TextAlign = ContentAlignment.MiddleLeft;
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmBookAppointment
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(414, 480);
        Controls.Add(btnCancel);
        Controls.Add(btnConfirm);
        Controls.Add(lblSelectHospitalOfficial);
        Controls.Add(cmbSelectHospitalOfficial);
        Controls.Add(lblPatientFullName);
        Controls.Add(btnFormTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmBookAppointment";
        StartPosition = FormStartPosition.CenterParent;
        Text = "FrmBookAppointment";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label btnFormTitle;
    private Label lblPatientFullName;
    private ComboBox cmbSelectHospitalOfficial;
    private Label lblSelectHospitalOfficial;
    private FontAwesome.Sharp.IconButton btnConfirm;
    private FontAwesome.Sharp.IconButton btnCancel;
}