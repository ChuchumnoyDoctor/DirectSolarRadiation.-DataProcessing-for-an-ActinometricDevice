using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrPr5
{
    [Serializable]
    public class LepestokKontur//данные, хранящиеся внутри лепестка
    {
        public Point pointScreen { get; set; }
        public int radiusLepestok { get; set; }
        public bool checkedLepestok { get; set; }
    }
}
