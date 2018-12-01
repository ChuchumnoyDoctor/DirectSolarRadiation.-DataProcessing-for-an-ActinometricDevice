using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class PointCoorGrValue : UserControl // контрол, представляющий из себя кликабельную точку
    {
        public PointCoorGrValue(int radius)
        {
            InitializeComponent();
            Radius = radius;
            this.Hide();
        }
        int radius;
        public KeyValuePair<string, string> realPoint { get; set; }
        public Point pointScreen { get; set; }
        public Color pointColor { get; set; }
        public bool visible { get; set; }
        public int Radius { get { return radius; } set { radius = value; show(); this.Invalidate();} }
        
        public void show() //рисуем точку
        {
            if (this.visible == true)
                this.Show();
            else
            {
                this.Hide();
            }
            //радиус точки
            this.Width = radius * 2;//ширина
            this.Height = radius * 2;//высота
            this.Location = new Point(pointScreen.X - radius, pointScreen.Y - radius);////расположение           
        }        
        private void PointCoorGrValue_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath =
    new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0, 0, this.Width, this.Height);
            Region myRegion = new Region(myPath);
            this.Region = myRegion;

            e.Graphics.FillEllipse(new Pen(pointColor, 1f).Brush, 0, 0, this.Width, this.Height);
            e.Graphics.DrawEllipse(new Pen(Color.Black), 0, 0, this.Width, this.Height);
        }
    }
}
