using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CsvHelper;

namespace PrPr5
{
    public partial class BottomPanel : UserControl
    {
        public BottomPanel()
        {
            InitializeComponent();
            checkGridViewDataSource.OnSaveAndExit += saveData; //вызываемый метод при изменении
        }
        bool isss;
        public void getIsReadyFiles(bool iss) //проверка файлов
        {
            isss = iss;
        }
        private void saveData(DataEventKolvoCheck e) // вызываемый метод
        {
            if (isss == false)
            {
                int kolvo;
                kolvo = checkGridViewDataSource.getKolvoCheck() - 1;
                if (bufKolvo != kolvo)
                {
                    bufKolvo = kolvo;
                    propertyOfDevice1.setRightSideCheck(bufKolvo);
                }
            }          
        }
        public delegate void onSaveAndExit(DataEventGGGGMMDD e);
        public event onSaveAndExit OnSaveAndExit;
        public Boolean OSvremya = true;
        public Boolean ZatenenShetchik = true;        
        public DataTable GridViewRada;
        DataTable dTable;
        int bufKolvo=0;
        StreamReader strem;
        int labelGGGGmmDD;
       
        public string StartIzmer { get; set; }
        public string EndIzmer { get; set; }
        public string StepIzmer { get; set; }
        public bool isDataSourceSeries { get; set; }
        public string filename { get; set; }
        public List<string> getSettings() // получение конфига настроек
        {            
            return propertyOfDevice1.getSettings();
        }
        public void loadDoc_Click() // метод загрузки документа
        {
            try
            {
                List<SummRadiation> s;
                strem = new StreamReader(filename, System.Text.Encoding.Default);
                var csv = new CsvReader(strem);
                csv.Configuration.Delimiter = ";";
                csv.ReadHeader();
                s = new List<SummRadiation>();
                string[] row;
                string[] newRow;
                byte[] win1251;
                byte[] utfbytes;
                SummRadiation covertedRow;
                while (csv.Read())
                {
                    row = csv.CurrentRecord;
                    newRow = new string[row.Length];
                    for (int i = 0; i < row.Length; i++)
                    {
                        win1251 = Encoding.GetEncoding(1251).GetBytes(row[i]);
                        utfbytes = Encoding.Convert(Encoding.GetEncoding(1251), System.Text.Encoding.Default, win1251);
                        newRow[i] = System.Text.Encoding.Default.GetString(utfbytes);
                    }
                    covertedRow = new SummRadiation();
                    covertedRow.setCsvFieldHeaders(csv.FieldHeaders);
                    covertedRow.Fill(csv.FieldHeaders, newRow);
                    s.Add(covertedRow);
                }
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable dt = converter.ToDataTable(s);
                checkGridViewDataSource.clear();
                checkGridViewDataSource.fiilData(dt);
                dTable = checkGridViewDataSource.returnTable();
                ConvertFilename2DataTime Mesaga = new ConvertFilename2DataTime();
                FileInfo fi = new FileInfo(filename);
                labelGGGGmmDD = Mesaga.Convertor(fi.Name);
                DataEventGGGGMMDD args = new DataEventGGGGMMDD();
                args.GGGGMMDD = labelGGGGmmDD;
                setIsDataSouce(true);
                OnSaveAndExit.Invoke(args);
            }
            catch { }
        }
        public void openfileloadDoc_Click() // кнопка открытие файла настроек
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();
            filename = opf.FileName;                        
        }
        public string getOpenfileloadDoc_Click() // кнопка
        {            
            return filename;
        }
        private void buttonLoadDoc_Click(object sender, EventArgs e) // кнопка загрузки документа
        {
            openfileloadDoc_Click();
            loadDoc_Click();
            getIsReadyFiles(false);
            checkGridViewDataSource.OnSaveAndExit += saveData;
        }       
        public void setCheckGridView(DataTable dtt) // отправить таблицу в гридвью
        {
            checkGridViewDataSource.clear();
            checkGridViewDataSource.fiilData(dtt);
        }
        public DataTable getDataTable() // получить таблицу из гридвью
        {
            return checkGridViewDataSource.returnTable();
        }
        public void Export(string filename)//экспорт по названию файла
        {
            string fileCSV = "";
            for (int i = 0; i < checkGridViewDataSource.dataGridView1.Columns.Count; i++)
            {

                fileCSV += (checkGridViewDataSource.dataGridView1.Columns[i].HeaderText ?? "").ToString() + ";";
            }
            fileCSV += "\t\n";
            for (int i = 0; i < checkGridViewDataSource.dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < checkGridViewDataSource.dataGridView1.ColumnCount; j++)
                {
                    fileCSV += (checkGridViewDataSource.dataGridView1[j, i].Value ?? "").ToString() + ";";
                }
                fileCSV += "\t\n";
            }
            StreamWriter wr = new StreamWriter(filename, false, Encoding.GetEncoding(1251));
            wr.Write(fileCSV);
            wr.Close();            
        }
        private void buttonExportS_Click(object sender, EventArgs e)//кнопка экспорта
        {
            string filename = "";
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Экспорт";
            fileDialog.Filter = "CSV (Comma delimited) | .csv";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            filename = fileDialog.FileName;
            Export(filename);
        }          
        public void setIsDataSouce(bool iss) //тип источника данных
        {
            isDataSourceSeries = iss;
        }
        public bool getIsDataSouce()//узнать тип источника данных
        {
            return isDataSourceSeries;
        }
    }
    public class DataEventGGGGMMDD : EventArgs // агрумент даты
    {
        public int GGGGMMDD { get; set; }
       
    }
}
