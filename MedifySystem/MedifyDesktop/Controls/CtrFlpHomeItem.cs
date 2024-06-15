namespace MedifySystem.MedifyDesktop.Controls
{
    /// <summary>
    /// Item for flpHome on the home screen for headline information
    /// </summary>
    public partial class CtrFlpHomeItem : UserControl
    {
        public CtrFlpHomeItem(string titleText, string data, string subData = "", )
        {
            InitializeComponent();

            if (DesignMode)
                return;

            lblControlTitle.Text = titleText;
            lblControlHeadlineData.Text = data;
            lblControlSubData.Text = subData;
        }

    }
}
