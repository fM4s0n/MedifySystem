using MedifySystem.MedifyCommon.Dictionaries;
using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyDesktop.Controls
{
    /// <summary>
    /// Item for flpHome on the home screen for headline information
    /// </summary>
    public partial class CtrFlpHomeItem : UserControl
    {
        public CtrFlpHomeItem(string titleText, string data, FlpHomeItemBackColour colour, string subData = "")
        {
            InitializeComponent();

            if (DesignMode)
                return;

            lblControlTitle.Text = titleText;
            lblControlHeadlineData.Text = data;
            lblControlSubData.Text = subData;
            BackColor = ColorTranslator.FromHtml(FlpHomeItemBackColourDictionary.GetColour(colour));

            CentraliseDataText();
            CentraliseTitleText();
        }

        private void CentraliseTitleText()
        {
            lblControlTitle.Location = new Point((Width - lblControlTitle.Width) / 2, lblControlTitle.Location.Y);
        }

        private void CentraliseDataText()
        {
            lblControlHeadlineData.Location = new Point((Width - lblControlHeadlineData.Width) / 2, lblControlHeadlineData.Location.Y);
        }
    }
}
