namespace MedifySystem.MedifyDesktop.Controls;

partial class CtrPatientRecordDataEntryPanelItem
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
        lblType = new Label();
        pbTitleImage = new FontAwesome.Sharp.IconPictureBox();
        txtData = new TextBox();
        lblDate = new Label();
        ((System.ComponentModel.ISupportInitialize)pbTitleImage).BeginInit();
        SuspendLayout();
        // 
        // lblType
        // 
        lblType.AutoSize = true;
        lblType.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblType.Location = new Point(2, 3);
        lblType.Margin = new Padding(2, 0, 2, 0);
        lblType.Name = "lblType";
        lblType.Size = new Size(230, 32);
        lblType.TabIndex = 0;
        lblType.Text = "Data entry type";
        // 
        // pbTitleImage
        // 
        pbTitleImage.BackColor = SystemColors.Control;
        pbTitleImage.ForeColor = SystemColors.ControlText;
        pbTitleImage.IconChar = FontAwesome.Sharp.IconChar.None;
        pbTitleImage.IconColor = SystemColors.ControlText;
        pbTitleImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
        pbTitleImage.IconSize = 70;
        pbTitleImage.Location = new Point(22, 57);
        pbTitleImage.Margin = new Padding(2);
        pbTitleImage.Name = "pbTitleImage";
        pbTitleImage.Size = new Size(70, 70);
        pbTitleImage.TabIndex = 1;
        pbTitleImage.TabStop = false;
        // 
        // txtData
        // 
        txtData.Location = new Point(120, 37);
        txtData.Multiline = true;
        txtData.Name = "txtData";
        txtData.ReadOnly = true;
        txtData.ScrollBars = ScrollBars.Vertical;
        txtData.Size = new Size(449, 110);
        txtData.TabIndex = 2;
        // 
        // lblDate
        // 
        lblDate.AutoSize = true;
        lblDate.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDate.Location = new Point(260, 11);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(158, 23);
        lblDate.TabIndex = 3;
        lblDate.Text = "Data entry date";
        // 
        // CtrPatientRecordDataEntryPanelItem
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblDate);
        Controls.Add(txtData);
        Controls.Add(pbTitleImage);
        Controls.Add(lblType);
        Font = new Font("Microsoft Sans Serif", 8.25F);
        Margin = new Padding(2);
        Name = "CtrPatientRecordDataEntryPanelItem";
        Size = new Size(572, 150);
        ((System.ComponentModel.ISupportInitialize)pbTitleImage).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblType;
    private FontAwesome.Sharp.IconPictureBox pbTitleImage;
    private TextBox txtData;
    private Label lblDate;
}
