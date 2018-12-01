using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrPr5
{
    public partial class PropertyOfDevice : UserControl
    {
        List<DVORVAK> VarOfRom = new List<DVORVAK>(); // лист из графических ключей и конфигурации устройства
        string NumbOfNumb = ""; //буфер 7/7
        string rightSide;
        int index;    
        public PropertyOfDevice()
        {
            InitializeComponent();
            try//считывание листа из ключей
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
                var path = Path.GetDirectoryName(location);
                using (FileStream fs = new FileStream(path + @"\myData.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    VarOfRom = (List<DVORVAK>)binaryFormatter.Deserialize(fs);
                }
            }
            catch
            {
            }
            NumbOfNumb = drawRomashka1.getNumb();
            timerProverkyLepestkov.Start();
            index = takeKeyInDataSource(1);
            setTextsBoxs(index);
        }
        public List<string> getSettings()//получение конфигурации
        {
            string StartI;
            string EndI;
            string StepI;
            StartI = labelVStart.Text;
            EndI = labelVEnd.Text;
            StepI = labelVStep.Text;
            List<string> list = new List<string>();
            list.Add(StartI);
            list.Add(EndI);
            list.Add(StepI);
            list.Add(labelVDiapazon.Text);
            list.Add(VarOfRom[index].ValueOfDIV.shirota);
            return list;
        }
        public void setRightSideCheck(int right)
        {
            rightSide = right + "";
            drawRomashka1.setRightSideCheck(right);
        }
        private void button2_Click(object sender, EventArgs e)//кнопка перехода на форму с настройками конфигурации
        {
            string startIzm;
            string endIzm;
            string stepIzm;
            string place;
            string shirota;
            string dolgota;
            string diapazon;
            startIzm = labelVStart.Text;
            endIzm = labelVEnd.Text;
            stepIzm = labelVStep.Text;
            place = labelVPlace.Text;
            shirota = VarOfRom[index].ValueOfDIV.shirota;
            dolgota = VarOfRom[index].ValueOfDIV.dolgota;
            diapazon = labelVDiapazon.Text;
            Options f = new Options(startIzm, endIzm, stepIzm, place, shirota, dolgota, diapazon);
            f.OnSaveAndExit += saveData;
            f.ShowDialog();
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
                var path = Path.GetDirectoryName(location);
                using (FileStream fs = new FileStream(path + @"\myData.dat", FileMode.OpenOrCreate))
                {
                    // сериализуем весь массив people
                    binaryFormatter.Serialize(fs, VarOfRom);
                    Console.WriteLine("Объект сериализован");
                }
            }
            catch { }            
        }
        private void saveData(DataEventArgumnts e)//метод обработки сохранения данных конфигурации
        {
            labelVStart.Text = e.startIzmer;
            labelVEnd.Text = e.endIzmer;
            labelVStep.Text = e.stepIzmer;
            labelVPlace.Text = e.opisanie;
            labelVDiapazon.Text = e.diapazon;
            VarOfRom[index].ValueOfDIV.startVremyaIzmer = labelVStart.Text;
            VarOfRom[index].ValueOfDIV.endVremyaIzmer = labelVEnd.Text;
            VarOfRom[index].ValueOfDIV.stepIzmer = labelVStep.Text;
            VarOfRom[index].ValueOfDIV.opisanie = labelVPlace.Text;
            VarOfRom[index].ValueOfDIV.shirota = e.shirota;
            VarOfRom[index].ValueOfDIV.dolgota = e.dolgota;
            VarOfRom[index].ValueOfDIV.diapazonVremyaIzmer = e.diapazon;
        }
        public List<LepestokKontur> takeKeyFromRomashka()// графический ключ из элемента "Ромашка"
        {
            List<LepestokKontur> buf;
            buf =  drawRomashka1.getListCheckedLep();
            return buf;
        }
        public void proverkaLep()
        {
            string buf;
            buf = drawRomashka1.getNumb();
            if (NumbOfNumb != buf)
            {
                NumbOfNumb = buf;
                index = takeKeyInDataSource(1);
                setTextsBoxs(index);
            }
        }
        private void timerProverkyLepestkov_Tick(object sender, EventArgs e)
        {
            proverkaLep();
        }
        public int takeKeyInDataSource(int ii)
        {
            bool buf = false;
            List<LepestokKontur> key = new List<LepestokKontur>();
            int i = 0;
            key = takeKeyFromRomashka();                  
            if (ii == 1)
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
                    var path = Path.GetDirectoryName(location);

                    using (FileStream fs = new FileStream(path + @"\myDataIndexLastChoice.dat", FileMode.OpenOrCreate))
                    {
                        binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        binaryFormatter.Serialize(fs, key);
                        Console.WriteLine("Объект сериализован");
                    }
                }
                catch { }               
            }
            foreach (DVORVAK rom in VarOfRom)
            {
                List<LepestokKontur> bufkey = new List<LepestokKontur>();
                bufkey = rom.KeyOfDR;
                if (SequenceEqual(key, bufkey) == true)
                {
                    buf = true;                 
                }               
            }
            if (buf == false)
            {
                DVORVAK dVORVAK = new DVORVAK();
                dVORVAK.KeyOfDR = key;
                VarOfRom.Add(dVORVAK);               
            }
            int j = 0;
            List<LepestokKontur> bufk = new List<LepestokKontur>();
            for (i=0; i < VarOfRom.Count; i++)
            {
                bufk = VarOfRom[i].KeyOfDR;
                if (SequenceEqual(key, bufk) == true) { j = i; }
            }          
            return j;
        }
        public bool eqOf2Lep(Point a, int b, bool c, Point a1, int b1, bool c1)//сопоставление ключей
        {
            bool tr;
            tr = true;
            if (a != a1) { tr = false; }
            if (b != b1) { tr = false; }
            if (c != c1) { tr = false; }
            return tr;
        }
        public bool SequenceEqual(List<LepestokKontur> a, List<LepestokKontur> b)
        {
            bool e = false;
            for (int i = 0; i < a.Count; i++)
            {
                e = false;
                e = eqOf2Lep(a[i].pointScreen, a[i].radiusLepestok, a[i].checkedLepestok, b[i].pointScreen, b[i].radiusLepestok, b[i].checkedLepestok);
                if (e == false) { break; }
            }            
            return e;
        }   
        public void setTextsBoxs(int i)//применение и отображение конфигурации, согласно графическому ключу
        {
            DataIzmerValue buf = new DataIzmerValue { };
            if (VarOfRom[i].ValueOfDIV == null)//в случае нового ключа добавляется пустая конфигурация
            {
                DataIzmerValue bufValue = new DataIzmerValue();
                bufValue.startVremyaIzmer = "";
                bufValue.endVremyaIzmer = "";
                bufValue.stepIzmer = "";
                bufValue.shirota = "";
                bufValue.dolgota = "";
                bufValue.opisanie = "";
                bufValue.diapazonVremyaIzmer = "";
                VarOfRom[i].ValueOfDIV = bufValue;
            }
            buf = VarOfRom[i].ValueOfDIV;
            labelVStart.Text = buf.startVremyaIzmer;
            labelVEnd.Text = buf.endVremyaIzmer;
            labelVStep.Text = buf.stepIzmer;
            labelVPlace.Text = buf.opisanie;
            labelVDiapazon.Text = buf.diapazonVremyaIzmer;
        }    
        private void groupBoxPropertyDevice_Resize(object sender, EventArgs e)//при изменении размера элемента
        {
            labelNorth.Location = new Point(panel2.Width / 2 - labelNorth.Width/2, 5);
            labelSouth.Location = new Point(panel2.Width / 2 - labelSouth.Width/2, panel2.Height - labelSouth.Height -35);
            labelWest.Location = new Point(0, panel2.Height / 2 - labelWest.Height / 2 -12);
            labelEast.Location = new Point(panel2.Width - labelEast.Width, panel2.Height / 2 - labelEast.Height / 2 -12);
            drawRomashka1.Location = new Point(panel2.Width/2 - drawRomashka1.Width/2, panel2.Height / 2 - drawRomashka1.Height / 2);
        }

        private void PropertyOfDevice_Load(object sender, EventArgs e)//при загрузке элемента
        {
            timerProverkyLepestkov.Enabled = true;
        }
    }
}
