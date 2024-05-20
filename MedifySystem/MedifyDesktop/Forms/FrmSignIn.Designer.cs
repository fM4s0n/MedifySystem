namespace MedifySystem.MedifyDesktop.Forms;

partial class FrmSignIn
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
        pbLogo = new PictureBox();
        txtEmail = new TextBox();
        txtPassword = new TextBox();
        lblEmail = new Label();
        lblPassword = new Label();
        btnSignIn = new FontAwesome.Sharp.IconButton();
        btnCancel = new FontAwesome.Sharp.IconButton();
        btnCreateAccount = new FontAwesome.Sharp.IconButton();
        ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
        SuspendLayout();
        // 
        // pbLogo
        // 
        pbLogo.Image = Properties.Resources.RectangleTransparentBackground;
        pbLogo.Location = new Point(72, 12);
        pbLogo.Name = "pbLogo";
        pbLogo.Size = new Size(359, 130);
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
        pbLogo.TabIndex = 0;
        pbLogo.TabStop = false;
        // 
        // txtEmail
        // 
        txtEmail.Font = new Font("Verdana", 9.75F);
        txtEmail.Location = new Point(73, 179);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(358, 23);
        txtEmail.TabIndex = 1;
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Verdana", 9.75F);
        txtPassword.Location = new Point(73, 230);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(358, 23);
        txtPassword.TabIndex = 2;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Verdana", 9.75F);
        lblEmail.Location = new Point(73, 160);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(103, 16);
        lblEmail.TabIndex = 3;
        lblEmail.Text = "Email Address:";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Verdana", 9.75F);
        lblPassword.Location = new Point(73, 211);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(75, 16);
        lblPassword.TabIndex = 4;
        lblPassword.Text = "Password:";
        // 
        // btnSignIn
        // 
        btnSignIn.BackColor = Color.White;
        btnSignIn.FlatStyle = FlatStyle.Flat;
        btnSignIn.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
        btnSignIn.IconColor = Color.Black;
        btnSignIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnSignIn.IconSize = 30;
        btnSignIn.ImageAlign = ContentAlignment.MiddleRight;
        btnSignIn.Location = new Point(341, 268);
        btnSignIn.Name = "btnSignIn";
        btnSignIn.Size = new Size(90, 38);
        btnSignIn.TabIndex = 5;
        btnSignIn.Text = "Sign In";
        btnSignIn.TextAlign = ContentAlignment.MiddleLeft;
        btnSignIn.UseVisualStyleBackColor = false;
        btnSignIn.Click += btnSignIn_Click;
        // 
        // btnCancel
        // 
        btnCancel.BackColor = Color.White;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.IconChar = FontAwesome.Sharp.IconChar.X;
        btnCancel.IconColor = Color.Black;
        btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnCancel.IconSize = 25;
        btnCancel.ImageAlign = ContentAlignment.MiddleRight;
        btnCancel.Location = new Point(73, 268);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 38);
        btnCancel.TabIndex = 6;
        btnCancel.Text = "Cancel";
        btnCancel.TextAlign = ContentAlignment.MiddleLeft;
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.BackColor = Color.White;
        btnCreateAccount.FlatStyle = FlatStyle.Flat;
        btnCreateAccount.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
        btnCreateAccount.IconColor = Color.Black;
        btnCreateAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnCreateAccount.IconSize = 30;
        btnCreateAccount.ImageAlign = ContentAlignment.MiddleRight;
        btnCreateAccount.Location = new Point(175, 320);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(153, 38);
        btnCreateAccount.TabIndex = 7;
        btnCreateAccount.Text = "Create Account";
        btnCreateAccount.TextAlign = ContentAlignment.MiddleLeft;
        btnCreateAccount.UseVisualStyleBackColor = false;
        btnCreateAccount.Click += btnCreateAccount_Click;
        // 
        // FrmSignIn
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(511, 370);
        Controls.Add(btnCreateAccount);
        Controls.Add(btnCancel);
        Controls.Add(btnSignIn);
        Controls.Add(lblPassword);
        Controls.Add(lblEmail);
        Controls.Add(txtPassword);
        Controls.Add(txtEmail);
        Controls.Add(pbLogo);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmSignIn";
        Text = "Medify | Sign In";
        ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pbLogo;
    private TextBox txtEmail;
    private TextBox txtPassword;
    private Label lblEmail;
    private Label lblPassword;
    private FontAwesome.Sharp.IconButton btnSignIn;
    private FontAwesome.Sharp.IconButton btnCancel;
    private FontAwesome.Sharp.IconButton btnCreateAccount;
}