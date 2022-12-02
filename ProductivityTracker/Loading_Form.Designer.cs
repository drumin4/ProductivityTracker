namespace ProductivityTracker
{
    partial class Loading_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading_Form));
            this.horizontalProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.verticalProgressBar = new Guna.UI2.WinForms.Guna2VProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontalProgressBar
            // 
            this.horizontalProgressBar.FillColor = System.Drawing.Color.Peru;
            this.horizontalProgressBar.ForeColor = System.Drawing.Color.BurlyWood;
            this.horizontalProgressBar.Location = new System.Drawing.Point(0, 388);
            this.horizontalProgressBar.Name = "horizontalProgressBar";
            this.horizontalProgressBar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition;
            this.horizontalProgressBar.ProgressColor = System.Drawing.Color.Chocolate;
            this.horizontalProgressBar.ProgressColor2 = System.Drawing.Color.Sienna;
            this.horizontalProgressBar.Size = new System.Drawing.Size(806, 19);
            this.horizontalProgressBar.TabIndex = 3;
            this.horizontalProgressBar.Text = "guna2ProgressBar2";
            this.horizontalProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.verticalProgressBar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(172, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 288);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lemon", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Peru;
            this.label1.Location = new System.Drawing.Point(14, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "TimeEclipse";
            // 
            // verticalProgressBar
            // 
            this.verticalProgressBar.FillColor = System.Drawing.Color.Peru;
            this.verticalProgressBar.Location = new System.Drawing.Point(44, -12);
            this.verticalProgressBar.Name = "verticalProgressBar";
            this.verticalProgressBar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition;
            this.verticalProgressBar.ProgressColor = System.Drawing.Color.Chocolate;
            this.verticalProgressBar.ProgressColor2 = System.Drawing.Color.Sienna;
            this.verticalProgressBar.Size = new System.Drawing.Size(19, 462);
            this.verticalProgressBar.TabIndex = 5;
            this.verticalProgressBar.Text = "guna2vProgressBar1";
            this.verticalProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(675, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version 1.0";
            // 
            // timer1
            // 
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // Loading_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.horizontalProgressBar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading_Form";
            this.Load += new System.EventHandler(this.Loading_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ProgressBar horizontalProgressBar;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2VProgressBar verticalProgressBar;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Panel panel2;
    }
}