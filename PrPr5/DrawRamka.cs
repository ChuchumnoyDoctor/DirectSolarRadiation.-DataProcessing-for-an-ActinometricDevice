using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class DrawRamka : UserControl
    {
        public DrawRamka()//отрисовка рамки
        {
            InitializeComponent();
            bmpp = new Bitmap(this.Width, this.Height);//новая битмапа
            p = Graphics.FromImage(bmpp);//изображение к ней               
        }
        Bitmap bmpp;
        Graphics p;         
        private void DrawRamka_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(bmpp, Point.Empty);
        }
        public void setRamkaVidelenie(Rectangle rect)
        {
            this.Location = rect.Location;
            this.Size = rect.Size;   
        }
    }
}
