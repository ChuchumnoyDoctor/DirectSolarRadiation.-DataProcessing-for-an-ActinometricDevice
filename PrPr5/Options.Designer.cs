namespace PrPr5
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.buttonSaveAndExit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelSetProperties2 = new PrPr5.PanelOptions();
            this.SuspendLayout();
            // 
            // buttonSaveAndExit
            // 
            this.buttonSaveAndExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSaveAndExit.Location = new System.Drawing.Point(5, 182);
            this.buttonSaveAndExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveAndExit.Name = "buttonSaveAndExit";
            this.buttonSaveAndExit.Size = new System.Drawing.Size(119, 42);
            this.buttonSaveAndExit.TabIndex = 9;
            this.buttonSaveAndExit.Text = "Сохранить изменения и выйти";
            this.buttonSaveAndExit.UseVisualStyleBackColor = false;
            this.buttonSaveAndExit.Click += new System.EventHandler(this.buttonSaveAndExit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCancel.Location = new System.Drawing.Point(474, 182);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 42);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Выйти";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panelSetProperties2
            // 
            this.panelSetProperties2.BackColor = System.Drawing.SystemColors.Window;
            this.panelSetProperties2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetProperties2.endIzmer = null;
            this.panelSetProperties2.Location = new System.Drawing.Point(5, 5);
            this.panelSetProperties2.Name = "panelSetProperties2";
            this.panelSetProperties2.Size = new System.Drawing.Size(570, 217);
            this.panelSetProperties2.startIzmer = null;
            this.panelSetProperties2.stepIzmer = null;
            this.panelSetProperties2.TabIndex = 0;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(580, 227);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveAndExit);
            this.Controls.Add(this.panelSetProperties2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

    
        private PanelOptions panelSetProperties2;
        private System.Windows.Forms.Button buttonSaveAndExit;
        private System.Windows.Forms.Button buttonCancel;
    }
}