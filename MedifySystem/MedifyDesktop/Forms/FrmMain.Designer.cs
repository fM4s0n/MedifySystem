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
        pnlLogo = new Panel();
        pbLogo = new PictureBox();
        pnlTopBar = new Panel();
        lblWelcome = new Label();
        pnlMain = new Panel();
        pnlMenu.SuspendLayout();
        pnlLogo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
        pnlTopBar.SuspendLayout();
        SuspendLayout();
        // 
        // pnlMenu
        // 
        pnlMenu.BackColor = Color.FromArgb(58, 110, 165);
        pnlMenu.Controls.Add(flpMainMenu);
        pnlMenu.Controls.Add(pnlLogo);
        pnlMenu.Dock = DockStyle.Left;
        pnlMenu.Location = new Point(0, 0);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new Size(200, 458);
        pnlMenu.TabIndex = 0;
        // 
        // flpMainMenu
        // 
        flpMainMenu.AutoScroll = true;
        flpMainMenu.Dock = DockStyle.Fill;
        flpMainMenu.FlowDirection = FlowDirection.TopDown;
        flpMainMenu.Location = new Point(0, 85);
        flpMainMenu.Name = "flpMainMenu";
        flpMainMenu.Size = new Size(200, 373);
        flpMainMenu.TabIndex = 1;
        // 
        // pnlLogo
        // 
        pnlLogo.Controls.Add(pbLogo);
        pnlLogo.Dock = DockStyle.Top;
        pnlLogo.Location = new Point(0, 0);
        pnlLogo.Name = "pnlLogo";
        pnlLogo.Size = new Size(200, 85);
        pnlLogo.TabIndex = 0;
        // 
        // pbLogo
        // 
        pbLogo.Image = Properties.Resources.RectangleTransparentBackground;
        pbLogo.Location = new Point(12, 0);
        pbLogo.Name = "pbLogo";
        pbLogo.Size = new Size(180, 79);
        pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        pbLogo.TabIndex = 0;
        pbLogo.TabStop = false;
        // 
        // pnlTopBar
        // 
        pnlTopBar.BackColor = Color.White;
        pnlTopBar.Controls.Add(lblWelcome);
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Location = new Point(200, 0);
        pnlTopBar.Name = "pnlTopBar";
        pnlTopBar.Size = new Size(617, 60);
        pnlTopBar.TabIndex = 1;
        // 
        // lblWelcome
        // 
        lblWelcome.AutoSize = true;
        lblWelcome.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblWelcome.Location = new Point(6, 13);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(135, 32);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Welcome";
        // 
        // pnlMain
        // 
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(200, 60);
        pnlMain.Name = "pnlMain";
        pnlMain.Size = new Size(617, 398);
        pnlMain.TabIndex = 2;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(817, 458);
        Controls.Add(pnlMain);
        Controls.Add(pnlTopBar);
        Controls.Add(pnlMenu);
        MinimumSize = new Size(833, 497);
        Name = "FrmMain";
        Text = "Medify | Home";
        pnlMenu.ResumeLayout(false);
        pnlLogo.ResumeLayout(false);
        StartPosition = FormStartPosition.CenterScreen;
        ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlMenu;
    private Panel pnlTopBar;
    private Panel pnlLogo;
    private Panel pnlMain;
    private PictureBox pbLogo;
    private FlowLayoutPanel flpMainMenu;
    private Label lblWelcome;
}
