using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class PointValueShow : UserControl // контрол, представляющий из себя маленький бокс со значениями, хранящиемся в месте нажатия точки
    {
        public PointValueShow()
        {
            InitializeComponent();
            this.Visible = false;
        }
        public void show(string legText,string x, string y, int clX, int clY)//вызов и отображение
        {
            //label с "Время: ...; Радиация: ..., Вт/М2";
            string X;
            string Y;
            int ClickX;
            int ClickY;
            X = x;
            Y = y;
            ClickX = clX;
            ClickY = clY;
            string MessageOnLabel = legText + ";" + "\n" + "Время: " + x + ";" + "\n" + "Радиация: " + y + ", Вт/М2.";
            Size textImageSize = TextRenderer.MeasureText((MessageOnLabel), this.Font);
            this.Width = (int)textImageSize.Width + buttonExit.Width + 10;
            this.Height = (int)buttonExit.Height + 10;
            label1.Text = (MessageOnLabel);
            this.Location = new Point(ClickX, ClickY);
            this.Size = new Size(label1.Width + buttonExit.Width, label1.Height + 5);
            this.Visible = true;           
            this.Invalidate();
        }
        public void hide()
        {
            this.Visible = false;
        }
        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.hide();
        }
    }
}
