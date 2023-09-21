using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LoaderDesgin.UI.KAnim
{
    public partial class Splash : Form
    {
        #region Form
        public Splash()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            ScaleCube();

            var timer = new Timer();
            timer.Tick += (s, e) =>
            {
                angleX += Math.PI / 180; 
                angleY += Math.PI / 180; 
                Refresh();
            };
            timer.Interval = 17;
            timer.Start();
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Main Main = new Main();
            this.Hide();
            Main.Show();
            timer1.Enabled = false;
        }
        #endregion

        #region Cube/Object Drawer
        private double[][] lines = {
    new double[] {0, 0, 0},
    new double[] {1, 1, -1},
    new double[] {-1, 1, -1},
    new double[] {-1, -1, -1},
    new double[] {1, -1, -1}
};

        private int[][] Connectpoints = {
    new int[] {0, 1},
    new int[] {0, 2},
    new int[] {0, 3},
    new int[] {0, 4},
    new int[] {1, 2},
    new int[] {2, 3},
    new int[] {3, 4},
    new int[] {4, 1}
};

        private double angleX = 0.0;
        private double angleY = 0.0;
        private double scale = 100.0;
        private double perspective = 500;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.FromArgb(9, 9, 9));
            g.TranslateTransform(Width / 2, Height / 2);

            foreach (var edge in Connectpoints)
            {
                double[] xy1 = lines[edge[0]];
                double[] xy2 = lines[edge[1]];

                double x1 = xy1[0] * Math.Cos(angleY) - xy1[2] * Math.Sin(angleY);
                double z1 = xy1[2] * Math.Cos(angleY) + xy1[0] * Math.Sin(angleY);
                xy1[0] = x1;
                xy1[2] = z1;

                double x2 = xy2[0] * Math.Cos(angleY) - xy2[2] * Math.Sin(angleY);
                double z2 = xy2[2] * Math.Cos(angleY) + xy2[0] * Math.Sin(angleY);
                xy2[0] = x2;
                xy2[2] = z2;

                double perspective1 = perspective / (perspective + xy1[2]);
                double perspective2 = perspective / (perspective + xy2[2]);

                int screenX1 = (int)Math.Round(xy1[0] * perspective1);
                int screenY1 = (int)Math.Round(xy1[1] * perspective1);
                int screenX2 = (int)Math.Round(xy2[0] * perspective2);
                int screenY2 = (int)Math.Round(xy2[1] * perspective2);

                g.DrawLine(Pens.Crimson, screenX1, screenY1, screenX2, screenY2);
            }
        }
        private void ScaleCube()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    lines[i][j] *= scale;
                }
            }
        }
        #endregion
    }
}
