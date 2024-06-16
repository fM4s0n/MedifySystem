using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedifySystem.MedifyDesktop.Controls;
partial class CtrFlpHomeItem
{
    private void InitializeComponent()
    {
        lblControlTitle = new Label();
        lblControlHeadlineData = new Label();
        lblControlSubData = new Label();
        SuspendLayout();
        // 
        // lblControlTitle
        // 
        lblControlTitle.AutoSize = true;
        lblControlTitle.Font = new Font("Verdana", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblControlTitle.Location = new Point(8, 7);
        lblControlTitle.Name = "lblControlTitle";
        lblControlTitle.Size = new Size(180, 32);
        lblControlTitle.TabIndex = 0;
        lblControlTitle.Text = "Control Title";
        // 
        // lblControlHeadlineData
        // 
        lblControlHeadlineData.AutoSize = true;
        lblControlHeadlineData.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblControlHeadlineData.Location = new Point(123, 51);
        lblControlHeadlineData.Name = "lblControlHeadlineData";
        lblControlHeadlineData.Size = new Size(56, 59);
        lblControlHeadlineData.TabIndex = 1;
        lblControlHeadlineData.Text = "0";
        // 
        // lblControlSubData
        // 
        lblControlSubData.AutoSize = true;
        lblControlSubData.Location = new Point(3, 130);
        lblControlSubData.Name = "lblControlSubData";
        lblControlSubData.Size = new Size(115, 16);
        lblControlSubData.TabIndex = 2;
        lblControlSubData.Text = "Control SubData";
        // 
        // CtrFlpHomeItem
        // 
        Controls.Add(lblControlSubData);
        Controls.Add(lblControlHeadlineData);
        Controls.Add(lblControlTitle);
        Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Name = "CtrFlpHomeItem";
        Size = new Size(300, 148);
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblControlTitle;
    private Label lblControlHeadlineData;
    private Label lblControlSubData;
}
