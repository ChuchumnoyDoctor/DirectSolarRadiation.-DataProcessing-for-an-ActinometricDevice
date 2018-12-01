using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrPr5
{
    public partial class DrawRomashka : UserControl
    {
        public DrawRomashka()//отрисовка ромашки
        {
            InitializeComponent();
            //строгий порядок выполнения
            kR = new DataRomashka();//создание экземпляра
            kR.setRomashkaKontur();//создание контура          
            drawRomashk();
            //конец порядка
            try
            {//получение последнего графического ключа, выбранного пользователем
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
                var path = Path.GetDirectoryName(location);

                using (FileStream fs = new FileStream(path + @"\myDataIndexLastChoice.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    bufList = (List<LepestokKontur>)binaryFormatter.Deserialize(fs);
                    setListLepestok(bufList);
                }
            }
            catch
            {
            }
            int buf;
            buf = getKolvoCheckedLep();
            leftSide = buf.ToString();
            setNumbOfNumb();
        }
        List<LepestokKontur> bufList;
        string rightSide = "0";
        string leftSide = "0";
        bool isOkay;
        public bool getIsOkey()
        {
            bool ok;
            ok = isOkay;
            return ok;
        }
        public void setListLepestok(List<LepestokKontur> list)//отправка последнего графического ключа
        {
            if (list[0].checkedLepestok == true) { drawLepestok1.setIsCheked(); }//центральный лепесток       
            if (list[1].checkedLepestok == true) { drawLepestok2.setIsCheked(); }//З            
            if (list[2].checkedLepestok == true) { drawLepestok3.setIsCheked(); }//с-з           
            if (list[3].checkedLepestok == true) { drawLepestok4.setIsCheked(); }//с-в            
            if (list[4].checkedLepestok == true) { drawLepestok5.setIsCheked(); }//в            
            if (list[5].checkedLepestok == true) { drawLepestok6.setIsCheked(); }//ю-в           
            if (list[6].checkedLepestok == true) { drawLepestok7.setIsCheked(); }//ю-з           
        }
        public string getNumb()
        {
            string buf;
            buf = labelNumbOfNumb.Text;
            return buf;
        }
        public List<LepestokKontur> getListCheckedLep()//получение графического ключа
        {           
            bool buf;
            DataRomashka bufData = new DataRomashka();
            bufList = new List<LepestokKontur>();
            bufData.setRomashkaKontur();
            buf = drawLepestok1.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 0); } else { bufData.clickCheckSet(false, 0); }//центральный лепесток
            buf = drawLepestok2.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 1); } else { bufData.clickCheckSet(false, 1); }//з
            buf = drawLepestok3.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 2); } else { bufData.clickCheckSet(false, 2); }//с-з
            buf = drawLepestok4.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 3); } else { bufData.clickCheckSet(false, 3); }//с-в
            buf = drawLepestok5.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 4); } else { bufData.clickCheckSet(false, 4); }//в
            buf = drawLepestok6.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 5); } else { bufData.clickCheckSet(false, 5); }//ю-в
            buf = drawLepestok7.getIsCheked();
            if (buf == true) { bufData.clickCheckSet(true, 6); } else { bufData.clickCheckSet(false, 6); }//ю-з
            bufList = bufData.getRomashkaKontur();            
            return bufList;
        }
        public int getKolvoCheckedLep()//получение количества включенных лепестков
        {
            bool buf;
            int i = 0;
            buf = drawLepestok1.getIsCheked();
            if (buf == true) { i++; }//центральный лепесток
            buf = drawLepestok2.getIsCheked();
            if (buf == true) { i++; }//з
            buf = drawLepestok3.getIsCheked();
            if (buf == true) { i++; }//с-з
            buf = drawLepestok4.getIsCheked();
            if (buf == true) { i++; }//с-в
            buf = drawLepestok5.getIsCheked();
            if (buf == true) { i++; }//в
            buf = drawLepestok6.getIsCheked();
            if (buf == true) { i++; }//ю-в
            buf = drawLepestok7.getIsCheked();
            if (buf == true) { i++; }//ю-з
            return i;
        }        
        Bitmap bmp;
        Graphics g;
        DataRomashka kR = new DataRomashka();
        List<LepestokKontur> drawKonturRomahi = new List<LepestokKontur>();
        List<newLabel> bufListPoint = new List<newLabel>();
        List<DrawLepestok> f = new List<DrawLepestok>();       
        double koeffecientOfData2Draw; //в дате коор хранятся в области 1000х1000
        public void drawRomashk()//отрисовка ромашки
        {
            koeffecientOfData2Draw = (float)(this.Width) / 1000;           
            bmp = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);          
            drawKonturRomahi = kR.getRomashkaKontur();
            try
            {
                reDrawLep();
            }
            catch { }
            this.Refresh();            
        }
        public Point drawIsCheckLepestok(Point xy, int rad)//получение координат для лепестков
        {
            DrawLepestok p;
            Point newLoc;
            p = new DrawLepestok();
            int koorX = (int)((xy.X - rad) * koeffecientOfData2Draw);
            int koorY = (int)((xy.Y - rad) * koeffecientOfData2Draw);
            newLoc = new Point(koorX, koorY);
            p.Location = newLoc;
            return newLoc;
        }     
        public void reDrawLep()//переотрисовка лепестка
        {
            Point loc = new Point();
            Size si = new Size();
            int lepWidth;
            int lepHeight;
            lepWidth = (int)(this.Width / 3);
            lepHeight = lepWidth;
            si = new Size(lepWidth, lepHeight);
            //первый лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[0].pointScreen, drawKonturRomahi[0].radiusLepestok);
            drawLepestok1.Size = si;
            drawLepestok1.Location = loc;
            //второй лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[1].pointScreen, drawKonturRomahi[1].radiusLepestok);
            drawLepestok2.Size = si;
            drawLepestok2.Location = loc;
            //третий лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[2].pointScreen, drawKonturRomahi[2].radiusLepestok);
            drawLepestok3.Size = si;
            drawLepestok3.Location = loc;
            //четвертый лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[3].pointScreen, drawKonturRomahi[3].radiusLepestok);
            drawLepestok4.Size = si;
            drawLepestok4.Location = loc;
            //пятый лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[4].pointScreen, drawKonturRomahi[4].radiusLepestok);
            drawLepestok5.Size = si;
            drawLepestok5.Location = loc;
            //шестой лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[5].pointScreen, drawKonturRomahi[5].radiusLepestok);
            drawLepestok6.Size = si;
            drawLepestok6.Location = loc;
            //седьмой лепесток
            loc = drawIsCheckLepestok(drawKonturRomahi[6].pointScreen, drawKonturRomahi[6].radiusLepestok);
            drawLepestok7.Size = si;
            drawLepestok7.Location = loc;
        }
        private void DrawRomashka_Resize(object sender, EventArgs e)//при изменении размера
        {
            Point newLoc;
            newLoc = new Point(this.Width / 2 - labelSelectDatchik.Width/2 - labelNumbOfNumb.Width/2, this.Height - labelNumbOfNumb.Height * 2);
            labelSelectDatchik.Location = newLoc;
            newLoc = new Point(newLoc.X + labelSelectDatchik.Width - 5, this.Height - (labelNumbOfNumb.Height * 2));
            labelNumbOfNumb.Location = newLoc;
            drawRomashk();
        }
        private void drawLepestok6_MouseClick(object sender, MouseEventArgs e)//при нажатии мышью на лепесток
        {
            int buf;
            buf = getKolvoCheckedLep();
            leftSide = buf.ToString();
            setNumbOfNumb();

        }
        public void setNumbOfNumb()
        {
            if (leftSide == rightSide) isOkay = true;
            else isOkay = false;
            labelNumbOfNumb.Text = leftSide + "/" + rightSide;
        }
        public void setRightSideCheck(int right)
        {
            rightSide = right + "";
            setNumbOfNumb();
        }
    }
}
