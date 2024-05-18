namespace MedifySystem;

partial class FrmMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlMenu = new Panel();
        panel1 = new Panel();
        pictureBox1 = new PictureBox();
        pnlTitleBar = new Panel();
        pnlDesktop = new Panel();
        pnlMenu.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pnlMenu
        // 
        pnlMenu.BackColor = Color.FromArgb(58, 110, 165);
        pnlMenu.Controls.Add(panel1);
        pnlMenu.Dock = DockStyle.Left;
        pnlMenu.Location = new Point(0, 0);
        pnlMenu.Margin = new Padding(3, 4, 3, 4);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new Size(263, 603);
        pnlMenu.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.Controls.Add(pictureBox1);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Margin = new Padding(3, 4, 3, 4);
        panel1.Name = "panel1";
        panel1.Size = new Size(263, 113);
        panel1.TabIndex = 0;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(78, 13);
        pictureBox1.Margin = new Padding(3, 4, 3, 4);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(100, 50);
        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // pnlTitleBar
        // 
        pnlTitleBar.BackColor = Color.White;
        pnlTitleBar.Dock = DockStyle.Top;
        pnlTitleBar.Location = new Point(263, 0);
        pnlTitleBar.Margin = new Padding(3, 4, 3, 4);
        pnlTitleBar.Name = "pnlTitleBar";
        pnlTitleBar.Size = new Size(669, 80);
        pnlTitleBar.TabIndex = 1;
        // 
        // pnlDesktop
        // 
        pnlDesktop.Dock = DockStyle.Fill;
        pnlDesktop.Location = new Point(263, 80);
        pnlDesktop.Margin = new Padding(3, 4, 3, 4);
        pnlDesktop.Name = "pnlDesktop";
        pnlDesktop.Size = new Size(669, 523);
        pnlDesktop.TabIndex = 2;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(932, 603);
        Controls.Add(pnlDesktop);
        Controls.Add(pnlTitleBar);
        Controls.Add(pnlMenu);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(950, 650);
        Name = "FrmMain";
        Text = "Medify | Home";
        pnlMenu.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlMenu;
    private Panel pnlTitleBar;
    private Panel panel1;
    private Panel pnlDesktop;
    private PictureBox pictureBox1;
}
