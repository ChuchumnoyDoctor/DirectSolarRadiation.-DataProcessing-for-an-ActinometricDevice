using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class newLabel : System.Windows.Forms.Label //элемент класса Label, который можно видоизменять
    {
        public int RotateAngle { get; set; }
        public string NewText { get; set; }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //throw new NotImplementedException();
            Brush b = new SolidBrush(this.ForeColor);
            e.Graphics.TranslateTransform(10, this.Height / 100);
            e.Graphics.RotateTransform(this.RotateAngle);
            // e.Graphics.TranslateTransform(- this.Width / 3, - this.Height / 3);
            e.Graphics.DrawString(this.NewText, this.Font, b, 0f, 0f);

            this.BackColor = System.Drawing.Color.Transparent;
            //this.BackColor = false;

            base.OnPaint(e);
        }
    }
}
