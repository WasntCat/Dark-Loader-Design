using System;
using System.Windows.Forms;

namespace LoaderDesgin
{
    public partial class Login : Form
    {
        #region Form
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
        #endregion

        #region Button
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UI.KAnim.Splash Splash = new UI.KAnim.Splash();
            this.Hide();
            Splash.Show();
        }
        #endregion
    }
}
