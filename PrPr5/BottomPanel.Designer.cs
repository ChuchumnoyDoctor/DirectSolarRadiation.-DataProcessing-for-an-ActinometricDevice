namespace PrPr5
{
    partial class BottomPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BottomPanel));
            this.buttonExportS = new System.Windows.Forms.Button();
            this.buttonLoadDoc = new System.Windows.Forms.Button();
            this.groupBoxInterface = new System.Windows.Forms.GroupBox();
            this.propertyOfDevice1 = new PrPr5.PropertyOfDevice();
            this.checkGridViewDataSource = new PrPr5.CheckGridView();
            this.groupBoxInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExportS
            // 
            this.buttonExportS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExportS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonExportS.Location = new System.Drawing.Point(5, 176);
            this.buttonExportS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExportS.Name = "buttonExportS";
            this.buttonExportS.Size = new System.Drawing.Size(113, 35);
            this.buttonExportS.TabIndex = 14;
            this.buttonExportS.Text = "Сохранить в документ";
            this.buttonExportS.UseVisualStyleBackColor = false;
            this.buttonExportS.Click += new System.EventHandler(this.buttonExportS_Click);
            // 
            // buttonLoadDoc
            // 
            this.buttonLoadDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonLoadDoc.Location = new System.Drawing.Point(5, 58);
            this.buttonLoadDoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLoadDoc.Name = "buttonLoadDoc";
            this.buttonLoadDoc.Size = new System.Drawing.Size(113, 35);
            this.buttonLoadDoc.TabIndex = 14;
            this.buttonLoadDoc.Text = "Загрузить документ";
            this.buttonLoadDoc.UseVisualStyleBackColor = false;
            this.buttonLoadDoc.Click += new System.EventHandler(this.buttonLoadDoc_Click);
            // 
            // groupBoxInterface
            // 
            this.groupBoxInterface.BackColor = System.Drawing.Color.White;
            this.groupBoxInterface.Controls.Add(this.buttonLoadDoc);
            this.groupBoxInterface.Controls.Add(this.propertyOfDevice1);
            this.groupBoxInterface.Controls.Add(this.checkGridViewDataSource);
            this.groupBoxInterface.Controls.Add(this.buttonExportS);
            this.groupBoxInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInterface.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInterface.Name = "groupBoxInterface";
            this.groupBoxInterface.Size = new System.Drawing.Size(1249, 221);
            this.groupBoxInterface.TabIndex = 15;
            this.groupBoxInterface.TabStop = false;
            this.groupBoxInterface.Text = "Интерфейс";
            // 
            // propertyOfDevice1
            // 
            this.propertyOfDevice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyOfDevice1.Location = new System.Drawing.Point(831, 15);
            this.propertyOfDevice1.Margin = new System.Windows.Forms.Padding(2);
            this.propertyOfDevice1.Name = "propertyOfDevice1";
            this.propertyOfDevice1.Size = new System.Drawing.Size(415, 202);
            this.propertyOfDevice1.TabIndex = 0;
            // 
            // checkGridViewDataSource
            // 
            this.checkGridViewDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkGridViewDataSource.headerCheck = ((System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object, System.Windows.Forms.DataGridViewColumn>>)(resources.GetObject("checkGridViewDataSource.headerCheck")));
            this.checkGridViewDataSource.Location = new System.Drawing.Point(124, 16);
            this.checkGridViewDataSource.Margin = new System.Windows.Forms.Padding(4);
            this.checkGridViewDataSource.Name = "checkGridViewDataSource";
            this.checkGridViewDataSource.Size = new System.Drawing.Size(700, 195);
            this.checkGridViewDataSource.TabIndex = 3;
            // 
            // BottomPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxInterface);
            this.Name = "BottomPanel";
            this.Size = new System.Drawing.Size(1249, 221);
            this.groupBoxInterface.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyOfDevice propertyOfDevice1;
        private CheckGridView checkGridViewDataSource;
        private System.Windows.Forms.Button buttonExportS;
        private System.Windows.Forms.Button buttonLoadDoc;
        private System.Windows.Forms.GroupBox groupBoxInterface;
    }
}
