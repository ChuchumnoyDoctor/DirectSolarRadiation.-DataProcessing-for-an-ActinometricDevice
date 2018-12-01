using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class PanelOptions : UserControl
    {
        public PanelOptions()
        {
            InitializeComponent();          
        }     
        public string startIzmer { get; set; }
        public string endIzmer { get; set; }
        public string stepIzmer { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            //код калибровки
            //загрузить документ с ясным небом
            MessageBox.Show("Калибровка прошла успешно!");
            //MessageBox.Show.
        }
        private void checkBoxSelectManSet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectManSet.Checked == false)
            {              
                this.labelStartIzmer.Enabled = false;
                this.maskedTextBoxStartIzmer.Enabled = false;
                this.labelEndIzmer.Enabled = false;
                this.maskedTextBoxEndIzmer.Enabled = false;
                this.labelStepIzmer.Enabled = false;
                this.maskedTextBoxStepIzmer.Enabled = false;
                this.labelDiapazon.Enabled = false;
                this.maskedTextBoxDiapazon.Enabled = false;
            }
            else
            {
                this.labelStartIzmer.Enabled = true;
                this.maskedTextBoxStartIzmer.Enabled = true;
                this.labelEndIzmer.Enabled = true;
                this.maskedTextBoxEndIzmer.Enabled = true;
                this.labelStepIzmer.Enabled = true;
                this.maskedTextBoxStepIzmer.Enabled = true;
                this.labelDiapazon.Enabled = true;
                this.maskedTextBoxDiapazon.Enabled = true;
            }            
        }
    }
}
