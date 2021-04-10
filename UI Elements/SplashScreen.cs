using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace President.UI_Elements
{
    public partial class SplashScreen : Form
    {
        public SplashScreen(bool withTimer)
        {
            InitializeComponent();
            if (!withTimer)
                timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void SplashScreen_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void SplashScreen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
