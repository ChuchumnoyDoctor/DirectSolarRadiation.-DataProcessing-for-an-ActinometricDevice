using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class OptionsOfDiagramm : Form // форма с конфигурацией диаграммы
    {
        public delegate void onSaveAndExit(DataEventOptionsDiagramma e);
        public event onSaveAndExit OnSaveAndExit;
        string inLeft;
        string inRight;
        string inTop;
        string inBottom;
        string nEX;
        string nEY;
        string tMin;
        string tRad;
        int radius;
        bool isLinesOfSeries;
        bool isPointsOfSeries;
        public OptionsOfDiagramm(string inLeft, string inRight, string inTop, string inBottom, string nEX, string nEY, string tMin, string tRad, bool isLinesOfSeries, bool isPointsOfSeries, int radius)
        {            
            InitializeComponent();
            this.inLeft = inLeft;
            this.inRight = inRight;
            this.inTop = inTop;
            this.inBottom = inBottom;
            this.nEX = nEX;
            this.nEY = nEY;
            this.tMin = tMin;
            this.tRad = tRad;
            this.radius = radius;
            this.isLinesOfSeries = isLinesOfSeries;
            this.isPointsOfSeries = isPointsOfSeries;
            textBoxOtLeft.Text = this.inLeft.ToString() + "";
            textBoxOtRight.Text = this.inRight.ToString() + "";
            textBoxOtTop.Text = this.inTop.ToString() + "";
            textBoxOtBottom.Text = this.inBottom.ToString() + "";
            textBoxKolVoDelX.Text = this.nEX.ToString() + "";
            textBoxKolVoDelY.Text = this.nEY.ToString() + "";
            textBoxMinutes.Text = this.tMin.ToString() + "";
            textBoxRadiation.Text = this.tRad.ToString() + "";
            textBoxRPoints.Text = this.radius.ToString() + "";
            checkBoxIsDrawLineOfSeries.Checked =  this.isLinesOfSeries;
            checkBoxIsPointsOfSeries.Checked =  this.isPointsOfSeries;
        }
        private void buttonCancel_Click(object sender, EventArgs e)//кнопка отмены
        {
            DataEventOptionsDiagramma args = new DataEventOptionsDiagramma();
            args.innerMarginLeft = this.inLeft;
            args.innerMarginRight = this.inRight;
            args.innerMarginBottom = this.inBottom;
            args.innerMarginTop = this.inTop;
            args.numEdgesX = this.nEX;
            args.numEdgesY = this.nEY;
            args.totalMinutes = this.tMin;
            args.totalRadiation = this.tRad;
            args.isLinesOfSer = this.isLinesOfSeries;
            args.isPointsOfSer = this.isPointsOfSeries;
            args.radius = this.radius;
            args.isChange = false;
            OnSaveAndExit.Invoke(args);
            this.Close();
        }
        private void buttonSaveAndExit_Click(object sender, EventArgs e)//метод сохранения аргументов
        {
            DataEventOptionsDiagramma args = new DataEventOptionsDiagramma();
            args.innerMarginLeft = textBoxOtLeft.Text;
            args.innerMarginRight = textBoxOtRight.Text;
            args.innerMarginBottom = textBoxOtBottom.Text;
            args.innerMarginTop = textBoxOtTop.Text;
            args.numEdgesX = textBoxKolVoDelX.Text;
            args.numEdgesY = textBoxKolVoDelY.Text;
            args.totalMinutes = textBoxMinutes.Text;
            args.totalRadiation = textBoxRadiation.Text;
            args.isLinesOfSer = this.checkBoxIsDrawLineOfSeries.Checked;
            args.isPointsOfSer = this.checkBoxIsPointsOfSeries.Checked;
            args.radius = int.Parse(this.textBoxRPoints.Text);
            args.isChange = true;        
            OnSaveAndExit.Invoke(args);
            this.Close();
        }
        private void checkBoxIsDrawLineOfSeries_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsDrawLineOfSeries.Checked)
                checkBoxIsPointsOfSeries.Enabled = true;
            else
            {
                checkBoxIsPointsOfSeries.Enabled = false;
                checkBoxIsPointsOfSeries.Checked = false;
            }
        }
    }
    public class DataEventOptionsDiagramma : EventArgs // сохраняемые аргументы
    {
        public string innerMarginLeft { get; set; }
        public string innerMarginRight { get; set; }
        public string innerMarginTop { get; set; }
        public string innerMarginBottom { get; set; }
        public string numEdgesX { get; set; }
        public string numEdgesY { get; set; }
        public string totalMinutes { get; set; }
        public string totalRadiation { get; set; }
        public bool  isChange { get; set; }
        public bool isLinesOfSer { get; set; }
        public bool isPointsOfSer { get; set; }
        public int radius { get; set; }
        
    }
}
