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
        SuspendLayout();
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.Location = new Point(231, 9);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(210, 32);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "Patient Record";
        // 
        // FrmManagePatientRecord
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(728, 473);
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
}