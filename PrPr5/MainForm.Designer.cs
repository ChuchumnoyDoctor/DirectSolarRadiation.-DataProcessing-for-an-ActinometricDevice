namespace PrPr5
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonGo2Diag = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonFAQinform = new System.Windows.Forms.Button();
            this.timerTakeDS = new System.Windows.Forms.Timer(this.components);
            this.timerObnovlenie = new System.Windows.Forms.Timer(this.components);
            this.bottomPanel1 = new PrPr5.BottomPanel();
            this.customChart1 = new PrPr5.CustomChart();
            this.SuspendLayout();
            // 
            // buttonGo2Diag
            // 
            this.buttonGo2Diag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGo2Diag.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonGo2Diag.Location = new System.Drawing.Point(5, 506);
            this.buttonGo2Diag.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGo2Diag.Name = "buttonGo2Diag";
            this.buttonGo2Diag.Size = new System.Drawing.Size(113, 35);
            this.buttonGo2Diag.TabIndex = 17;
            this.buttonGo2Diag.Text = "Вывести на диаграмму";
            this.buttonGo2Diag.UseVisualStyleBackColor = false;
            this.buttonGo2Diag.Click += new System.EventHandler(this.buttonGo2Diag_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(5, 545);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 35);
            this.button1.TabIndex = 20;
            this.button1.Text = "Сформировать результат";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 430);
            this.checkBox1.MaximumSize = new System.Drawing.Size(113, 35);
            this.checkBox1.MinimumSize = new System.Drawing.Size(113, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 35);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Автоматическое\r\n выполнение";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonFAQinform
            // 
            this.buttonFAQinform.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonFAQinform.Location = new System.Drawing.Point(202, 13);
            this.buttonFAQinform.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFAQinform.Name = "buttonFAQinform";
            this.buttonFAQinform.Size = new System.Drawing.Size(82, 37);
            this.buttonFAQinform.TabIndex = 22;
            this.buttonFAQinform.Text = "Справочная информация";
            this.buttonFAQinform.UseVisualStyleBackColor = false;
            this.buttonFAQinform.Click += new System.EventHandler(this.buttonFAQinform_Click);
            // 
            // timerTakeDS
            // 
            this.timerTakeDS.Tick += new System.EventHandler(this.timerTakeDS_Tick);
            // 
            // timerObnovlenie
            // 
            this.timerObnovlenie.Interval = 1000;
            this.timerObnovlenie.Tick += new System.EventHandler(this.timerObnovlenie_Tick);
            // 
            // bottomPanel1
            // 
            this.bottomPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel1.EndIzmer = null;
            this.bottomPanel1.filename = null;
            this.bottomPanel1.isDataSourceSeries = false;
            this.bottomPanel1.Location = new System.Drawing.Point(0, 415);
            this.bottomPanel1.Name = "bottomPanel1";
            this.bottomPanel1.Size = new System.Drawing.Size(1246, 215);
            this.bottomPanel1.StartIzmer = null;
            this.bottomPanel1.StepIzmer = null;
            this.bottomPanel1.TabIndex = 19;
            this.bottomPanel1.Resize += new System.EventHandler(this.bottomPanel1_Resize);
            // 
            // customChart1
            // 
            this.customChart1.BackColor = System.Drawing.Color.White;
            this.customChart1.diapazon = 0;
            this.customChart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customChart1.EndIzmer = null;
            this.customChart1.isDataSourceSeries = false;
            this.customChart1.Location = new System.Drawing.Point(0, 0);
            this.customChart1.Name = "customChart1";
            this.customChart1.Offset = 0;
            this.customChart1.radius = 0;
            this.customChart1.shagSec = 0;
            this.customChart1.Size = new System.Drawing.Size(1246, 409);
            this.customChart1.StartIzmer = null;
            this.customChart1.StepIzmer = null;
            this.customChart1.StepX = 45;
            this.customChart1.StepY = 24;
            this.customChart1.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1246, 630);
            this.Controls.Add(this.buttonFAQinform);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGo2Diag);
            this.Controls.Add(this.bottomPanel1);
            this.Controls.Add(this.customChart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1262, 669);
            this.MinimumSize = new System.Drawing.Size(1262, 669);
            this.Name = "MainForm";
            this.Text = "Многоэлементный измеритель прямой солнечной радиации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button buttonGo2Diag;
        private CustomChart customChart1;
        private BottomPanel bottomPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonFAQinform;
        private System.Windows.Forms.Timer timerTakeDS;
        private System.Windows.Forms.Timer timerObnovlenie;
    }
}