using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PrPr5
{
    class SummRadiation //класс парсинга документа
    {
        public Dictionary<string, string> prikol = new Dictionary<string, string>()
        {
        };
        public void setCsvFieldHeaders(string[] csvFieldHeaders)
        {
            for (int i = 0; i < csvFieldHeaders.Length; i++)
            {
                prikol.Add(csvFieldHeaders[i], csvFieldHeaders[i]);
            }
        }
        public SummRadiation()
        {
        }
        public virtual void Fill(string[] fields, string[] values)
        {
            string curField = "";
            for (int i = 0; i < fields.Length; i++)
            {
                curField = fields[i];
                if (!prikol.ContainsKey(curField)) continue;
            
                string value = values[i];
                if (String.IsNullOrEmpty(value) || value == " ")
                    value = "0";
                prikol[curField] = value;
            }
        }
    }
}
