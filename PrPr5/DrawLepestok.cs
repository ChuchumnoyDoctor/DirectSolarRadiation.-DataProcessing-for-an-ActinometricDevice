using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class DrawLepestok : Control
    {
        public DrawLepestok()//отрисовка лепестка
        {
            InitializeComponent();       
            isChekedLep = false;          
        }
        int radius;   //радиус равен одной шестой, где один лепесток занимает треть компонента 
        bool isChekedLep; 
        Graphics g;
        Pen _pen = new Pen(Color.Black, 4f);
        SolidBrush _brush = new SolidBrush(Color.Red);//Color.FromKnownColor (KnownColor.Control));
        SolidBrush _brushInside = new SolidBrush(Color.White);
        public bool getIsCheked()
        {
            return isChekedLep;
        }
        public void setIsCheked()
        {
            isChekedLep = true;
            this.Invalidate();
        }
        // OnPaint…
        protected override void OnPaint(PaintEventArgs pe)
        {
            radius = ClientSize.Width / 2;
            g = pe.Graphics;
            if (isChekedLep == false)
            {                
                drawLep(new SolidBrush(Color.White));                
            }
            if (isChekedLep == true)
            {              
                drawLep(new SolidBrush(Color.Orange));               
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(path);
            base.OnPaint(pe);
        }
        public void drawLep(SolidBrush Brush1)//отрисовка лепестка
        {
            g.FillRectangle(_brush, 0, 0, ClientSize.Width, ClientSize.Height);
            g.FillEllipse(Brush1, 0, 0, ClientSize.Width, ClientSize.Height);
            g.DrawEllipse(_pen, 0, 0, ClientSize.Width, ClientSize.Height);
        }
        public bool PointInCircle(double ox, double oy, double r, int clickX, int clickY)//проверка лежит ли в круге
        {
            double x;
            double y;
            bool isChecke;
            x = clickX;
            y = clickY;
            double d = Math.Sqrt(Math.Pow(ox - x, 2) + Math.Pow(oy - y, 2));
            if (d <= r)
            {
                isChecke = true;
                //MessageBox.Show("Точка М лежит в круге."); 
            }
            else
            {
                isChecke = false;
                //MessageBox.Show("Точка М лежит вне круга.");
            }
            return isChecke;
        }
        private void DrawLepestok_MouseDown(object sender, MouseEventArgs e)
        {            
            int clickX;
            int clickY;
            clickX = (int)(e.Location.X);
            clickY = (int)(e.Location.Y);
            bool isCheki = PointInCircle(ClientSize.Width / 2, ClientSize.Height / 2, radius, clickX, clickY);
            if (isCheki == true)
            {
                if (isChekedLep == true)
                {
                    isChekedLep = false;
                }
                else
                {
                    isChekedLep = true;
                }
            }
            this.Invalidate();
        }
    }
}
