namespace MedifySystem.MedifyDesktop.Forms;

partial class FrmBookAppointment
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
        btnFormTitle = new Label();
        lblPatientFullName = new Label();
        comboBox1 = new ComboBox();
        dateTimePicker1 = new DateTimePicker();
        monthCalendar1 = new MonthCalendar();
        SuspendLayout();
        // 
        // btnFormTitle
        // 
        btnFormTitle.AutoSize = true;
        btnFormTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnFormTitle.Location = new Point(106, 9);
        btnFormTitle.Name = "btnFormTitle";
        btnFormTitle.Size = new Size(264, 32);
        btnFormTitle.TabIndex = 0;
        btnFormTitle.Text = "Book Appointment";
        // 
        // lblPatientFullName
        // 
        lblPatientFullName.AutoSize = true;
        lblPatientFullName.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPatientFullName.Location = new Point(150, 49);
        lblPatientFullName.Name = "lblPatientFullName";
        lblPatientFullName.Size = new Size(178, 23);
        lblPatientFullName.TabIndex = 1;
        lblPatientFullName.Text = "Pateint Full Name";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(63, 130);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 24);
        comboBox1.TabIndex = 2;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new Point(63, 199);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new Size(200, 23);
        dateTimePicker1.TabIndex = 3;
        // 
        // monthCalendar1
        // 
        monthCalendar1.CalendarDimensions = new Size(2, 2);
        monthCalendar1.Location = new Point(587, 112);
        monthCalendar1.Name = "monthCalendar1";
        monthCalendar1.TabIndex = 4;
        // 
        // FrmBookAppointment
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1195, 480);
        Controls.Add(monthCalendar1);
        Controls.Add(dateTimePicker1);
        Controls.Add(comboBox1);
        Controls.Add(lblPatientFullName);
        Controls.Add(btnFormTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "FrmBookAppointment";
        StartPosition = FormStartPosition.CenterParent;
        Text = "FrmBookAppointment";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label btnFormTitle;
    private Label lblPatientFullName;
    private ComboBox comboBox1;
    private DateTimePicker dateTimePicker1;
    private MonthCalendar monthCalendar1;
}