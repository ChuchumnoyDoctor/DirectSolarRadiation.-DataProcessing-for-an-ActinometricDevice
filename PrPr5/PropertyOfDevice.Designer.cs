namespace PrPr5
{
    partial class PropertyOfDevice
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
            this.groupBoxPropertyDevice = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNorth = new System.Windows.Forms.Label();
            this.labelSouth = new System.Windows.Forms.Label();
            this.labelWest = new System.Windows.Forms.Label();
            this.labelEast = new System.Windows.Forms.Label();
            this.drawRomashka1 = new PrPr5.DrawRomashka();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelVStart = new System.Windows.Forms.Label();
            this.labelStartIzmer = new System.Windows.Forms.Label();
            this.labelVDiapazon = new System.Windows.Forms.Label();
            this.labelDiapazon = new System.Windows.Forms.Label();
            this.labelVPlace = new System.Windows.Forms.Label();
            this.labelPlace = new System.Windows.Forms.Label();
            this.labelVStep = new System.Windows.Forms.Label();
            this.labelStepIzmer = new System.Windows.Forms.Label();
            this.labelVEnd = new System.Windows.Forms.Label();
            this.labelEndIzmer = new System.Windows.Forms.Label();
            this.buttonSetProperties = new System.Windows.Forms.Button();
            this.timerProverkyLepestkov = new System.Windows.Forms.Timer(this.components);
            this.groupBoxPropertyDevice.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPropertyDevice
            // 
            this.groupBoxPropertyDevice.BackColor = System.Drawing.Color.White;
            this.groupBoxPropertyDevice.Controls.Add(this.panel2);
            this.groupBoxPropertyDevice.Controls.Add(this.panel1);
            this.groupBoxPropertyDevice.Controls.Add(this.buttonSetProperties);
            this.groupBoxPropertyDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPropertyDevice.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPropertyDevice.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPropertyDevice.Name = "groupBoxPropertyDevice";
            this.groupBoxPropertyDevice.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPropertyDevice.Size = new System.Drawing.Size(413, 200);
            this.groupBoxPropertyDevice.TabIndex = 4;
            this.groupBoxPropertyDevice.TabStop = false;
            this.groupBoxPropertyDevice.Text = "Настройка конфигурации устройства измерения";
            this.groupBoxPropertyDevice.Resize += new System.EventHandler(this.groupBoxPropertyDevice_Resize);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelNorth);
            this.panel2.Controls.Add(this.labelSouth);
            this.panel2.Controls.Add(this.labelWest);
            this.panel2.Controls.Add(this.labelEast);
            this.panel2.Controls.Add(this.drawRomashka1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(258, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 183);
            this.panel2.TabIndex = 20;
            // 
            // labelNorth
            // 
            this.labelNorth.AutoSize = true;
            this.labelNorth.Location = new System.Drawing.Point(61, 13);
            this.labelNorth.Name = "labelNorth";
            this.labelNorth.Size = new System.Drawing.Size(14, 13);
            this.labelNorth.TabIndex = 21;
            this.labelNorth.Text = "C";
            // 
            // labelSouth
            // 
            this.labelSouth.AutoSize = true;
            this.labelSouth.Location = new System.Drawing.Point(59, 139);
            this.labelSouth.Name = "labelSouth";
            this.labelSouth.Size = new System.Drawing.Size(16, 13);
            this.labelSouth.TabIndex = 24;
            this.labelSouth.Text = "Ю";
            // 
            // labelWest
            // 
            this.labelWest.AutoSize = true;
            this.labelWest.Location = new System.Drawing.Point(8, 79);
            this.labelWest.Name = "labelWest";
            this.labelWest.Size = new System.Drawing.Size(14, 13);
            this.labelWest.TabIndex = 23;
            this.labelWest.Text = "З";
            // 
            // labelEast
            // 
            this.labelEast.AutoSize = true;
            this.labelEast.Location = new System.Drawing.Point(123, 79);
            this.labelEast.Name = "labelEast";
            this.labelEast.Size = new System.Drawing.Size(14, 13);
            this.labelEast.TabIndex = 22;
            this.labelEast.Text = "В";
            // 
            // drawRomashka1
            // 
            this.drawRomashka1.BackColor = System.Drawing.Color.White;
            this.drawRomashka1.Location = new System.Drawing.Point(20, 11);
            this.drawRomashka1.Margin = new System.Windows.Forms.Padding(4);
            this.drawRomashka1.Name = "drawRomashka1";
            this.drawRomashka1.Size = new System.Drawing.Size(126, 159);
            this.drawRomashka1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelVStart);
            this.panel1.Controls.Add(this.labelStartIzmer);
            this.panel1.Controls.Add(this.labelVDiapazon);
            this.panel1.Controls.Add(this.labelDiapazon);
            this.panel1.Controls.Add(this.labelVPlace);
            this.panel1.Controls.Add(this.labelPlace);
            this.panel1.Controls.Add(this.labelVStep);
            this.panel1.Controls.Add(this.labelStepIzmer);
            this.panel1.Controls.Add(this.labelVEnd);
            this.panel1.Controls.Add(this.labelEndIzmer);
            this.panel1.Location = new System.Drawing.Point(5, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 135);
            this.panel1.TabIndex = 19;
            // 
            // labelVStart
            // 
            this.labelVStart.AutoSize = true;
            this.labelVStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVStart.Location = new System.Drawing.Point(157, 7);
            this.labelVStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVStart.MaximumSize = new System.Drawing.Size(90, 15);
            this.labelVStart.MinimumSize = new System.Drawing.Size(90, 15);
            this.labelVStart.Name = "labelVStart";
            this.labelVStart.Size = new System.Drawing.Size(90, 15);
            this.labelVStart.TabIndex = 13;
            // 
            // labelStartIzmer
            // 
            this.labelStartIzmer.AutoSize = true;
            this.labelStartIzmer.Location = new System.Drawing.Point(5, 7);
            this.labelStartIzmer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartIzmer.Name = "labelStartIzmer";
            this.labelStartIzmer.Size = new System.Drawing.Size(153, 13);
            this.labelStartIzmer.TabIndex = 13;
            this.labelStartIzmer.Text = "Начало времени измерений:";
            // 
            // labelVDiapazon
            // 
            this.labelVDiapazon.AutoSize = true;
            this.labelVDiapazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVDiapazon.Location = new System.Drawing.Point(157, 89);
            this.labelVDiapazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVDiapazon.MaximumSize = new System.Drawing.Size(90, 15);
            this.labelVDiapazon.MinimumSize = new System.Drawing.Size(90, 15);
            this.labelVDiapazon.Name = "labelVDiapazon";
            this.labelVDiapazon.Size = new System.Drawing.Size(90, 15);
            this.labelVDiapazon.TabIndex = 16;
            // 
            // labelDiapazon
            // 
            this.labelDiapazon.AutoSize = true;
            this.labelDiapazon.Location = new System.Drawing.Point(5, 89);
            this.labelDiapazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDiapazon.Name = "labelDiapazon";
            this.labelDiapazon.Size = new System.Drawing.Size(120, 13);
            this.labelDiapazon.TabIndex = 16;
            this.labelDiapazon.Text = "Диапазон S\' (минуты):";
            // 
            // labelVPlace
            // 
            this.labelVPlace.AutoSize = true;
            this.labelVPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVPlace.Location = new System.Drawing.Point(157, 115);
            this.labelVPlace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVPlace.MaximumSize = new System.Drawing.Size(90, 15);
            this.labelVPlace.MinimumSize = new System.Drawing.Size(90, 15);
            this.labelVPlace.Name = "labelVPlace";
            this.labelVPlace.Size = new System.Drawing.Size(90, 15);
            this.labelVPlace.TabIndex = 16;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(5, 115);
            this.labelPlace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(98, 13);
            this.labelPlace.TabIndex = 16;
            this.labelPlace.Text = "Местоположение:";
            // 
            // labelVStep
            // 
            this.labelVStep.AutoSize = true;
            this.labelVStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVStep.Location = new System.Drawing.Point(157, 62);
            this.labelVStep.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVStep.MaximumSize = new System.Drawing.Size(90, 15);
            this.labelVStep.MinimumSize = new System.Drawing.Size(90, 15);
            this.labelVStep.Name = "labelVStep";
            this.labelVStep.Size = new System.Drawing.Size(90, 15);
            this.labelVStep.TabIndex = 16;
            // 
            // labelStepIzmer
            // 
            this.labelStepIzmer.AutoSize = true;
            this.labelStepIzmer.Location = new System.Drawing.Point(5, 62);
            this.labelStepIzmer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStepIzmer.Name = "labelStepIzmer";
            this.labelStepIzmer.Size = new System.Drawing.Size(148, 13);
            this.labelStepIzmer.TabIndex = 16;
            this.labelStepIzmer.Text = "Шаг измерений S\' (минуты):";
            // 
            // labelVEnd
            // 
            this.labelVEnd.AutoSize = true;
            this.labelVEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelVEnd.Location = new System.Drawing.Point(157, 35);
            this.labelVEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVEnd.MaximumSize = new System.Drawing.Size(90, 15);
            this.labelVEnd.MinimumSize = new System.Drawing.Size(90, 15);
            this.labelVEnd.Name = "labelVEnd";
            this.labelVEnd.Size = new System.Drawing.Size(90, 15);
            this.labelVEnd.TabIndex = 15;
            // 
            // labelEndIzmer
            // 
            this.labelEndIzmer.AutoSize = true;
            this.labelEndIzmer.Location = new System.Drawing.Point(5, 35);
            this.labelEndIzmer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndIzmer.Name = "labelEndIzmer";
            this.labelEndIzmer.Size = new System.Drawing.Size(147, 13);
            this.labelEndIzmer.TabIndex = 15;
            this.labelEndIzmer.Text = "Конец времени измерений:";
            // 
            // buttonSetProperties
            // 
            this.buttonSetProperties.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSetProperties.Location = new System.Drawing.Point(5, 155);
            this.buttonSetProperties.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetProperties.Name = "buttonSetProperties";
            this.buttonSetProperties.Size = new System.Drawing.Size(104, 41);
            this.buttonSetProperties.TabIndex = 12;
            this.buttonSetProperties.Text = "Настройки";
            this.buttonSetProperties.UseVisualStyleBackColor = false;
            this.buttonSetProperties.Click += new System.EventHandler(this.button2_Click);
            // 
            // timerProverkyLepestkov
            // 
            this.timerProverkyLepestkov.Interval = 1;
            this.timerProverkyLepestkov.Tick += new System.EventHandler(this.timerProverkyLepestkov_Tick);
            // 
            // PropertyOfDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPropertyDevice);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PropertyOfDevice";
            this.Size = new System.Drawing.Size(413, 200);
            this.Load += new System.EventHandler(this.PropertyOfDevice_Load);
            this.groupBoxPropertyDevice.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxPropertyDevice;
        private System.Windows.Forms.Button buttonSetProperties;
        private System.Windows.Forms.Label labelStartIzmer;
        private System.Windows.Forms.Label labelEndIzmer;
        private System.Windows.Forms.Label labelStepIzmer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public DrawRomashka drawRomashka1;
        private System.Windows.Forms.Timer timerProverkyLepestkov;
        public System.Windows.Forms.Label labelVStart;
        public System.Windows.Forms.Label labelVStep;
        public System.Windows.Forms.Label labelVEnd;
        private System.Windows.Forms.Label labelNorth;
        private System.Windows.Forms.Label labelSouth;
        private System.Windows.Forms.Label labelWest;
        private System.Windows.Forms.Label labelEast;
        public System.Windows.Forms.Label labelVPlace;
        private System.Windows.Forms.Label labelPlace;
        public System.Windows.Forms.Label labelVDiapazon;
        private System.Windows.Forms.Label labelDiapazon;
    }
}
