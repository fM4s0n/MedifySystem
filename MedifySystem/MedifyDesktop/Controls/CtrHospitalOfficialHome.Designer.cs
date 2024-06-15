namespace MedifySystem.MedifyDesktop.Controls;

partial class CtrHospitalOfficialHome
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
        flpHome = new FlowLayoutPanel();
        SuspendLayout();
        // 
        // flpHome
        // 
        flpHome.Location = new Point(25, 27);
        flpHome.Name = "flpHome";
        flpHome.Size = new Size(642, 450);
        flpHome.TabIndex = 0;
        // 
        // CtrHospitalOfficialHome
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(flpHome);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "CtrHospitalOfficialHome";
        Size = new Size(696, 505);
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel flpHome;
}
