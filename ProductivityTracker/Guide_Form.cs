using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductivityTracker
{
    public partial class Guide_Form : Form
    {
        string FirstName;
        string LastName;
        string Username;
        int page;

        public Guide_Form(string firstname, string lastname, string username)
        {
            InitializeComponent();
            Page1.BringToFront();
            panelButtons.BringToFront();
            page = 2;
            buttonBack.Enabled = false;

            FirstName = firstname;
            LastName = lastname;
            Username = username;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            pageCheckBack().BringToFront();
            panelButtons.BringToFront();

            if (page == 22)
            {
                buttonNext.Enabled = true;
            }
            
            if (page == 3)
            {
                buttonBack.Enabled = false;
            }

            page--;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            pageCheckNext().BringToFront();
            panelButtons.BringToFront();

            if (page == 21)
            {
                buttonNext.Enabled = false;
            }
            
            if (page == 2)
            {
                buttonBack.Enabled = true;
            }

            page++;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the Guide?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Activity_Form activity = new Activity_Form(FirstName, LastName, Username);
                this.Close();
                activity.Show();
            }
        }

        private Panel pageCheckNext()
        {
            if (page == 1)
                return Page1;
            else if (page == 2)
                return Page2;
            else if (page == 3)
                return Page3;
            else if (page == 4)
                return Page4;
            else if (page == 5)
                return Page5;
            else if (page == 6)
                return Page6;
            else if (page == 7)
                return Page7;
            else if (page == 8)
                return Page8;
            else if (page == 9)
                return Page9;
            else if (page == 10)
                return Page10;
            else if (page == 11)
                return Page11;
            else if (page == 12)
                return Page12;
            else if (page == 13)
                return Page13;
            else if (page == 14)
                return Page14;
            else if (page == 15)
                return Page15;
            else if (page == 16)
                return Page16;
            else if (page == 17)
                return Page17;
            else if (page == 18)
                return Page18;
            else if (page == 19)
                return Page19;
            else if (page == 20)
                return Page20;
            else if (page == 21)
                return Page21;
            return null;
        }
        
        private Panel pageCheckBack()
        {
            if (page == 3)
                return Page1;
            else if (page == 4)
                return Page2;
            else if (page == 5)
                return Page3;
            else if (page == 6)
                return Page4;
            else if (page == 7)
                return Page5;
            else if (page == 8)
                return Page6;
            else if (page == 9)
                return Page7;
            else if (page == 10)
                return Page8;
            else if (page == 11)
                return Page9;
            else if (page == 12)
                return Page10;
            else if (page == 13)
                return Page11;
            else if (page == 14)
                return Page12;
            else if (page == 15)
                return Page13;
            else if (page == 16)
                return Page14;
            else if (page == 17)
                return Page15;
            else if (page == 18)
                return Page16;
            else if (page == 19)
                return Page17;
            else if (page == 20)
                return Page18;
            else if (page == 21)
                return Page19;
            else
                return Page20;
        }
    }
}
