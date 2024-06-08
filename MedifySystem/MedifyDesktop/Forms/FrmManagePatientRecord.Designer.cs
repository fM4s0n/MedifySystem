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
        btnAddDataEntry = new FontAwesome.Sharp.IconButton();
        grpAddDataEntry = new GroupBox();
        lblType = new Label();
        cmbType = new ComboBox();
        txtData = new TextBox();
        lblData = new Label();
        grpAddDataEntry.SuspendLayout();
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
        flpPatientRecordDataEntries.Location = new Point(348, 100);
        flpPatientRecordDataEntries.Name = "flpPatientRecordDataEntries";
        flpPatientRecordDataEntries.Size = new Size(581, 477);
        flpPatientRecordDataEntries.TabIndex = 2;
        // 
        // btnAddDataEntry
        // 
        btnAddDataEntry.IconChar = FontAwesome.Sharp.IconChar.Plus;
        btnAddDataEntry.IconColor = Color.Black;
        btnAddDataEntry.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnAddDataEntry.IconSize = 30;
        btnAddDataEntry.ImageAlign = ContentAlignment.TopRight;
        btnAddDataEntry.Location = new Point(159, 438);
        btnAddDataEntry.Name = "btnAddDataEntry";
        btnAddDataEntry.Size = new Size(165, 33);
        btnAddDataEntry.TabIndex = 3;
        btnAddDataEntry.Text = "Submit Data Entry";
        btnAddDataEntry.TextAlign = ContentAlignment.MiddleLeft;
        btnAddDataEntry.UseVisualStyleBackColor = true;
        // 
        // grpAddDataEntry
        // 
        grpAddDataEntry.Controls.Add(lblData);
        grpAddDataEntry.Controls.Add(lblType);
        grpAddDataEntry.Controls.Add(cmbType);
        grpAddDataEntry.Controls.Add(txtData);
        grpAddDataEntry.Controls.Add(btnAddDataEntry);
        grpAddDataEntry.Location = new Point(12, 100);
        grpAddDataEntry.Name = "grpAddDataEntry";
        grpAddDataEntry.Size = new Size(330, 477);
        grpAddDataEntry.TabIndex = 4;
        grpAddDataEntry.TabStop = false;
        grpAddDataEntry.Text = "Add New Data Entry";
        // 
        // lblType
        // 
        lblType.AutoSize = true;
        lblType.Location = new Point(6, 30);
        lblType.Name = "lblType";
        lblType.Size = new Size(39, 16);
        lblType.TabIndex = 6;
        lblType.Text = "Type";
        // 
        // cmbType
        // 
        cmbType.FormattingEnabled = true;
        cmbType.Location = new Point(51, 27);
        cmbType.Name = "cmbType";
        cmbType.Size = new Size(273, 24);
        cmbType.TabIndex = 5;
        // 
        // txtData
        // 
        txtData.Location = new Point(6, 81);
        txtData.Multiline = true;
        txtData.Name = "txtData";
        txtData.Size = new Size(318, 351);
        txtData.TabIndex = 4;
        // 
        // lblData
        // 
        lblData.AutoSize = true;
        lblData.Location = new Point(6, 62);
        lblData.Name = "lblData";
        lblData.Size = new Size(42, 16);
        lblData.TabIndex = 7;
        lblData.Text = "Text:";
        // 
        // FrmManagePatientRecord
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        ClientSize = new Size(941, 580);
        Controls.Add(grpAddDataEntry);
        Controls.Add(flpPatientRecordDataEntries);
        Controls.Add(lblPatientName);
        Controls.Add(lblFormTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmManagePatientRecord";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Medify |  Patient Record";
        grpAddDataEntry.ResumeLayout(false);
        grpAddDataEntry.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFormTitle;
    private Label lblPatientName;
    private FlowLayoutPanel flpPatientRecordDataEntries;
    private FontAwesome.Sharp.IconButton btnAddDataEntry;
    private GroupBox grpAddDataEntry;
    private TextBox txtData;
    private Label lblType;
    private ComboBox cmbType;
    private Label lblData;
}