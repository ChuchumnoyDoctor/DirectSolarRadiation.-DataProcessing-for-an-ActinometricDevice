using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class LegBox : UserControl//ледженд бокс
    {
        public List<LegendRow> rowList = new List<LegendRow>();
        FlowLayoutPanel flowLayoutPanel1;
        public LegBox()
        {
            InitializeComponent();
        }
        public void setLegBox(List<DataLegRow> list)//отправка данных в леджендбокс
        {
            this.Controls.Clear();
            flowLayoutPanel1 = new FlowLayoutPanel();
            this.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1.BackColor = Color.White;        
          //  flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanel1.Size = new Size(this.Width, this.Height);
            flowLayoutPanel1.AutoScroll = true;
            foreach (DataLegRow dlg in list)
            {
                setLegRow(dlg.col,dlg.headerText,dlg.visible);
            }        
        }
        public void setLegRow(Color coll, string text, bool vis)//получение ледженд строки/модуля, состоящего из данных конкретного графика
        {
            LegendRow lR = new LegendRow();
            lR.setSettings(coll, text, vis);
            rowList.Add(lR);
            flowLayoutPanel1.Controls.Add(lR);          
        }
    }
}
