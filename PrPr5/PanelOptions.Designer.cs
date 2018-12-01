namespace PrPr5
{
    partial class PanelOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelOptions));
            this.labelStepIzmer = new System.Windows.Forms.Label();
            this.labelEndIzmer = new System.Windows.Forms.Label();
            this.checkBoxSelectManSet = new System.Windows.Forms.CheckBox();
            this.labelStartIzmer = new System.Windows.Forms.Label();
            this.groupBoxManualSetting = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxStepIzmer = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxEndIzmer = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxStartIzmer = new System.Windows.Forms.MaskedTextBox();
            this.buttonCalibration = new System.Windows.Forms.Button();
            this.labelKalibrovkaDescription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxOpisanie = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxShirota = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxDolgota = new System.Windows.Forms.MaskedTextBox();
            this.labelDiapazon = new System.Windows.Forms.Label();
            this.maskedTextBoxDiapazon = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxManualSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStepIzmer
            // 
            this.labelStepIzmer.AutoSize = true;
            this.labelStepIzmer.Enabled = false;
            this.labelStepIzmer.Location = new System.Drawing.Point(5, 80);
            this.labelStepIzmer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStepIzmer.Name = "labelStepIzmer";
            this.labelStepIzmer.Size = new System.Drawing.Size(148, 13);
            this.labelStepIzmer.TabIndex = 7;
            this.labelStepIzmer.Text = "Шаг измерений S\' (минуты):";
            // 
            // labelEndIzmer
            // 
            this.labelEndIzmer.AutoSize = true;
            this.labelEndIzmer.Enabled = false;
            this.labelEndIzmer.Location = new System.Drawing.Point(5, 54);
            this.labelEndIzmer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndIzmer.Name = "labelEndIzmer";
            this.labelEndIzmer.Size = new System.Drawing.Size(147, 13);
            this.labelEndIzmer.TabIndex = 6;
            this.labelEndIzmer.Text = "Конец времени измерений:";
            // 
            // checkBoxSelectManSet
            // 
            this.checkBoxSelectManSet.AutoSize = true;
            this.checkBoxSelectManSet.Location = new System.Drawing.Point(107, 0);
            this.checkBoxSelectManSet.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSelectManSet.Name = "checkBoxSelectManSet";
            this.checkBoxSelectManSet.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSelectManSet.TabIndex = 8;
            this.checkBoxSelectManSet.UseVisualStyleBackColor = true;
            this.checkBoxSelectManSet.CheckedChanged += new System.EventHandler(this.checkBoxSelectManSet_CheckedChanged);
            // 
            // labelStartIzmer
            // 
            this.labelStartIzmer.AutoSize = true;
            this.labelStartIzmer.Enabled = false;
            this.labelStartIzmer.Location = new System.Drawing.Point(5, 32);
            this.labelStartIzmer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartIzmer.Name = "labelStartIzmer";
            this.labelStartIzmer.Size = new System.Drawing.Size(153, 13);
            this.labelStartIzmer.TabIndex = 4;
            this.labelStartIzmer.Text = "Начало времени измерений:";
            // 
            // groupBoxManualSetting
            // 
            this.groupBoxManualSetting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxManualSetting.Controls.Add(this.maskedTextBoxDiapazon);
            this.groupBoxManualSetting.Controls.Add(this.maskedTextBoxStepIzmer);
            this.groupBoxManualSetting.Controls.Add(this.labelStartIzmer);
            this.groupBoxManualSetting.Controls.Add(this.maskedTextBoxEndIzmer);
            this.groupBoxManualSetting.Controls.Add(this.maskedTextBoxStartIzmer);
            this.groupBoxManualSetting.Controls.Add(this.checkBoxSelectManSet);
            this.groupBoxManualSetting.Controls.Add(this.labelEndIzmer);
            this.groupBoxManualSetting.Controls.Add(this.labelDiapazon);
            this.groupBoxManualSetting.Controls.Add(this.labelStepIzmer);
            this.groupBoxManualSetting.Location = new System.Drawing.Point(0, 0);
            this.groupBoxManualSetting.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxManualSetting.Name = "groupBoxManualSetting";
            this.groupBoxManualSetting.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxManualSetting.Size = new System.Drawing.Size(300, 127);
            this.groupBoxManualSetting.TabIndex = 13;
            this.groupBoxManualSetting.TabStop = false;
            this.groupBoxManualSetting.Text = "Ручная настройка:";
            // 
            // maskedTextBoxStepIzmer
            // 
            this.maskedTextBoxStepIzmer.Enabled = false;
            this.maskedTextBoxStepIzmer.Location = new System.Drawing.Point(186, 77);
            this.maskedTextBoxStepIzmer.Name = "maskedTextBoxStepIzmer";
            this.maskedTextBoxStepIzmer.Size = new System.Drawing.Size(103, 20);
            this.maskedTextBoxStepIzmer.TabIndex = 3;
            // 
            // maskedTextBoxEndIzmer
            // 
            this.maskedTextBoxEndIzmer.Enabled = false;
            this.maskedTextBoxEndIzmer.Location = new System.Drawing.Point(186, 51);
            this.maskedTextBoxEndIzmer.Mask = "00:00:00";
            this.maskedTextBoxEndIzmer.Name = "maskedTextBoxEndIzmer";
            this.maskedTextBoxEndIzmer.Size = new System.Drawing.Size(103, 20);
            this.maskedTextBoxEndIzmer.TabIndex = 2;
            // 
            // maskedTextBoxStartIzmer
            // 
            this.maskedTextBoxStartIzmer.Enabled = false;
            this.maskedTextBoxStartIzmer.Location = new System.Drawing.Point(186, 25);
            this.maskedTextBoxStartIzmer.Mask = "00:00:00";
            this.maskedTextBoxStartIzmer.Name = "maskedTextBoxStartIzmer";
            this.maskedTextBoxStartIzmer.Size = new System.Drawing.Size(103, 20);
            this.maskedTextBoxStartIzmer.TabIndex = 1;
            // 
            // buttonCalibration
            // 
            this.buttonCalibration.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCalibration.Location = new System.Drawing.Point(1, 131);
            this.buttonCalibration.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCalibration.Name = "buttonCalibration";
            this.buttonCalibration.Size = new System.Drawing.Size(100, 41);
            this.buttonCalibration.TabIndex = 7;
            this.buttonCalibration.Text = "Калибровка";
            this.buttonCalibration.UseVisualStyleBackColor = false;
            this.buttonCalibration.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelKalibrovkaDescription
            // 
            this.labelKalibrovkaDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKalibrovkaDescription.AutoEllipsis = true;
            this.labelKalibrovkaDescription.AutoSize = true;
            this.labelKalibrovkaDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKalibrovkaDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKalibrovkaDescription.Location = new System.Drawing.Point(106, 131);
            this.labelKalibrovkaDescription.MaximumSize = new System.Drawing.Size(459, 50);
            this.labelKalibrovkaDescription.MinimumSize = new System.Drawing.Size(459, 2);
            this.labelKalibrovkaDescription.Name = "labelKalibrovkaDescription";
            this.labelKalibrovkaDescription.Size = new System.Drawing.Size(459, 41);
            this.labelKalibrovkaDescription.TabIndex = 15;
            this.labelKalibrovkaDescription.Text = resources.GetString("labelKalibrovkaDescription.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.maskedTextBoxOpisanie);
            this.groupBox1.Controls.Add(this.maskedTextBoxShirota);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maskedTextBoxDolgota);
            this.groupBox1.Location = new System.Drawing.Point(305, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 124);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Координаты (в десятичных градусах)";
            // 
            // maskedTextBoxOpisanie
            // 
            this.maskedTextBoxOpisanie.Location = new System.Drawing.Point(122, 70);
            this.maskedTextBoxOpisanie.Name = "maskedTextBoxOpisanie";
            this.maskedTextBoxOpisanie.Size = new System.Drawing.Size(126, 20);
            this.maskedTextBoxOpisanie.TabIndex = 6;
            // 
            // maskedTextBoxShirota
            // 
            this.maskedTextBoxShirota.Location = new System.Drawing.Point(122, 44);
            this.maskedTextBoxShirota.Mask = "00.0000000";
            this.maskedTextBoxShirota.Name = "maskedTextBoxShirota";
            this.maskedTextBoxShirota.Size = new System.Drawing.Size(126, 20);
            this.maskedTextBoxShirota.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Долгота: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Краткое описание: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Широта: ";
            // 
            // maskedTextBoxDolgota
            // 
            this.maskedTextBoxDolgota.Location = new System.Drawing.Point(122, 18);
            this.maskedTextBoxDolgota.Mask = "00.0000000";
            this.maskedTextBoxDolgota.Name = "maskedTextBoxDolgota";
            this.maskedTextBoxDolgota.Size = new System.Drawing.Size(126, 20);
            this.maskedTextBoxDolgota.TabIndex = 4;
            // 
            // labelDiapazon
            // 
            this.labelDiapazon.AutoSize = true;
            this.labelDiapazon.Enabled = false;
            this.labelDiapazon.Location = new System.Drawing.Point(5, 106);
            this.labelDiapazon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDiapazon.Name = "labelDiapazon";
            this.labelDiapazon.Size = new System.Drawing.Size(179, 13);
            this.labelDiapazon.TabIndex = 7;
            this.labelDiapazon.Text = "Диапазон измерений S\' (минуты):";
            // 
            // maskedTextBoxDiapazon
            // 
            this.maskedTextBoxDiapazon.Enabled = false;
            this.maskedTextBoxDiapazon.Location = new System.Drawing.Point(186, 103);
            this.maskedTextBoxDiapazon.Name = "maskedTextBoxDiapazon";
            this.maskedTextBoxDiapazon.Size = new System.Drawing.Size(103, 20);
            this.maskedTextBoxDiapazon.TabIndex = 3;
            // 
            // PanelOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelKalibrovkaDescription);
            this.Controls.Add(this.buttonCalibration);
            this.Controls.Add(this.groupBoxManualSetting);
            this.Name = "PanelOptions";
            this.Size = new System.Drawing.Size(572, 238);
            this.groupBoxManualSetting.ResumeLayout(false);
            this.groupBoxManualSetting.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStepIzmer;
        private System.Windows.Forms.Label labelEndIzmer;
        private System.Windows.Forms.CheckBox checkBoxSelectManSet;
        private System.Windows.Forms.Label labelStartIzmer;
        private System.Windows.Forms.GroupBox groupBoxManualSetting;
        private System.Windows.Forms.Button buttonCalibration;
        private System.Windows.Forms.Label labelKalibrovkaDescription;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxStartIzmer;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxStepIzmer;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxEndIzmer;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxOpisanie;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxShirota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxDolgota;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxDiapazon;
        private System.Windows.Forms.Label labelDiapazon;
    }
}
