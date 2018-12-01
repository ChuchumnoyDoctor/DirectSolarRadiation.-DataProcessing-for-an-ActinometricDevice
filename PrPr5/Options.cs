using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PrPr5
{
    public partial class Options : Form // форма с настройками конфигурации устройства измерения
    {
        public delegate void onSaveAndExit(DataEventArgumnts e);
        public event onSaveAndExit OnSaveAndExit;
        public Options(string startI, string endI, string stepI, string place, string shirota, string dolgota, string diapazon)
        {
            InitializeComponent();
            panelSetProperties2.maskedTextBoxStartIzmer.Text = startI;
            panelSetProperties2.maskedTextBoxEndIzmer.Text = endI;
            panelSetProperties2.maskedTextBoxStepIzmer.Text = stepI;
            panelSetProperties2.maskedTextBoxDolgota.Text = dolgota;
            panelSetProperties2.maskedTextBoxShirota.Text = shirota;
            panelSetProperties2.maskedTextBoxOpisanie.Text = place;
            panelSetProperties2.maskedTextBoxDiapazon.Text = diapazon;
            bufStart = startI;
            bufEnd = endI;
            bufStep = stepI;
            bufDolgota = dolgota;
            bufShirota = shirota;
            bufPlace = place;
            bufDiapazon = diapazon;
        }
        string bufDiapazon;
        string bufStart;
        string bufEnd;
        string bufStep;
        string bufShirota;
        string bufDolgota;
        string bufPlace;
        bool isHour;
        bool isMinute;
        bool isTimeStartEnd;
        bool isStep;
        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> bufListStr = new List<string>();           
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
        private void buttonSaveAndExit_Click(object sender, EventArgs e)
        {
            int start;
            int end;
            isTimeStartEnd = false;            
            {//Проверка формата времени измерений
                try
                {
                    start = parseStringTime(panelSetProperties2.maskedTextBoxStartIzmer.Text);
                    end = parseStringTime(panelSetProperties2.maskedTextBoxEndIzmer.Text);
                    {//start измерений
                        isMinute = false;
                        isHour = false;
                        string[] r = panelSetProperties2.maskedTextBoxStartIzmer.Text.Split(':');
                        if (int.Parse(r[1]) < 60)
                        {
                            isMinute = true;
                        }
                        else
                        {
                            MessageBox.Show("Формат минут должен быть меньше 60-ти");
                        }
                        if (int.Parse(r[0]) < 24)
                        {
                            isHour = true;
                        }
                        else
                        {
                            MessageBox.Show("Формат часов должен быть меньше 24-ех");
                        }
                    }
                    if (isMinute == true && isHour == true)
                    {//end измерений
                        isMinute = false;
                        isHour = false;
                        string[] r = panelSetProperties2.maskedTextBoxEndIzmer.Text.Split(':');
                        if (int.Parse(r[1]) <= 59)
                        {
                            isMinute = true;
                        }
                        else
                        {
                            MessageBox.Show("Формат минут должен быть меньше 60-ти");
                        }
                        if (int.Parse(r[0]) < 24)
                        {
                            isHour = true;
                        }
                        else
                        {
                            MessageBox.Show("Формат часов должен быть меньше 24-ех");
                        }
                    }
                    if (isMinute == true && isHour == true)
                    {
                        if (start < end)
                        {
                            isTimeStartEnd = true;
                        }
                        else
                        {
                            MessageBox.Show("Начало не может быть позже конца измерений.");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Время измерений отсутствует или имеет не верный формат.");
                }
            }
            int step;
            isStep = false;
            {//проверка интервала измерений
                try
                {
                    step = int.Parse(panelSetProperties2.maskedTextBoxStepIzmer.Text);
                    isStep = true;
                }
                catch
                {
                    MessageBox.Show("Значение интервала измерения неверно или отстуствует.");
                }
            }
            if (isTimeStartEnd == true && isStep == true)
            {
                //код сохранения изменений и выход
                DataEventArgumnts args = new DataEventArgumnts();
                args.startIzmer = panelSetProperties2.maskedTextBoxStartIzmer.Text;
                args.endIzmer = panelSetProperties2.maskedTextBoxEndIzmer.Text;
                args.stepIzmer = panelSetProperties2.maskedTextBoxStepIzmer.Text;
                args.shirota = panelSetProperties2.maskedTextBoxShirota.Text;
                args.dolgota = panelSetProperties2.maskedTextBoxDolgota.Text;
                args.opisanie = panelSetProperties2.maskedTextBoxOpisanie.Text;
                args.diapazon = panelSetProperties2.maskedTextBoxDiapazon.Text;
                OnSaveAndExit.Invoke(args);
                this.Close();
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //код отмены изменений и выход
            DataEventArgumnts args = new DataEventArgumnts();
            args.startIzmer = bufStart;
            args.endIzmer = bufEnd;
            args.stepIzmer = bufStep;
            args.shirota = bufShirota;
            args.dolgota = bufDolgota;
            args.opisanie = bufPlace;
            args.diapazon = bufDiapazon;
            OnSaveAndExit.Invoke(args);          
            this.Close();
        }        
    }
    public class DataEventArgumnts : EventArgs
    {
        public string diapazon { get; set; }
        public string startIzmer { get; set; }
        public string endIzmer { get; set; }
        public string stepIzmer { get; set; }
        public string dolgota { get; set; }
        public string shirota { get; set; }
        public string opisanie { get; set; }
    }
}
