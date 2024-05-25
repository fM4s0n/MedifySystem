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
        flpMainMenu = new FlowLayoutPanel();
        panel1 = new Panel();
        pictureBox1 = new PictureBox();
        pnlTitleBar = new Panel();
        pnlMain = new Panel();
        pnlMenu.SuspendLayout();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pnlMenu
        // 
        pnlMenu.BackColor = Color.FromArgb(58, 110, 165);
        pnlMenu.Controls.Add(flpMainMenu);
        pnlMenu.Controls.Add(panel1);
        pnlMenu.Dock = DockStyle.Left;
        pnlMenu.Location = new Point(0, 0);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new Size(230, 458);
        pnlMenu.TabIndex = 0;
        // 
        // flpMainMenu
        // 
        flpMainMenu.AutoScroll = true;
        flpMainMenu.Dock = DockStyle.Fill;
        flpMainMenu.FlowDirection = FlowDirection.TopDown;
        flpMainMenu.Location = new Point(0, 85);
        flpMainMenu.Name = "flpMainMenu";
        flpMainMenu.Size = new Size(230, 373);
        flpMainMenu.TabIndex = 1;
        // 
        // panel1
        // 
        panel1.Controls.Add(pictureBox1);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(230, 85);
        panel1.TabIndex = 0;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = Properties.Resources.RectangleTransparentBackground;
        pictureBox1.Location = new Point(24, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(180, 79);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // pnlTitleBar
        // 
        pnlTitleBar.BackColor = Color.White;
        pnlTitleBar.Dock = DockStyle.Top;
        pnlTitleBar.Location = new Point(230, 0);
        pnlTitleBar.Name = "pnlTitleBar";
        pnlTitleBar.Size = new Size(587, 60);
        pnlTitleBar.TabIndex = 1;
        // 
        // pnlMain
        // 
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(230, 60);
        pnlMain.Name = "pnlMain";
        pnlMain.Size = new Size(587, 398);
        pnlMain.TabIndex = 2;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(817, 458);
        Controls.Add(pnlMain);
        Controls.Add(pnlTitleBar);
        Controls.Add(pnlMenu);
        MinimumSize = new Size(833, 497);
        Name = "FrmMain";
        Text = "Medify | Home";
        pnlMenu.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlMenu;
    private Panel pnlTitleBar;
    private Panel panel1;
    private Panel pnlMain;
    private PictureBox pictureBox1;
    private FlowLayoutPanel flpMainMenu;
}
