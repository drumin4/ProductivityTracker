using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductivityTracker
{
    public partial class Loading_Form : Form
    {
        int startPoint = 0;

        public Loading_Form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            verticalProgressBar.Value = startPoint;
            horizontalProgressBar.Value = startPoint;
            startPoint += 1;

            if (verticalProgressBar.Value == 100)
            {
                Thread.Sleep(3000);

                timer1.Stop();
                verticalProgressBar.Value = 0;
                horizontalProgressBar.Value = 0;
                LoginOrRegister_Form loginOrRegister_ = new LoginOrRegister_Form();
                loginOrRegister_.Show();
                this.Hide();
            }
        }

        private void Loading_Form_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
