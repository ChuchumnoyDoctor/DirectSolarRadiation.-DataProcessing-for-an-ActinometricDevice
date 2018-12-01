using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class LegendRow : UserControl//ледженд строка/модуль, состоящий из данных конкретного графика
    {
        public LegendRow()
        {
            InitializeComponent();
        }       
        public void setSettings(Color coll, string text, bool vis)
        {
            labelColor.BackColor = coll;
            labelSeries.Text = text;
            checkBoxVisible.Checked = vis;
        }
    }
}
