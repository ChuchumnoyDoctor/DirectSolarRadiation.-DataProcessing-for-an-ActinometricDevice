namespace PrPr5
{
    partial class CustomChart
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelDiagramma = new System.Windows.Forms.Panel();
            this.buttonCancelUvelechenie = new System.Windows.Forms.Button();
            this.buttonUvelichit = new System.Windows.Forms.Button();
            this.labelObnovlenie = new System.Windows.Forms.Label();
            this.pointValueShow1 = new PrPr5.PointValueShow();
            this.legBox1 = new PrPr5.LegBox();
            this.bitmapOfSeries1 = new PrPr5.BitmapOfSeries();
            this.LabelGGGGMMDD = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.timerForScreen = new System.Windows.Forms.Timer(this.components);
            this.panelDiagramma.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDiagramma
            // 
            this.panelDiagramma.BackColor = System.Drawing.Color.White;
            this.panelDiagramma.Controls.Add(this.buttonCancelUvelechenie);
            this.panelDiagramma.Controls.Add(this.buttonUvelichit);
            this.panelDiagramma.Controls.Add(this.labelObnovlenie);
            this.panelDiagramma.Controls.Add(this.pointValueShow1);
            this.panelDiagramma.Controls.Add(this.legBox1);
            this.panelDiagramma.Controls.Add(this.bitmapOfSeries1);
            this.panelDiagramma.Controls.Add(this.LabelGGGGMMDD);
            this.panelDiagramma.Controls.Add(this.labelData);
            this.panelDiagramma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDiagramma.Location = new System.Drawing.Point(0, 0);
            this.panelDiagramma.Name = "panelDiagramma";
            this.panelDiagramma.Size = new System.Drawing.Size(591, 286);
            this.panelDiagramma.TabIndex = 0;
            this.panelDiagramma.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomChart_Paint);
            // 
            // buttonCancelUvelechenie
            // 
            this.buttonCancelUvelechenie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCancelUvelechenie.Location = new System.Drawing.Point(114, 13);
            this.buttonCancelUvelechenie.Name = "buttonCancelUvelechenie";
            this.buttonCancelUvelechenie.Size = new System.Drawing.Size(82, 37);
            this.buttonCancelUvelechenie.TabIndex = 3;
            this.buttonCancelUvelechenie.Text = "Отменить увеличение";
            this.buttonCancelUvelechenie.UseVisualStyleBackColor = false;
            this.buttonCancelUvelechenie.Visible = false;
            this.buttonCancelUvelechenie.Click += new System.EventHandler(this.buttonCancelUvelechenie_Click);
            // 
            // buttonUvelichit
            // 
            this.buttonUvelichit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonUvelichit.Location = new System.Drawing.Point(396, 182);
            this.buttonUvelichit.Name = "buttonUvelichit";
            this.buttonUvelichit.Size = new System.Drawing.Size(82, 37);
            this.buttonUvelichit.TabIndex = 7;
            this.buttonUvelichit.Text = "Увеличить";
            this.buttonUvelichit.UseVisualStyleBackColor = false;
            this.buttonUvelichit.Visible = false;
            this.buttonUvelichit.Click += new System.EventHandler(this.buttonUvelichit_Click);
            // 
            // labelObnovlenie
            // 
            this.labelObnovlenie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelObnovlenie.AutoSize = true;
            this.labelObnovlenie.Location = new System.Drawing.Point(190, 250);
            this.labelObnovlenie.Name = "labelObnovlenie";
            this.labelObnovlenie.Size = new System.Drawing.Size(104, 13);
            this.labelObnovlenie.TabIndex = 6;
            this.labelObnovlenie.Text = "Обновление через:";
            // 
            // pointValueShow1
            // 
            this.pointValueShow1.BackColor = System.Drawing.Color.White;
            this.pointValueShow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pointValueShow1.Location = new System.Drawing.Point(193, 81);
            this.pointValueShow1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pointValueShow1.Name = "pointValueShow1";
            this.pointValueShow1.Size = new System.Drawing.Size(143, 82);
            this.pointValueShow1.TabIndex = 5;
            this.pointValueShow1.Visible = false;
            // 
            // legBox1
            // 
            this.legBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.legBox1.BackColor = System.Drawing.SystemColors.Control;
            this.legBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.legBox1.Location = new System.Drawing.Point(413, 13);
            this.legBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.legBox1.Name = "legBox1";
            this.legBox1.Size = new System.Drawing.Size(166, 150);
            this.legBox1.TabIndex = 4;
            // 
            // bitmapOfSeries1
            // 
            this.bitmapOfSeries1.BackColor = System.Drawing.Color.Transparent;
            this.bitmapOfSeries1.diapazon = 0;
            this.bitmapOfSeries1.EndIzmer = null;
            this.bitmapOfSeries1.isDS = false;
            this.bitmapOfSeries1.Location = new System.Drawing.Point(25, 69);
            this.bitmapOfSeries1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bitmapOfSeries1.Name = "bitmapOfSeries1";
            this.bitmapOfSeries1.Radius = 0;
            this.bitmapOfSeries1.Size = new System.Drawing.Size(150, 150);
            this.bitmapOfSeries1.StartIzmer = null;
            this.bitmapOfSeries1.StepIzmer = null;
            this.bitmapOfSeries1.TabIndex = 3;
            this.bitmapOfSeries1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDiagramma_MouseDown);
            this.bitmapOfSeries1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDiagramma_MouseMove);
            this.bitmapOfSeries1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bitmapOfSeries1_MouseUp);
            // 
            // LabelGGGGMMDD
            // 
            this.LabelGGGGMMDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelGGGGMMDD.AutoSize = true;
            this.LabelGGGGMMDD.Location = new System.Drawing.Point(88, 250);
            this.LabelGGGGMMDD.Name = "LabelGGGGMMDD";
            this.LabelGGGGMMDD.Size = new System.Drawing.Size(67, 13);
            this.LabelGGGGMMDD.TabIndex = 1;
            this.LabelGGGGMMDD.Text = "ГГГГММДД";
            // 
            // labelData
            // 
            this.labelData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(22, 250);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(52, 13);
            this.labelData.TabIndex = 1;
            this.labelData.Text = "labelData";
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSettings.Location = new System.Drawing.Point(25, 13);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(82, 37);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "Настройки диаграммы";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // timerForScreen
            // 
            this.timerForScreen.Interval = 5;
            this.timerForScreen.Tick += new System.EventHandler(this.timerForScreen_Tick);
            // 
            // CustomChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.panelDiagramma);
            this.Name = "CustomChart";
            this.Size = new System.Drawing.Size(591, 286);
            this.Load += new System.EventHandler(this.CustomChart_Load);
            this.Resize += new System.EventHandler(this.CustomChart_Resize_1);
            this.panelDiagramma.ResumeLayout(false);
            this.panelDiagramma.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDiagramma;
        private System.Windows.Forms.Label LabelGGGGMMDD;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Button buttonSettings;
        private BitmapOfSeries bitmapOfSeries1;
        private LegBox legBox1;
        private PointValueShow pointValueShow1;
        private System.Windows.Forms.Label labelObnovlenie;
        private System.Windows.Forms.Timer timerForScreen;
        private System.Windows.Forms.Button buttonUvelichit;
        private System.Windows.Forms.Button buttonCancelUvelechenie;
    }
}
