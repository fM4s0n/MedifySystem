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
        lblData = new Label();
        lblType = new Label();
        cmbNewEntryType = new ComboBox();
        txtData = new TextBox();
        cmbFilterType = new ComboBox();
        lblFilterType = new Label();
        btnSearch = new FontAwesome.Sharp.IconButton();
        btnResetShowAll = new FontAwesome.Sharp.IconButton();
        txtSearch = new TextBox();
        lblSearchText = new Label();
        grpAddDataEntry.SuspendLayout();
        SuspendLayout();
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.Location = new Point(341, 9);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(210, 32);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "Patient Record";
        // 
        // lblPatientName
        // 
        lblPatientName.AutoSize = true;
        lblPatientName.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPatientName.Location = new Point(368, 50);
        lblPatientName.Name = "lblPatientName";
        lblPatientName.Size = new Size(155, 18);
        lblPatientName.TabIndex = 1;
        lblPatientName.Text = "Patient Full Name";
        // 
        // flpPatientRecordDataEntries
        // 
        flpPatientRecordDataEntries.AutoScroll = true;
        flpPatientRecordDataEntries.Location = new Point(348, 169);
        flpPatientRecordDataEntries.Name = "flpPatientRecordDataEntries";
        flpPatientRecordDataEntries.Size = new Size(604, 408);
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
        btnAddDataEntry.Click += btnAddDataEntry_Click;
        // 
        // grpAddDataEntry
        // 
        grpAddDataEntry.Controls.Add(lblData);
        grpAddDataEntry.Controls.Add(lblType);
        grpAddDataEntry.Controls.Add(cmbNewEntryType);
        grpAddDataEntry.Controls.Add(txtData);
        grpAddDataEntry.Controls.Add(btnAddDataEntry);
        grpAddDataEntry.Location = new Point(12, 100);
        grpAddDataEntry.Name = "grpAddDataEntry";
        grpAddDataEntry.Size = new Size(330, 477);
        grpAddDataEntry.TabIndex = 4;
        grpAddDataEntry.TabStop = false;
        grpAddDataEntry.Text = "Add New Data Entry";
        // 
        // lblData
        // 
        lblData.AutoSize = true;
        lblData.Location = new Point(6, 62);
        lblData.Name = "lblData";
        lblData.Size = new Size(78, 16);
        lblData.TabIndex = 7;
        lblData.Text = "Data Text:";
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
        cmbNewEntryType.FormattingEnabled = true;
        cmbNewEntryType.Location = new Point(51, 27);
        cmbNewEntryType.Name = "cmbType";
        cmbNewEntryType.Size = new Size(273, 24);
        cmbNewEntryType.TabIndex = 5;
        // 
        // txtData
        // 
        txtData.Location = new Point(6, 81);
        txtData.Multiline = true;
        txtData.Name = "txtData";
        txtData.Size = new Size(318, 351);
        txtData.TabIndex = 4;
        // 
        // cmbFilterType
        // 
        cmbFilterType.FormattingEnabled = true;
        cmbFilterType.Location = new Point(776, 100);
        cmbFilterType.Name = "cmbFilterType";
        cmbFilterType.Size = new Size(176, 24);
        cmbFilterType.TabIndex = 5;
        cmbFilterType.SelectedIndexChanged += cmbFilterType_SelectedIndexChanged;
        // 
        // lblFilterType
        // 
        lblFilterType.AutoSize = true;
        lblFilterType.Location = new Point(649, 105);
        lblFilterType.Name = "lblFilterType";
        lblFilterType.Size = new Size(123, 16);
        lblFilterType.TabIndex = 6;
        lblFilterType.Text = "Filter Entry Type:";
        // 
        // btnSearch
        // 
        btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
        btnSearch.IconColor = Color.Black;
        btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnSearch.IconSize = 30;
        btnSearch.ImageAlign = ContentAlignment.MiddleRight;
        btnSearch.Location = new Point(806, 130);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(146, 33);
        btnSearch.TabIndex = 7;
        btnSearch.Text = "Search Record";
        btnSearch.TextAlign = ContentAlignment.MiddleLeft;
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // btnResetShowAll
        // 
        btnResetShowAll.IconChar = FontAwesome.Sharp.IconChar.None;
        btnResetShowAll.IconColor = Color.Black;
        btnResetShowAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnResetShowAll.Location = new Point(348, 130);
        btnResetShowAll.Name = "btnResetShowAll";
        btnResetShowAll.Size = new Size(147, 33);
        btnResetShowAll.TabIndex = 8;
        btnResetShowAll.Text = "Reset and Show All";
        btnResetShowAll.UseVisualStyleBackColor = true;
        btnResetShowAll.Click += btnReset_Click;
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(447, 100);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(183, 23);
        txtSearch.TabIndex = 9;
        // 
        // lblSearchText
        // 
        lblSearchText.AutoSize = true;
        lblSearchText.Location = new Point(348, 103);
        lblSearchText.Name = "lblSearchText";
        lblSearchText.Size = new Size(93, 16);
        lblSearchText.TabIndex = 10;
        lblSearchText.Text = "Search Text:";
        // 
        // FrmManagePatientRecord
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LightGray;
        ClientSize = new Size(964, 586);
        Controls.Add(lblSearchText);
        Controls.Add(txtSearch);
        Controls.Add(btnResetShowAll);
        Controls.Add(btnSearch);
        Controls.Add(lblFilterType);
        Controls.Add(cmbFilterType);
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
    private ComboBox cmbNewEntryType;
    private Label lblData;
    private ComboBox cmbFilterType;
    private Label lblFilterType;
    private FontAwesome.Sharp.IconButton btnSearch;
    private FontAwesome.Sharp.IconButton btnResetShowAll;
    private TextBox txtSearch;
    private Label lblSearchText;
}