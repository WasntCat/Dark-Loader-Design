using System;
using System.Windows.Forms;

namespace LoaderDesgin.UI
{
    public partial class Main : Form
    {
        #region Form
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
        #endregion

        #region Button
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Logger.Clear();
            Logger.Text += " [--] Connecting to server. . ." + Environment.NewLine;

            if (guna2ComboBox1.SelectedIndex >= 0)
            {
                string selectedItem = guna2ComboBox1.SelectedItem.ToString();

                if (selectedItem == "Build [ Lite ]")
                {
                    Logger.Text += " [--] Loading Lite, please wait" + Environment.NewLine;

                }
                else if (selectedItem == "Build [ Full ]")
                {
                    Logger.Text += " [--] Loading Full, please wait" + Environment.NewLine;

                }
                else
                {
                    Logger.Text += " [//] Load Error, Invaild product Selection " + Environment.NewLine;
                }
            }
            else
            {
                Logger.Text += " [//] Selection Error, No product selected " + Environment.NewLine;
            }
        }
        #endregion
    }
}
