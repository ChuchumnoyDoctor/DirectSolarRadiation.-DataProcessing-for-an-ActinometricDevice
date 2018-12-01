using System;
using System.Collections.Generic;
using System.Text;

namespace PrPr5
{
    [Serializable]
    class DataIzmerValue//класс с частью конфигурации устройства измерения
    {
        public string startVremyaIzmer { get; set; }
        public string endVremyaIzmer { get; set; }
        public string stepIzmer { get; set; }
        public string dolgota { get; set; }
        public string shirota { get; set; }
        public string opisanie { get; set; }
        public string diapazonVremyaIzmer { get; set; }
    }
}
