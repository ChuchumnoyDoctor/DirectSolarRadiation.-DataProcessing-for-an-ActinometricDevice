using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PrPr5
{
    class ConvertFilename2DataTime
    {
        public int Convertor(string x)//конвертер из названия документа в дату
        {
            string X = x;
            int r = Convert.ToInt32(Regex.Replace(X, @"[^\d]+", ""));
            X = r.ToString();
            string[] MassiveOfDate = new string[4];
            MassiveOfDate[0] = X[0] + "" + X[1] + "";
            MassiveOfDate[1] = X[2] + X[3] + "";
            MassiveOfDate[2] = X[4] + X[5] + "";
            MassiveOfDate[3] = X[6] + X[7] + "";
            // Счетчик месяцов
            int ShetMes = 0;
            int ShetMesIndex = 0;
            // Счетчик годов
            int ShetGod = 0;
            int ShetGodIndex = 0;
            string DataYear = "";
            string DataMonth = "";
            string DataDay = "";
            for (int i = 0; i < MassiveOfDate.Length; i++)
            {
                if (Convert.ToInt32(MassiveOfDate[i]) < 13)
                {
                    //месяц
                    ShetMes++;
                    ShetMesIndex = i;
                }
                if (Convert.ToInt32(MassiveOfDate[i]) == 20)
                {
                    if (i != (MassiveOfDate.Length))
                    {
                        //год
                        for (int j = i; j < MassiveOfDate.Length - 1; j++)
                        {
                            if (Convert.ToInt32(MassiveOfDate[j] + MassiveOfDate[j + 1]) >= 2000)
                            {
                                ShetGod++;
                                ShetGodIndex = j;
                            }
                        }
                    }
                }
            }
            List<string> tmp;
            if (ShetGod == 1)
            {
                DataYear = (MassiveOfDate[ShetGodIndex] + MassiveOfDate[ShetGodIndex + 1]);
                if (ShetMes == 1)
                {
                    DataMonth = MassiveOfDate[ShetMesIndex];
                    // Преобразование в список
                    tmp = new List<string>(MassiveOfDate);
                    // Удаление элемента
                    tmp.RemoveAt(ShetGodIndex);
                    tmp.RemoveAt(ShetGodIndex + 1);
                    tmp.RemoveAt(ShetMesIndex);
                    // Преобразование в массив
                    MassiveOfDate = tmp.ToArray();
                    DataDay = MassiveOfDate[0];
                }
            }
            else if (ShetMes == 1)
            {
                tmp = new List<string>(MassiveOfDate);
                DataMonth = MassiveOfDate[ShetMesIndex];
                tmp.RemoveAt(ShetMesIndex);
                // Преобразование в массив
            }
            return r;
        }        
    }
}
