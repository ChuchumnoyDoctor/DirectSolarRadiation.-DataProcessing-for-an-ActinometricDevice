using System;
using System.Collections.Generic;
using System.Text;

namespace PrPr5
{
    [Serializable]
    class DVORVAK//класс из графического ключа и конфигурации устройства измерения
    {
        public  List<LepestokKontur> KeyOfDR { get; set; }
        public DataIzmerValue ValueOfDIV { get; set; }
    }
}
