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
        lblWarnEmail = new Label();
        lblWarnPassword = new Label();
        lblNewPasswordHelp = new Label();
        lblNewPassword = new Label();
        txtNewPassword = new TextBox();
        btnConfirmReset = new FontAwesome.Sharp.IconButton();
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
        txtPassword.Location = new Point(69, 249);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(358, 23);
        txtPassword.TabIndex = 2;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Verdana", 9.75F);
        lblEmail.ForeColor = Color.White;
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
        lblPassword.ForeColor = Color.White;
        lblPassword.Location = new Point(69, 230);
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
        btnSignIn.Location = new Point(337, 379);
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
        btnCancel.Location = new Point(69, 379);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 38);
        btnCancel.TabIndex = 6;
        btnCancel.Text = "Cancel";
        btnCancel.TextAlign = ContentAlignment.MiddleLeft;
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblWarnEmail
        // 
        lblWarnEmail.AutoSize = true;
        lblWarnEmail.Font = new Font("Verdana", 9.75F);
        lblWarnEmail.ForeColor = Color.White;
        lblWarnEmail.Location = new Point(73, 205);
        lblWarnEmail.Name = "lblWarnEmail";
        lblWarnEmail.Size = new Size(204, 16);
        lblWarnEmail.TabIndex = 8;
        lblWarnEmail.Text = "Please enter an email address";
        lblWarnEmail.Visible = false;
        // 
        // lblWarnPassword
        // 
        lblWarnPassword.AutoSize = true;
        lblWarnPassword.Font = new Font("Verdana", 9.75F);
        lblWarnPassword.ForeColor = Color.White;
        lblWarnPassword.Location = new Point(69, 275);
        lblWarnPassword.Name = "lblWarnPassword";
        lblWarnPassword.Size = new Size(169, 16);
        lblWarnPassword.TabIndex = 9;
        lblWarnPassword.Text = "Please enter a password";
        lblWarnPassword.Visible = false;
        // 
        // lblNewPasswordHelp
        // 
        lblNewPasswordHelp.AutoSize = true;
        lblNewPasswordHelp.Font = new Font("Verdana", 9.75F);
        lblNewPasswordHelp.ForeColor = Color.White;
        lblNewPasswordHelp.Location = new Point(69, 350);
        lblNewPasswordHelp.Name = "lblNewPasswordHelp";
        lblNewPasswordHelp.Size = new Size(222, 16);
        lblNewPasswordHelp.TabIndex = 12;
        lblNewPasswordHelp.Text = "Please enter your new password";
        lblNewPasswordHelp.Visible = false;
        // 
        // lblNewPassword
        // 
        lblNewPassword.AutoSize = true;
        lblNewPassword.Font = new Font("Verdana", 9.75F);
        lblNewPassword.ForeColor = Color.White;
        lblNewPassword.Location = new Point(69, 305);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Size = new Size(75, 16);
        lblNewPassword.TabIndex = 11;
        lblNewPassword.Text = "Password:";
        lblNewPassword.Visible = false;
        // 
        // txtNewPassword
        // 
        txtNewPassword.Font = new Font("Verdana", 9.75F);
        txtNewPassword.Location = new Point(69, 324);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Size = new Size(358, 23);
        txtNewPassword.TabIndex = 10;
        txtNewPassword.Visible = false;
        // 
        // btnConfirmReset
        // 
        btnConfirmReset.BackColor = Color.White;
        btnConfirmReset.FlatStyle = FlatStyle.Flat;
        btnConfirmReset.IconChar = FontAwesome.Sharp.IconChar.Lock;
        btnConfirmReset.IconColor = Color.Black;
        btnConfirmReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnConfirmReset.IconSize = 30;
        btnConfirmReset.ImageAlign = ContentAlignment.MiddleRight;
        btnConfirmReset.Location = new Point(165, 379);
        btnConfirmReset.Name = "btnConfirmReset";
        btnConfirmReset.Size = new Size(166, 38);
        btnConfirmReset.TabIndex = 13;
        btnConfirmReset.Text = "Confirm Password";
        btnConfirmReset.TextAlign = ContentAlignment.MiddleLeft;
        btnConfirmReset.UseVisualStyleBackColor = false;
        btnConfirmReset.Visible = false;
        btnConfirmReset.Click += btnConfirmReset_Click;
        // 
        // FrmSignIn
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(58, 110, 165);
        ClientSize = new Size(511, 429);
        Controls.Add(btnConfirmReset);
        Controls.Add(lblNewPasswordHelp);
        Controls.Add(lblNewPassword);
        Controls.Add(txtNewPassword);
        Controls.Add(lblWarnPassword);
        Controls.Add(lblWarnEmail);
        Controls.Add(btnCancel);
        Controls.Add(btnSignIn);
        Controls.Add(lblPassword);
        Controls.Add(lblEmail);
        Controls.Add(txtPassword);
        Controls.Add(txtEmail);
        Controls.Add(pbLogo);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MaximizeBox = false;
        Name = "FrmSignIn";
        StartPosition = FormStartPosition.CenterParent;
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
    private Label lblWarnEmail;
    private Label lblWarnPassword;
    private Label lblNewPasswordHelp;
    private Label lblNewPassword;
    private TextBox txtNewPassword;
    private FontAwesome.Sharp.IconButton btnConfirmReset;
}