namespace MedifySystem.MedifyDesktop.Forms;

partial class FrmManagePatientRecord
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
        lblPatientName = new Label();
        flpPatientRecordDataEntries = new FlowLayoutPanel();
        SuspendLayout();
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.Location = new Point(309, 9);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(210, 32);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "Patient Record";
        // 
        // lblPatientName
        // 
        lblPatientName.AutoSize = true;
        lblPatientName.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPatientName.Location = new Point(336, 50);
        lblPatientName.Name = "lblPatientName";
        lblPatientName.Size = new Size(155, 18);
        lblPatientName.TabIndex = 1;
        lblPatientName.Text = "Patient Full Name";
        // 
        // flpPatientRecordDataEntries
        // 
        flpPatientRecordDataEntries.Location = new Point(231, 91);
        flpPatientRecordDataEntries.Name = "flpPatientRecordDataEntries";
        flpPatientRecordDataEntries.Size = new Size(572, 477);
        flpPatientRecordDataEntries.TabIndex = 2;
        // 
        // FrmManagePatientRecord
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        ClientSize = new Size(815, 580);
        Controls.Add(flpPatientRecordDataEntries);
        Controls.Add(lblPatientName);
        Controls.Add(lblFormTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmManagePatientRecord";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Medify |  Patient Record";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFormTitle;
    private Label lblPatientName;
    private FlowLayoutPanel flpPatientRecordDataEntries;
}