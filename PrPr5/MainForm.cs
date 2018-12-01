using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class MainForm : Form//главная форма и окно программы
    {        
        public MainForm()
        {
            InitializeComponent();         
            bottomPanel1.OnSaveAndExit += saveData;//метод, вызываемый при изменении
            customChart1.hideLabelObnovlenie();
        }
        private void saveData(DataEventGGGGMMDD e)//обработка метода
        {
            //int ggggmmdd = bottomPanel1.getLabelGGGGMMDD();
            labelGGGGMMDD = e.GGGGMMDD.ToString();
            List<int> ggggMMdd;
            string gggmmd;
            ggggMMdd = parseData(labelGGGGMMDD);
            int year;
            int month;
            int day;
            year = ggggMMdd[0];
            month = ggggMMdd[1];
            day = ggggMMdd[2];
            string y;
            string m;
            string d;
            if (month < 10)
            {
                m = "0" + month;
            }
            else
            {
                m = month + "";
            }
            if (day < 10)
            {
                d = "0" + day;
            }
            else
            {
                d = day + "";
            }
            gggmmd = year + "." + m + "." + d;  
            customChart1.SetLabelGGGGMMDD1(gggmmd + "");
           
        }
        List<string> list;
        DataTable dTable;
        int timeIntervalObnovlenie;
        string labelGGGGMMDD;
        double sinQ;
        double sinF;
        double cosQ;
        double cosF;
        double cosW;
        double B;
        double sinh;
        double Q;
        public string StartIzmer { get; set; }
        public string EndIzmer { get; set; }
        public string StepIzmer { get; set; }
        public string diapazon { get; set; }
        public string shirota { get; set; }
        public int numberDay(int year, int month, int day)//вычисление номера дня по дате
        {
            int i = 0;
            List<int> numberDay = new List<int>();
            numberDay.Add(31);//январь
            float f = year % 4;
            if(f == 0)
            {
                numberDay.Add(29);//февраль высокосный
            }
            else
            {
                numberDay.Add(28);//февраль
            }
            numberDay.Add(31);//март
            numberDay.Add(30);//апрель
            numberDay.Add(31);//май
            numberDay.Add(30);//июнь
            numberDay.Add(31);//июль
            numberDay.Add(31);//август
            numberDay.Add(30);//сентябрь
            numberDay.Add(31);//октябрь
            numberDay.Add(30);//ноябрь
            numberDay.Add(31);//декабрь
            for(int j=0; j< month-1;j++)
            {
                i = i + numberDay[j];
            }
            i = i + day;
            return i;
        }
        public List<int> parseData(string ggggmmdd)//парсинг даты
        {
            List<int> list = new List<int>();           
            foreach(char ch in ggggmmdd)
            {
                list.Add(int.Parse(ch.ToString()));
            }
            List<int> listData = new List<int>();
            string year = "";
            string month = "";
            string day = "";
            for (int i = 0; i<list.Count;i++)
            {                
                if (i <= 3)
                {
                    year = year + list[i].ToString();
                }
                else
                if (i > 3 & i <= 5)
                {
                    month = month + list[i].ToString();
                }
                else
                {
                    day = day + list[i].ToString();
                }
            }
            listData.Add(int.Parse(year));
            listData.Add(int.Parse(month));
            listData.Add(int.Parse(day));
            return listData;
        }
        public string getS(string getH, string s_)
        {
            double sinH;
            string S;
            sinH = Math.Sin((Math.PI *  double.Parse(getH) /180));
            double dS;
            dS = (double.Parse(s_) / sinH);
            S = dS + "";
            return S;
        }
        public string getH(string time,string s_)
        {
            string s = "";
            double SShtrih;
            if (s_ == "")
            {
                s = "";
            }
            else
            {
                shirota = double.Parse(shirota).ToString("00.00");
                SShtrih = double.Parse(s_);                                         
                B = getNubmerDay();
                double SinB = getsinB(B+ "");
                SinB = double.Parse(SinB.ToString("0.00"));
                Q = 23.45 * SinB;
                Q = double.Parse(Q.ToString("0.00"));
                sinQ = getsinQ(Q + "");
                sinQ = double.Parse(sinQ.ToString("0.00"));
                cosQ = Math.Cos(Math.PI * Q / 180);
                cosQ = double.Parse(cosQ.ToString("0.00"));
                sinF = Math.Sin(Math.PI * double.Parse(shirota) / 180);
                sinF = double.Parse(sinF.ToString("0.00"));
                cosF = Math.Cos(Math.PI * double.Parse(shirota) / 180);
                cosF = double.Parse(cosF.ToString("0.00"));
                float w;
                w = (float)getLST(time);
                w = float.Parse(w.ToString("0.00"));
                cosW = Math.Cos((double)(Math.PI * w) / 180);
                cosW = double.Parse(cosW.ToString("0.00"));
                double ccosw = Math.Cos(w);
                sinh = Math.Asin(((sinQ * sinF) + (cosQ * cosF * cosW)));
                double bufS = double.Parse(sinh.ToString("0.00"));
                s = bufS + "";                
            }
            return s;
        }
        public double getNubmerDay()
        {
            double B;
            int D;
            List<int> ggggMMdd;
            ggggMMdd = parseData(labelGGGGMMDD);
            int year;
            int month;
            int day;
            year = ggggMMdd[0];
            month = ggggMMdd[1];
            day = ggggMMdd[2];
            D = numberDay(year, month, day);
            float bb = (((float)(360 * (D - 81)) / 365));    
            double zz = double.Parse(bb.ToString("0.00"));
            return zz;
        }
        public double getsinB(string b)
        {
            double B = double.Parse(b);
            double SinB = Math.Sin(Math.PI * B / 180);
            double zz = double.Parse(SinB.ToString("0.00"));
            return SinB;
        }
        public double getsinQ(string q)
        {
            double Q;
            double sinQ;
            Q = double.Parse(q);
            sinQ = Math.Sin(Math.PI * Q / 180);
            double zz = double.Parse(sinQ.ToString("0.00"));
            return sinQ;
        }      
        public float getLST(string time)
        {
            float minuts = parseStringTime(time);
            float LST = (minuts / 60);         
            float w = (float)(15 * (LST - 12));
            return w;
        }
        public DataTable DrawGridViewSRada()//создание формы таблицы с конечными итоговыми данными
        {
            List<Seria> list = new List<Seria>();
            DataTable GridViewRada = new DataTable();
            list = customChart1.getSeriesFromDiagramma();
            GridViewRada.Columns.Add("Время", typeof(string));
            GridViewRada.Columns.Add("S', Вт/М2", typeof(string));
            GridViewRada.Columns.Add("S, Вт/М2", typeof(string));
            GridViewRada.Columns.Add("S30, Вт/М2", typeof(string));
            GridViewRada.Columns.Add("h", typeof(string));
            GridViewRada.Columns.Add("sinδ", typeof(string));
            GridViewRada.Columns.Add("cosδ", typeof(string));
            GridViewRada.Columns.Add("sinφ", typeof(string));
            GridViewRada.Columns.Add("cosφ", typeof(string));
            GridViewRada.Columns.Add("cosω", typeof(string));
            GridViewRada.Columns.Add("ω", typeof(string));
            GridViewRada.Columns.Add("δ", typeof(string));
            GridViewRada.Columns.Add("Широта", typeof(string));
            GridViewRada.Columns.Add("B", typeof(string));          
            DataRow RowGridViewRada = GridViewRada.NewRow();
            Seria S = list[list.Count-1];
            foreach (PointCoorGrValue ser in S.points)
            {
                string h = "";
                string SS;
                if(ser.realPoint.Value == "")
                {
                    SS = "";
                    h = "";
                }
                else
                {
                    h = getH(ser.realPoint.Key, ser.realPoint.Value);
                    SS = getS(h, ser.realPoint.Value);                   
                }
                RowGridViewRada = GridViewRada.NewRow();                
                RowGridViewRada["S', Вт/М2"] = ser.realPoint.Value;
                RowGridViewRada["Время"] = ser.realPoint.Key;
                RowGridViewRada["S, Вт/М2"] = SS;
                RowGridViewRada["S30, Вт/М2"] = "";
                RowGridViewRada["h"] = h;
                RowGridViewRada["sinδ"] = sinQ;
                RowGridViewRada["cosδ"] = cosQ;
                RowGridViewRada["sinφ"] = sinF;
                RowGridViewRada["cosφ"] =cosF;
                RowGridViewRada["cosω"] = cosW;
                RowGridViewRada["ω"] = getLST(ser.realPoint.Key);                
                RowGridViewRada["δ"] = Q;
                RowGridViewRada["Широта"] = double.Parse(shirota).ToString("00.00"); 
                RowGridViewRada["B"] = B;               
                GridViewRada.Rows.Add(RowGridViewRada);
            }            
            return GridViewRada;
        }        
        public void go2Diag_Click()//метод обработки отправки данных на диаграмму
        {
            customChart1.Hide();            
            bool iss = bottomPanel1.getIsDataSouce();
            dTable = new DataTable();
            list = new List<string>();
            list = bottomPanel1.getSettings();//взял настройки с элемента
            StartIzmer = list[0];
            EndIzmer = list[1];
            StepIzmer = list[2];
            diapazon = list[3];
            shirota = list[4];
            if (StartIzmer != "" & EndIzmer != "" & StepIzmer != "" & diapazon != "" & shirota != "")
            {
                if (bottomPanel1.getOpenfileloadDoc_Click() == "" || bottomPanel1.getOpenfileloadDoc_Click() == null)
                {
                    MessageBox.Show("Отсуствуют входные данные.");
                }
                else
                {
                    customChart1.setSettings(StartIzmer, EndIzmer, StepIzmer, int.Parse(diapazon));//отправил настройки на кастомчарт
                    dTable = bottomPanel1.getDataTable();//взял тейбл
                    customChart1.isDataSourceSeries = iss;
                    customChart1.setDataSource(dTable);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует или не действительна конфигурация устройства.");
            }
            customChart1.Show();
        }
        private void buttonGo2Diag_Click(object sender, EventArgs e)//кнопка отправки данных на диаграмму
        {           
            go2Diag_Click();       
        }
        public void readyResult()
        {
            try
            {
                DataTable dt = DrawGridViewSRada();
                bottomPanel1.setCheckGridView(dt);
                bottomPanel1.setIsDataSouce(false);
            }
            catch
            {
                MessageBox.Show("Отсутствуют входные данные.");
            }
        }
        private void button1_Click(object sender, EventArgs e)//кнопка формирования итоговой таблицы
        {
            bottomPanel1.getIsReadyFiles(true);
            readyResult();
        }

        private void buttonFAQinform_Click(object sender, EventArgs e)//кнопка справочной информации
        {
            SpravInform f = new SpravInform();
            f.ShowDialog();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//чекбокс автоматического выполнения
        {
            if(checkBox1.Checked == true)
            {
                if (bottomPanel1.getOpenfileloadDoc_Click() == "" || bottomPanel1.getOpenfileloadDoc_Click() == null)
                {
                    bottomPanel1.openfileloadDoc_Click();
                }
                if (bottomPanel1.getOpenfileloadDoc_Click() == "" || bottomPanel1.getOpenfileloadDoc_Click() == null)
                {
                    //MessageBox.Show("Отсуствуют входные данные.");
                    checkBox1.Checked = false;
                }
                else
                {
                    list = new List<string>();
                    list = bottomPanel1.getSettings();//взял настройки с элемента
                    StartIzmer = list[0];
                    EndIzmer = list[1];
                    StepIzmer = list[2];
                    if (StartIzmer == "" || EndIzmer == "" || StepIzmer == "" || StartIzmer == null || EndIzmer == null || StepIzmer == null)
                    {
                        MessageBox.Show("Отсутствует или не действительна конфигурация устройства.");
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        timerTakeDS.Enabled = true;                       
                        timerObnovlenie.Enabled = true;                       
                    }
                }            
            }
            else
            {
                timerTakeDS.Enabled = false;
                customChart1.hideLabelObnovlenie();
                timerObnovlenie.Enabled = false;
                customChart1.shagSec = 0;
            }            
        }
        public int convertToMinutes(int hours)//конвертор из часы в минуты
        {
            if (hours <= 0)
                return hours;
            return 60 + convertToMinutes(hours - 1);
        }
        public int convertToMinutes(string hours)//конвертор из часы в минуты
        {
            int hour = int.Parse(hours);
            return convertToMinutes(hour);
        }
        public int parseStringTime(string time)//парсинг строковой строки времени в минуты
        {
            string[] r = time.Split(':');
            return int.Parse(r[1]) + convertToMinutes(r[0]);
        }
        public void getIntervalObnovlenie()
        {
            DataColumn dC = dTable.Columns[0];
            //DataRow dataRow = dTable.Rows[dTable.Rows.Count - 1];           
            string time = dTable.Rows[dTable.Rows.Count - 2][0].ToString();
            timeIntervalObnovlenie = parseStringTime(EndIzmer) - parseStringTime(time);
            if (timeIntervalObnovlenie <=0)
            {
                timerTakeDS.Enabled = false;
                customChart1.hideLabelObnovlenie();
                timerObnovlenie.Enabled = false;
                customChart1.shagSec = 0;
            }
            else
            {
                timeIntervalObnovlenie = timeIntervalObnovlenie / int.Parse(bottomPanel1.getSettings()[1]);
            }           
            /*ласт значение в документе  - конец времени измерений
             * получили минуты
             * общее кол-во минут / интервал измерения
             * отбрасываем целую часть
             * остаток переводим в часть интервала
             * отдаем лейблу остаток
             * */            
        }
        private void timerTakeDS_Tick(object sender, EventArgs e)
        {
            bottomPanel1.getIsReadyFiles(false);
            bottomPanel1.loadDoc_Click();
            go2Diag_Click();
            bottomPanel1.getIsReadyFiles(true);
            readyResult();
            timerTakeDS.Interval = int.Parse(bottomPanel1.getSettings()[2])*60*1000;
            customChart1.showLabelObnovlenie();
            getIntervalObnovlenie();
        }
        private void timerObnovlenie_Tick(object sender, EventArgs e)
        {
            //отправлем в лейбл остаток
            customChart1.changeLabelObnovlenie(timeIntervalObnovlenie * 60);
        }

        private void bottomPanel1_Resize(object sender, EventArgs e)
        {
            buttonGo2Diag.Location = new Point(5,bottomPanel1.Location.Y + 91);
            button1.Location = new Point(5, bottomPanel1.Location.Y + 130);
            checkBox1.Location = new Point(5, bottomPanel1.Location.Y + 15);
        }
    }
}
