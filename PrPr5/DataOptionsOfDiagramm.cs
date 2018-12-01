using System;
using System.Collections.Generic;
using System.Text;

namespace PrPr5
{
    [Serializable]
    class DataOptionsOfDiagramm//класс с конфигурацией диаграммы
    {
        public int innerMarginLeft { get; set; }
        public int innerMarginRight { get; set; }
        public int innerMarginTop { get; set; }
        public int innerMarginBottom { get; set; }
        public int numEdgesX { get; set; }
        public int numEdgesY { get; set; }
        public int totalMinutes { get; set; }
        public int totalRadiation { get; set; }
        public bool isLinesOfSer { get; set; }
        public bool isPointsOfSer { get; set; }
        public int radius { get; set; }         
    }
}
