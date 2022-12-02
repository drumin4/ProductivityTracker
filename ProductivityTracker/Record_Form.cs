using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProductivityTracker
{
    public partial class Record_Form : Form
    {
        GlobalConfig Connection;
        static private string DatePerformed;
        static private Dictionary<string, List<KeyValuePair<string, string>>> ActivityAndPerformance;
        static private string[] DateStarted;
        static private string Username;
        static private string FirstName;
        static private string LastName;

        public Record_Form(string firstname, string lastname, string username)
        {
            InitializeComponent();
            Connection = new GlobalConfig();

            FirstName = firstname;
            LastName = lastname;
            Username = username;

            GetRecords();
        }

        public Record_Form(string datePerformed, Dictionary<string, List<KeyValuePair<string, string>>> activityAndPerformance, string[] dateStarted, string username, string firstname, string lastname)
        {
            InitializeComponent();
            Connection = new GlobalConfig();

            FirstName = firstname;
            LastName = lastname;
            Username = username;
            DatePerformed = datePerformed;
            DateStarted = dateStarted;
            ActivityAndPerformance = activityAndPerformance;
            AddRecords(DatePerformed, ActivityAndPerformance, DateStarted, Username);
            GetRecords();
        }

        private void GetChart()
        {
            List<TimeSpan> allTimesLeft = new List<TimeSpan>();
            string Query = $"select top 5 Performance from RecordTable where Username = '{Username}' and RecordName = '{textBoxSearchActivity.Text}' order by DatePerformed";
            DataTable dataTable = Connection.GetData(Query);
            string timeTargetedString = dataTable.Rows[0][0].ToString().Substring(11, 8);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string timePerformed = dataTable.Rows[i][0].ToString().Substring(0, 8);

                allTimesLeft.Add(TimeSpan.Parse(timePerformed));
            }

            if(allTimesLeft.Count >= 5)
            {
                chartPerformance.Series.Add(new LineSeries()
                {
                    Title = textBoxSearchActivity.Text + " Performance",
                    Values = new ChartValues<double> { allTimesLeft[0].TotalMinutes, allTimesLeft[1].TotalMinutes, allTimesLeft[2].TotalMinutes, allTimesLeft[3].TotalMinutes, allTimesLeft[4].TotalMinutes },

                    PointGeometrySize = 13

                });
            }
            else if (allTimesLeft.Count == 4)
            {
                chartPerformance.Series.Add(new LineSeries
                {
                    Title = textBoxSearchActivity.Text + " Performance",
                    Values = new ChartValues<double> { allTimesLeft[0].TotalMinutes, allTimesLeft[1].TotalMinutes, allTimesLeft[2].TotalMinutes, allTimesLeft[3].TotalMinutes },

                    PointGeometrySize = 13

                });
            }
            else if (allTimesLeft.Count == 3)
            {
                chartPerformance.Series.Add(new LineSeries
                {
                    Title = textBoxSearchActivity.Text + " Performance",
                    Values = new ChartValues<double> { allTimesLeft[0].TotalMinutes, allTimesLeft[1].TotalMinutes, allTimesLeft[2].TotalMinutes },

                    PointGeometrySize = 13

                });
            }
            else if (allTimesLeft.Count == 2)
            {
                chartPerformance.Series.Add(new LineSeries
                {
                    Title = textBoxSearchActivity.Text + " Performance",
                    Values = new ChartValues<double> { allTimesLeft[0].TotalMinutes, allTimesLeft[1].TotalMinutes },

                    PointGeometrySize = 13

                });
            }
            else if (allTimesLeft.Count == 1)
            {
                chartPerformance.Series.Add(new LineSeries
                {
                    Title = textBoxSearchActivity.Text + " Performance",
                    Values = new ChartValues<double> { allTimesLeft[0].TotalMinutes },

                    PointGeometrySize = 13

                });
            }

            TimeSpan timeTargetedTimeSpan = TimeSpan.Parse(timeTargetedString);
            double timeTargeted = timeTargetedTimeSpan.TotalMinutes;
            chartPerformance.Series.Add(new LineSeries
            {
                Title = "Targeted Time",
                Values = new ChartValues<double> { timeTargeted, timeTargeted, timeTargeted, timeTargeted, timeTargeted },

                PointGeometry = null
            });

            chartPerformance.LegendLocation = LegendLocation.Right;

            chartPerformance.AxisX.Add(
            new Axis
            {
                MaxValue = 4,
                Title = "Last 5 records",
                Labels = new[] { "-4", "-3", "-2", "-1", "0" }
            });
        }

        private void GetRecords()
        {
            if (textBoxSearchActivity.Text == "")
            {
                string QueryToShow = $"select DatePerformed, RecordName, DateStarted, Performance from RecordTable where Username = '{Username}' order by DatePerformed DESC, RecordName ASC";
                listRecords.DataSource = Connection.GetData(QueryToShow);
            }
        }

        private void textBoxSearchActivity_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSearchActivity.Text == "")
            {
                string QueryToShow = $"select DatePerformed, RecordName, DateStarted, Performance from RecordTable where Username = '{Username}' order by DatePerformed DESC, RecordName ASC";
                listRecords.DataSource = Connection.GetData(QueryToShow);
            }
        }

        private bool rowSelected(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != listRecords.Rows.Count - 1 && e.RowIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void listRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isRow = rowSelected(e);
            if (isRow)
            {
                textBoxSearchActivity.Text = listRecords.SelectedRows[0].Cells[1].Value.ToString();

                chartPerformance.Series.Clear();
                chartPerformance.AxisX.Clear();

                GetChart();
            }  
        }

        private void AddRecords(string datePerformed, Dictionary<string, List<KeyValuePair<string, string>>> activityAndPerformance, string[] dateStarted, string username)
        {
            int i = -1;

            foreach(KeyValuePair<string, List<KeyValuePair<string, string>>> kvp in activityAndPerformance)
            {
                i++;

                string Query = $"insert into RecordTable values ('{DatePerformed}', '{kvp.Key}', '{DateStarted[i]}', '{$"{kvp.Value[0].Key} / {kvp.Value[0].Value}"}', '{Username}')";
                Connection.SetData(Query);
            }
        }

        private void buttonSearchRecord_Click(object sender, EventArgs e)
        {
            if(textBoxSearchActivity.Text != "")
            {
                string ActivityName = textBoxSearchActivity.Text;
                string QueryToShow = $"select DatePerformed, RecordName, DateStarted, Performance from RecordTable where Username = '{Username}' and RecordName = '{ActivityName}' order by DatePerformed DESC";
                listRecords.DataSource = Connection.GetData(QueryToShow);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormMover.ReleaseCapture();
                FormMover.SendMessage(Handle, FormMover.WM_NCLBUTTONDOWN, FormMover.HT_CAPTION, 0);
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormMover.ReleaseCapture();
                FormMover.SendMessage(Handle, FormMover.WM_NCLBUTTONDOWN, FormMover.HT_CAPTION, 0);
            }
        }

        private void buttonToAddActivity_Click(object sender, EventArgs e)
        {
            Category_Form category = new Category_Form(FirstName, LastName, Username);
            category.Show();
            this.Hide();
        }

        private void buttonToAddActivity_MouseEnter(object sender, EventArgs e)
        {
            buttonToAddActivity.BackColor = Color.Sienna;
        }

        private void buttonToAddActivity_MouseLeave(object sender, EventArgs e)
        {
            buttonToAddActivity.BackColor = Color.Transparent;
        }

        private void buttonToAddActivity_MouseDown(object sender, MouseEventArgs e)
        {
            buttonToAddActivity.BackColor = Color.SaddleBrown;
        }

        private void buttonToAddActivity_MouseUp(object sender, MouseEventArgs e)
        {
            buttonToAddActivity.BackColor = Color.Sienna;
        }

        private void buttonToTracker_Click(object sender, EventArgs e)
        {
            Activity_Form activity = new Activity_Form(FirstName, LastName, Username);
            activity.Show();
            this.Hide();
        }

        private void buttonToTracker_MouseEnter(object sender, EventArgs e)
        {
            buttonToTracker.BackColor = Color.Sienna;
        }

        private void buttonToTracker_MouseLeave(object sender, EventArgs e)
        {
            buttonToTracker.BackColor = Color.Transparent;
        }

        private void buttonToTracker_MouseDown(object sender, MouseEventArgs e)
        {
            buttonToTracker.BackColor = Color.SaddleBrown;
        }

        private void buttonToTracker_MouseUp(object sender, MouseEventArgs e)
        {
            buttonToTracker.BackColor = Color.Sienna;
        }

        private void buttonToGuide_Click(object sender, EventArgs e)
        {
            Guide_Form guide = new Guide_Form(FirstName, LastName, Username);
            guide.Show();
            this.Hide();
        }

        private void buttonToGuide_MouseEnter(object sender, EventArgs e)
        {
            buttonToGuide.BackColor = Color.Sienna;
        }

        private void buttonToGuide_MouseLeave(object sender, EventArgs e)
        {
            buttonToGuide.BackColor = Color.Transparent;
        }

        private void buttonToGuide_MouseDown(object sender, MouseEventArgs e)
        {
            buttonToGuide.BackColor = Color.SaddleBrown;
        }

        private void buttonToGuide_MouseUp(object sender, MouseEventArgs e)
        {
            buttonToGuide.BackColor = Color.Sienna;
        }

        private void buttonToSignOut_Click(object sender, EventArgs e)
        {
            LoginOrRegister_Form login = new LoginOrRegister_Form();
            login.Show();
            this.Hide();
        }

        private void buttonToSignOut_MouseEnter(object sender, EventArgs e)
        {
            buttonToSignOut.BackColor = Color.Sienna;
        }

        private void buttonToSignOut_MouseLeave(object sender, EventArgs e)
        {
            buttonToSignOut.BackColor = Color.Transparent;
        }

        private void buttonToSignOut_MouseDown(object sender, MouseEventArgs e)
        {
            buttonToSignOut.BackColor = Color.SaddleBrown;
        }

        private void buttonToSignOut_MouseUp(object sender, MouseEventArgs e)
        {
            buttonToSignOut.BackColor = Color.Sienna;
        }

        private void listRecords_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            listRecords.ClearSelection();
        }
    }
}
