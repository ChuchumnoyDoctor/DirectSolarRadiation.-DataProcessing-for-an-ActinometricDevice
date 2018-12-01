using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrPr5
{
    public class DataRomashka//класс, хранящий логику пользовательского элемента "Ромашка"
    {
        List<LepestokKontur> romashkaKontur = new List<LepestokKontur>();
        int Width;
        int Height;
        public List<LepestokKontur> getRomashkaKontur()//получение контура
        {
            return romashkaKontur;
        }
        public void setRomashkaKontur()//расположение лепестков и их размеры
        {
            //координаты хранятся в области 1000х1000 пикселей
            Width = Height = 1000;//ширина и высота элемента
            //список расположения лепестков
            int radius;
            radius = this.Width / 6;
            double promezhutok;
            promezhutok = 1.73205161514;//коэффициент м/у катетами
            promezhutok = radius * promezhutok;
            List<Point> pointLepestok = new List<Point>();
            //конечный набор статичных точек
            pointLepestok.Add(new Point() { X = Width / 2, Y = Height / 2 });//центральный лепесток
            pointLepestok.Add(new Point() { X = Width / 6, Y = Height / 2 });//левый лепесток
            pointLepestok.Add(new Point() { X = Width / 3, Y = (int)(Height / 2 - promezhutok) });//С-З
            pointLepestok.Add(new Point() { X = Width / 2 + this.Width / 6, Y = (int)(Height / 2 - promezhutok) });//С-В
            pointLepestok.Add(new Point() { X = Width / 2 + this.Width / 3, Y = Height / 2 });//Правый лепесток
            pointLepestok.Add(new Point() { X = Width / 2 + this.Width / 6, Y = (int)(Height / 2 + promezhutok) });//Ю-В
            pointLepestok.Add(new Point() { X = Width / 3, Y = (int)(Height / 2 + promezhutok) });//Ю-З
            LepestokKontur romashkaBuffer = new LepestokKontur();           
            foreach (Point pLep in pointLepestok)
            {
                romashkaBuffer = new LepestokKontur();
                romashkaBuffer = setLepestok(pLep, radius);//задаем характеристики лепестков
                //формируем контур ромашки
                romashkaKontur.Add(new LepestokKontur() { });
                romashkaKontur[romashkaKontur.Count-1] = romashkaBuffer;
            };            
        }
        public void clickCheckSet(bool isCheck, int numberLepest)
        {
            romashkaKontur[numberLepest].checkedLepestok = isCheck;
        }  
        public LepestokKontur setLepestok(Point xy, int r)
        {
            LepestokKontur lep = new LepestokKontur() { pointScreen = xy, radiusLepestok = r};
            return lep;
        }
    }
}
