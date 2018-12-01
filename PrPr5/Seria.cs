using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrPr5
{
    public class Seria // класс с графиками
    {
        static public Dictionary<PointTypes, Color> seriesProperty = new Dictionary<PointTypes, Color>()//статичный набор цветов для графиков
        {
            { PointTypes.Red, Color.FromArgb(255,255,0,0) },
            { PointTypes.Blue, Color.FromArgb(255,0,0,255)},
            { PointTypes.DarkSlateGrey, Color.FromArgb(255,47, 79, 79)},
            { PointTypes.Lime, Color.FromArgb(255,0, 255, 0)},
            { PointTypes.Olive, Color.FromArgb(255,255,100,100)},
            { PointTypes.Maroon, Color.FromArgb(255,128, 0, 0)},
            { PointTypes.Gray, Color.FromArgb(255,128, 128, 128)},
            { PointTypes.FF9201, Color.FromArgb(255,255, 128, 0)}
        };
        public enum PointTypes //тип графика
        {
            Red,
            Blue,
            DarkSlateGrey,
            Lime,
            Olive,
            Maroon,
            Gray,
            FF9201
        }
        public List<PointCoorGrValue> points = new List<PointCoorGrValue>();
        PointTypes ptype = (PointTypes)1;
        private bool isDrawing;
        string legendText;
        public PointTypes GetPtype()//получение типа графика
        {
            return ptype;
        }
        public void SetPtype(PointTypes value)//отправка типа графика
        {
            ptype = value;
        }
        public bool GetIsDrawing()// получение bool на отображение графика
        {
            return isDrawing;
        }
        public void SetIsDrawing(bool value)// отправка bool на отображение графика
        {
            isDrawing = value;
        }
        public string GetLegendText()//получение названия графика
        {
            return legendText;
        }
        public void SetLegendText(string value)//отправка названия графика
        {
            legendText = value;
        }
    }
}
