using MedifySystem.MedifyCommon.Dictionaries;
using MedifySystem.MedifyCommon.Enums;

namespace MedifySystem.MedifyDesktop.Controls
{
    /// <summary>
    /// Item for flpHome on the home screen for headline information
    /// </summary>
    public partial class CtrFlpHomeItem : UserControl
    {
        public CtrFlpHomeItem(string titleText, string data, string subData = "", FlpHomeItemBackColour colour)
        {
            InitializeComponent();

            if (DesignMode)
                return;

            lblControlTitle.Text = titleText;
            lblControlHeadlineData.Text = data;
            lblControlSubData.Text = subData;
            BackColor = ColorTranslator.FromHtml(FlpHomeItemBackColourDictionary.GetColour(colour));
        }
    }
}
