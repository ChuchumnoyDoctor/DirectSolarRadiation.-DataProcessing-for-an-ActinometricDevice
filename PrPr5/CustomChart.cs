using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static PrPr5.Seria;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Imaging;

namespace PrPr5
{
    public partial class CustomChart : UserControl
    {
        public CustomChart()// Диаграмма
        {
            InitializeComponent();   
            drawingPanel = panelDiagramma;
            DataOfDiag = new DataOptionsOfDiagramm();
            //статичных набор  
            try//считываются настройки из файла
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
                var path = Path.GetDirectoryName(location);
                using (FileStream fs = new FileStream(path + @"\myDataOfDiag.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    DataOfDiag = (DataOptionsOfDiagramm)binaryFormatter.Deserialize(fs);
                }
            }           
            catch//в случае неудачи применяется стандартный набор данных для диаграммы
            {
                DataOfDiag.innerMarginLeft = 110;
                DataOfDiag.innerMarginRight = 50;
                DataOfDiag.innerMarginTop = 50;
                DataOfDiag.innerMarginBottom = 70;
                DataOfDiag.numEdgesX = 24;//количество делений по оси Х
                DataOfDiag.numEdgesY = 12;//количество делений по оси У
                DataOfDiag.totalMinutes = 24 * 60;//максимальное значение по оси Х
                DataOfDiag.totalRadiation = 1200;//максимальное значение по оси Y     
                DataOfDiag.isLinesOfSer = true;
                DataOfDiag.isPointsOfSer = true;
                DataOfDiag.isLinesOfSer = true;
                DataOfDiag.isPointsOfSer = true;
                DataOfDiag.radius = 5;
            }
            bmpp = new Bitmap(this.Width, this.Height);
            Graphics p = Graphics.FromImage(bmpp);//изображение к ней  
            reDrawPictureBox();
        }     
        DataTable DtForSeriesReturn;
        bool isRamka = false;
        Bitmap bmpp;     
        bool is_m_still_down = false;
        Rectangle rect;
        public int shagSec { get; set; }        
        DataOptionsOfDiagramm DataOfDiag;
        public Control drawingPanel;//на чем отрисовывать      
        List<Seria> series = new List<Seria>();//массив графиков + S'график
        bool isNewDataSource;      
        string startIzmer;//начало измер    
        string endIzmer;//конец измер
        string stepIzmer;//интервал измер
        int stepX;//шаг по оси Х
        int stepY;//шаг по оси У
        int offset;//отступ
        int maxWidth; //макс широта в пикселях
        int maxHeight;//макс высота в пикселях     
        Point startCoordinates;//начало координат
        Pen gridColor = new Pen(Color.Silver, 0.3f);//цвет сетки
        Pen graphColor = new Pen(Color.Black, 1f);//цвет осей      
        Bitmap bmp;//битмапа, на которой будем изображать
        Graphics g;//графика к ней     
        List<DataLegRow> DLR;
        string TextOsY = "Радиация, Вт/м2";//Легенда оси У     
        string labelData1= "Дата: ";//label со следующим текстом: "Дата: "
        DataTable DtForSeries;
        public int diapazon { get; set; }
        public int radius { get; set; }
        public int StepX { get { return stepX; } set { stepX = value; } }
        public int StepY { get { return stepY; } set { stepY = value; } }
        public int Offset { get { return offset; } set { offset = value; } }
        public string StartIzmer { get { return startIzmer; } set { startIzmer = value; } }
        public string EndIzmer { get { return endIzmer; } set { endIzmer = value; } }
        public string StepIzmer { get { return stepIzmer; } set { stepIzmer = value; } }
        float minute2pixel;//коэфициент перевода из минут в пиксели 
        float Radiation2pixel;//коэфициент перевода из радиации в пиксели   
        float minute2pixelUvel;
        float Radiation2pixelUvel;
        public DataTable DT; //датасорс таблица
        List<string> DelenieXValue = null;//список делений Х
        List<string> DelenieYValue = null;//список делений У
        int endx;
        int endy;
        int lineSizeX;//Длина оси Ох до последнего деления
        int lineSizeY; //Длина оси Оу до последнего деления
        int lineOffset = 5; //отступ
        int KStrelki = 3;//стрелки осей
        public bool isDataSourceSeries { get; set; }  
        List<PointCoorGrValue> gh = new List<PointCoorGrValue>();
        private bool is_m_down;
        private Point mdown;

        public void setSettings(string Start, string End, string Step, int diapazon)//метод отправки конфигурации
        {
            StartIzmer = Start;
            EndIzmer = End;
            StepIzmer = Step;
            this.diapazon = diapazon;
            reDrawPictureBox();
        }          
        private void CustomChart_Paint(object sender, PaintEventArgs e)//метод получение графики
        {
            e.Graphics.DrawImageUnscaled(bmp, Point.Empty);
            e.Graphics.DrawImageUnscaled(bmpp, Point.Empty);
        }
        public void drawAxis()//рисуем оси
        {
            g.DrawLine(graphColor, DataOfDiag.innerMarginLeft, DataOfDiag.innerMarginTop, DataOfDiag.innerMarginLeft, maxHeight - DataOfDiag.innerMarginBottom); //Отрисовка оси Y            
            g.DrawLine(graphColor, new Point(DataOfDiag.innerMarginLeft, maxHeight - DataOfDiag.innerMarginBottom), new Point(maxWidth - DataOfDiag.innerMarginRight, maxHeight - DataOfDiag.innerMarginBottom));//Отрисовка оси Х            
            g.DrawLine(graphColor, DataOfDiag.innerMarginLeft, DataOfDiag.innerMarginTop, DataOfDiag.innerMarginLeft + lineOffset, DataOfDiag.innerMarginTop + lineOffset * KStrelki);//Отрисовка 
            g.DrawLine(graphColor, DataOfDiag.innerMarginLeft, DataOfDiag.innerMarginTop, DataOfDiag.innerMarginLeft - lineOffset, DataOfDiag.innerMarginTop + lineOffset * KStrelki);//стрелки оси Y           
            g.DrawLine(graphColor, new Point(maxWidth - DataOfDiag.innerMarginRight - lineOffset * KStrelki, maxHeight - DataOfDiag.innerMarginBottom + lineOffset), new Point(maxWidth - DataOfDiag.innerMarginRight, maxHeight - DataOfDiag.innerMarginBottom));//Отрисовка         
            g.DrawLine(graphColor, new Point(maxWidth - DataOfDiag.innerMarginRight - lineOffset * KStrelki, maxHeight - DataOfDiag.innerMarginBottom - lineOffset), new Point(maxWidth - DataOfDiag.innerMarginRight, maxHeight - DataOfDiag.innerMarginBottom));//стрелки оси Х
            //Деления ОСи X
            int constY = maxHeight - DataOfDiag.innerMarginBottom;//константа координат Y по оси Х
            for (endx = startCoordinates.X + StepX; endx + StepX <= maxWidth - DataOfDiag.innerMarginRight; endx += StepX)
            {
                g.DrawLine(gridColor, endx, constY - lineOffset, endx, 0);
                g.DrawLine(graphColor, endx, constY - lineOffset, endx, constY + lineOffset);
            }        
            //Деления оси Y
            int constX = DataOfDiag.innerMarginLeft;//константа координат X по оси Y
            for (endy = startCoordinates.Y - StepY; endy - StepY >= DataOfDiag.innerMarginTop; endy -= StepY)
            {
                g.DrawLine(gridColor, constX - lineOffset, endy, maxWidth, endy);
                g.DrawLine(graphColor, constX - lineOffset, endy, constX + lineOffset, endy);
            }            
            drawingPanel.Invalidate();
        }
        public List<Seria> getSeriesFromDiagramma()//метод получения графиков
        {
            return bitmapOfSeries1.getSeriesFromDiagramma();
        }
        public void setDataSource(DataTable dt)//метод отправки источника данных
        {
            bitmapOfSeries1.Hide();
            DtForSeries = dt;
            DtForSeriesReturn = dt; ;
            bitmapOfSeries1.StartIzmer = StartIzmer;
            bitmapOfSeries1.EndIzmer = EndIzmer;
            bitmapOfSeries1.StepIzmer = StepIzmer;
            bitmapOfSeries1.diapazon = diapazon;
            bitmapOfSeries1.setSettings(0 ,DataOfDiag.totalMinutes + "", 0 , DataOfDiag.totalRadiation + "", DataOfDiag.isLinesOfSer, DataOfDiag.isPointsOfSer, DataOfDiag.radius);
            bitmapOfSeries1.setDataSource(DtForSeries, isDataSourceSeries);
            newDataSource();
            if (isNewDataSource == true)//legendBox
            {
                legBox1.setLegBox(getLegendSeriesFromDiagramm());
                isNewDataSource = false;
            }
            legBox1.rowList.ForEach(t => t.checkBoxVisible.CheckedChanged += changeChecked);
            try
            {
                setDeleniyaOSsText(0, DataOfDiag.totalMinutes, 0 , DataOfDiag.totalRadiation);//добавление осей в массив
                drawDeleniyaOSsText();
            }
            catch { }//отрисовка описание делений по осям          
            bitmapOfSeries1.Show();
        }
        public void drawDeleniyaOSsText()//метод отрисовки надписей для делений осей
        {
            bool isRemove;
            do
            {
                isRemove = false;
                foreach (Control c in drawingPanel.Controls)
                {
                    if (c is newLabel)
                    {
                        drawingPanel.Controls.Remove(c);
                        isRemove = true;
                    }
                }
            } while (isRemove);
            //Деления оси X, подписи
            int constY = maxHeight - DataOfDiag.innerMarginBottom;
            StringFormat f = new StringFormat();
            Brush textBrush = new SolidBrush(this.ForeColor);
            for (int i = (DelenieXValue.Count - 1) * StepX + startCoordinates.X, k = DelenieXValue.Count - 1; i >= startCoordinates.X; i -= StepX, k--)
            {
                string MessageOnLabel = DelenieXValue[k];
                double sizeWH;
                newLabel newlbl = new newLabel() { };
                newlbl.Text = "";
                newlbl.AutoSize = false;
                newlbl.NewText = MessageOnLabel;
                sizeWH = newlbl.Width;
                newlbl.ForeColor = Color.Black;
                int RotateAngle = 60;
                newlbl.RotateAngle = RotateAngle;
                sizeWH = Math.Sqrt(sizeWH * sizeWH) / 2;
                newlbl.Size = new System.Drawing.Size((int)sizeWH - lineOffset, (int)sizeWH - lineOffset);
                newlbl.Location = new Point(i - lineOffset, constY + lineOffset);
                drawingPanel.Controls.Add(newlbl);
                drawingPanel.Invalidate();
            }
            //Деления оси Y
            int constX = DataOfDiag.innerMarginLeft;
            for (int i = startCoordinates.Y - StepY, k = 0; i - StepY >= DataOfDiag.innerMarginTop; i -= StepY, k++)
            {               
                double sizeWH;
                newLabel newlbl = new newLabel() { };
                newlbl.Text = "";
                newlbl.AutoSize = false;
                newlbl.NewText = DelenieYValue[k];
                sizeWH = newlbl.Width;
                newlbl.ForeColor = Color.Black;
                int RotateAngle = 0;
                newlbl.RotateAngle = RotateAngle;
                sizeWH = Math.Sqrt(sizeWH * sizeWH) / 2;
                newlbl.Size = new System.Drawing.Size((int)sizeWH - lineOffset, (int)sizeWH - lineOffset);
                newlbl.Location = new Point(constX - DataOfDiag.innerMarginBottom / 20 - newlbl.Width, i - newlbl.Height/10);
                drawingPanel.Controls.Add(newlbl);
                drawingPanel.Invalidate();
            }
            drawingPanel.Invalidate();
        }
        public void DrawTextOsY()// метод отрисовки подписи оси У
        {//подпись оси У
            int innerMarginTextOsY;
            Font mesaga;
            mesaga = new Font(buttonSettings.Font.Name, 16, buttonSettings.Font.Style);
            TextOsY = "Радиация, Вт/м2";//Легенда оси У
            Brush textBrush = new SolidBrush(this.ForeColor);
            SizeF textImageSize = g.MeasureString(TextOsY, mesaga);
            Bitmap str = new Bitmap((int)textImageSize.Width, (int)textImageSize.Height);
            Graphics strgr = Graphics.FromImage(str);
            strgr.DrawString(TextOsY, mesaga, textBrush, 0f, 0f);
            strgr.Save();
            str.RotateFlip(RotateFlipType.Rotate270FlipNone);
            innerMarginTextOsY = DataOfDiag.innerMarginLeft /2 + str.Width;
            g.DrawImage(str, startCoordinates.X - innerMarginTextOsY, maxHeight / 2 - str.Height/2, str.Width, str.Height);
            drawingPanel.Invalidate();   
        }      
        public void SetLabelGGGGMMDD1(string value)
        {//Лейбл ГодМесяцДень
            LabelGGGGMMDD.Text = value;
        }       
        private void CustomChart_Resize_1(object sender, EventArgs e)
        {//При изменении чарта
            try
            {
                reDrawPictureBox();
            }
            catch { }            
        }
        private void buttonSettings_Click(object sender, EventArgs e)//кнопка отправления конфига
        {
            OptionsOfDiagramm f = new OptionsOfDiagramm(DataOfDiag.innerMarginLeft.ToString(), DataOfDiag.innerMarginRight.ToString(), DataOfDiag.innerMarginTop.ToString(),
                DataOfDiag.innerMarginBottom.ToString(), DataOfDiag.numEdgesX.ToString(), DataOfDiag.numEdgesY.ToString(), DataOfDiag.totalMinutes.ToString(), DataOfDiag.totalRadiation.ToString(),
                DataOfDiag.isLinesOfSer, DataOfDiag.isPointsOfSer, DataOfDiag.radius);
            f.OnSaveAndExit += saveSettings;//метод получения
            f.ShowDialog();//вызов окна формы
            try
            {//отправка конфига в файл, локально распологающийся
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
                var path = Path.GetDirectoryName(location);
                using (FileStream fs = new FileStream(path + @"\myDataOfDiag.dat", FileMode.OpenOrCreate))
                {
                    // сериализуем весь массив
                    binaryFormatter.Serialize(fs, DataOfDiag);
                    Console.WriteLine("Объект сериализован");
                }
            }
            catch
            {
            }           
        }
        private void saveSettings(DataEventOptionsDiagramma e)//метод применения и сохранения полученного конфига
        {
            if(e.isChange == true)
            {
                bitmapOfSeries1.Hide();
                this.Hide();
                DataOfDiag.innerMarginLeft = int.Parse(e.innerMarginLeft);
                DataOfDiag.innerMarginRight = int.Parse(e.innerMarginRight);
                DataOfDiag.innerMarginBottom = int.Parse(e.innerMarginBottom);
                DataOfDiag.innerMarginTop = int.Parse(e.innerMarginTop);
                DataOfDiag.numEdgesX = int.Parse(e.numEdgesX);
                DataOfDiag.numEdgesY = int.Parse(e.numEdgesY);
                DataOfDiag.totalMinutes = int.Parse(e.totalMinutes);
                DataOfDiag.totalRadiation = int.Parse(e.totalRadiation);
                DataOfDiag.isLinesOfSer = e.isLinesOfSer;
                DataOfDiag.isPointsOfSer = e.isPointsOfSer;
                DataOfDiag.radius = e.radius;               
                reDrawPictureBox();
                try
                {
                    setDeleniyaOSsText(0, DataOfDiag.totalMinutes, 0, DataOfDiag.totalRadiation);//добавление осей в массив
                    drawDeleniyaOSsText();
                }
                catch { }//отрисовка описание делений по осям   
                try
                {
                    bitmapOfSeries1.setSettings(0, DataOfDiag.totalMinutes + "", 0, DataOfDiag.totalRadiation + "", DataOfDiag.isLinesOfSer, DataOfDiag.isPointsOfSer, DataOfDiag.radius);
                    bitmapOfSeries1.setDataSource(DtForSeries, isDataSourceSeries);
                }
                catch { }                    
                try
                {
                    proverkaChangeCheked();
                }
                catch
                {
                }
                this.Show();
                bitmapOfSeries1.Show();
            }
        }
        public void setDeleniyaOSsText(int nachaloX, int endX, int nachaloY, int endY)
        {
            int KratnoeDel;//единица измерения между делениями 
            //Ось Х
            //еденица измерений = всего минут по оси Х / количество делений
            //кратноедел = (конец - начало времени)/DataOfDiag.numEdgesX
            //totalMinutes = начало + разность
            int nachaloTime = nachaloX;
            int raznostTime = 0;
            int endTime = endX;
            raznostTime = endTime - nachaloTime;
            KratnoeDel = raznostTime / DataOfDiag.numEdgesX;
            //KratnoeDel = (int)DataOfDiag.totalMinutes / DataOfDiag.numEdgesX; // 60 минут на 24 деления
            DelenieXValue = new List<string>();//Массив делений по оси Х
            for (int i = nachaloTime; i <= endTime - 1; i += KratnoeDel)
            {
                string mesaga;
                int h = (int)(i / 60);
                int m = (int)i - h * 60;
                mesaga = h + ":" + m + ":00";//деление - строка
                DelenieXValue.Add(mesaga);//добавили в массив Х название деления
            }
            //ОСЬ Y
            DelenieYValue = new List<string>();//Массив делений по оси У
                                               //totalMinutes = начало + разность
            int nachaloRad = nachaloY;
            int raznostRad = 0;
            int endRad = endY;
            raznostRad = endRad - nachaloRad;
            KratnoeDel = raznostRad / DataOfDiag.numEdgesY;
            //KratnoeDel = (int)DataOfDiag.totalRadiation / DataOfDiag.numEdgesY;
            for (int i = nachaloRad + KratnoeDel; i <= endRad - KratnoeDel; i += KratnoeDel)
            {
                //деление - число
                DelenieYValue.Add(i + "");//массив элементов для делений по оси Х
            }
        }
        public void reDrawPictureBox()//перерисовка основы диаграммы
        {
            {               
                drawingPanel = panelDiagramma;               
                maxWidth = this.Width;//нью широта
                maxHeight = this.Height;//нью высота
                startCoordinates = new Point(DataOfDiag.innerMarginLeft, maxHeight - DataOfDiag.innerMarginBottom);//начало координат
                bmp = new Bitmap(maxWidth, maxHeight);//новая битмапа
                g = Graphics.FromImage(bmp);//изображение к ней            
                StepX = (maxWidth - DataOfDiag.innerMarginLeft - DataOfDiag.innerMarginRight) / DataOfDiag.numEdgesX;//шаг по оси у
                StepY = (maxHeight - DataOfDiag.innerMarginTop - DataOfDiag.innerMarginBottom) / DataOfDiag.numEdgesY;//Шаг по оси х                
                lineSizeX = (maxWidth - DataOfDiag.innerMarginLeft - DataOfDiag.innerMarginRight);//длина оси Х в пикселях
                lineSizeY = (maxHeight - DataOfDiag.innerMarginTop - DataOfDiag.innerMarginBottom);//длина оси У в пикселях
                minute2pixel = (float)lineSizeX / DataOfDiag.totalMinutes;//коэфициент из минут в пиксели
                Radiation2pixel = (float)lineSizeY / DataOfDiag.totalRadiation;//коэфициент из радиации в пиксели    
                minute2pixelUvel = minute2pixel;
                Radiation2pixelUvel = Radiation2pixel;
                int innerLegendbox = 10;//отступ для легенд бокса   
                labelData.Location = new Point(innerLegendbox, maxHeight - labelData.Height - innerLegendbox);//локейшн
                labelData.Text = labelData1;//дата
                LabelGGGGMMDD.Location = new Point(innerLegendbox + labelData.Width, maxHeight - LabelGGGGMMDD.Height - innerLegendbox);//локейшн                
                labelObnovlenie.Location = new Point(LabelGGGGMMDD.Location.X + LabelGGGGMMDD.Width + 10, LabelGGGGMMDD.Location.Y);
                drawAxis();//отрисовка осей и сетки 
                DrawTextOsY();//описание оси У
                bitmapOfSeries1.OnSaveAndExit += saveData;
                bitmapOfSeries1.Location = new Point(DataOfDiag.innerMarginLeft, DataOfDiag.innerMarginTop);
                bitmapOfSeries1.Size = new Size(this.Width - DataOfDiag.innerMarginLeft - DataOfDiag.innerMarginRight, this.Height - DataOfDiag.innerMarginBottom - DataOfDiag.innerMarginTop);
                bitmapOfSeries1.setRamkaClear();
                bitmapOfSeries1.clearRectangle();
                buttonCancelUvelechenie.Hide();
                buttonUvelichit.Hide();
            }
            drawingPanel.Invalidate();//обновить            
        }
        public void hideLabelObnovlenie()
        {
            labelObnovlenie.Enabled = false;
        }
        public void showLabelObnovlenie()
        {
            labelObnovlenie.Enabled = true;
        }
        public void changeLabelObnovlenie(int x)// x - секунды
        {
            string ob;
            int hour = 0;
            int min = 0;
            int sec = 0;
            x = x - shagSec;
            hour = x / 60 / 60;
            min = (x - hour * 60 * 60)/60;
            sec = (x - hour * 60 * 60 - min * 60);
            string h ="";
            string m = "";
            string s = "";
            if(hour < 10)
            {
                h = "0" + hour;
            }
            else
            {
                h = hour + "";
            }
            if (min < 10)
            {
                m = "0" + min;
            }
            else
            {
                m = min + "";
            }
            if (sec < 10)
            {
                s = "0" + sec;
            }
            else
            {
                s = sec + "";
            }
            ob = h + ":" + m + ":" + s;
            labelObnovlenie.Text = "Обновление через: " + ob;
            shagSec++;
        }
        private void saveData(DataEventValueShow e)
        {
            pointValueShow1.show(e.legendText, e.x, e.y,e.locx+ DataOfDiag.innerMarginLeft,e.locy+ DataOfDiag.innerMarginTop);
        }
        public void newDataSource()
        {
            isNewDataSource = true;           
        }
        public void proverkaChangeCheked()
        {
            series = bitmapOfSeries1.getSeriesFromDiagramma();
            foreach (LegendRow lr in legBox1.rowList)
            {
                string text;
                bool chek;
                text = lr.labelSeries.Text;
                chek = lr.checkBoxVisible.Checked;
                checkedChanged2VisibleSeries(text, chek);
            }
            bitmapOfSeries1.setSeriesFromDiagramma(series);
            bitmapOfSeries1.reDrawPictureBox();
            bitmapOfSeries1.reDraw();
        }
        private void changeChecked(object sender, EventArgs e)
        {//Вызов чек из леджендбокса           
            LegendRow legendRow = sender as LegendRow;
            bitmapOfSeries1.Hide();
            proverkaChangeCheked();
            bitmapOfSeries1.Show();
        }
        public void checkedChanged2VisibleSeries(string text, bool vis)
        {           
            foreach (Seria seria in series)
            {
                if (seria.GetLegendText() == text)
                {
                    seria.SetIsDrawing(vis);
                    if(text == legBox1.rowList[legBox1.rowList.Count-1].labelSeries.Text)
                    {
                        foreach (PointCoorGrValue pr in seria.points)
                        {
                            pr.visible = vis;
                        }
                    }
                    else
                    {
                        if (DataOfDiag.isPointsOfSer)
                            foreach (PointCoorGrValue pr in seria.points)
                            {
                                pr.visible = vis;
                            }
                    }                                 
                }                
            }            
        }
        public List<DataLegRow> getLegendSeriesFromDiagramm()//получение данных о графиках
        {           
            series = bitmapOfSeries1.getSeriesFromDiagramma();
            DLR = new List<DataLegRow>();            
            foreach (Seria seria in series)
            {
                DLR.Add(new DataLegRow());
                if (seria.GetIsDrawing())
                {
                    DLR[DLR.Count - 1].visible = seria.GetIsDrawing();
                }
                PointTypes ptype = seria.GetPtype();
                DLR[DLR.Count - 1].col = seriesProperty[ptype];
                DLR[DLR.Count - 1].headerText = seria.GetLegendText();             
            }
            return DLR;
        }
        private void CustomChart_Load(object sender, EventArgs e)//при загрузке элемента
        {
            reDrawPictureBox();
            try
            {
                setDeleniyaOSsText(0, DataOfDiag.totalMinutes, 0, DataOfDiag.totalRadiation);//добавление осей в массив
                drawDeleniyaOSsText();
            }
            catch { }//отрисовка описание делений по осям   
        }
        private void panelDiagramma_MouseDown(object sender, MouseEventArgs e)//метод обработки рамки выделения при нажатии на мышь
        {          
            is_m_down = true;
            if(isRamka == true)
            {
                bitmapOfSeries1.Hide();
                bitmapOfSeries1.setRamkaClear();
                bitmapOfSeries1.clearRectangle();
                bitmapOfSeries1.Show();
            }        
            //mdown = new Point(e.X + DataOfDiag.innerMarginLeft, e.Y + DataOfDiag.innerMarginTop);
            mdown = new Point(e.X, e.Y);
            buttonUvelichit.Visible = false;
            isRamka = false;
            timerForScreen.Enabled = true;
            
        }
        private void panelDiagramma_MouseMove(object sender, MouseEventArgs e)//метод обработки рамки выделения при нажатии и движении мышью
        {
            if (!is_m_still_down) return;
            //Point mMove = new Point(e.X + DataOfDiag.innerMarginLeft, e.Y + DataOfDiag.innerMarginTop);
            Point mMove = new Point(e.X, e.Y);
            rect = new Rectangle(Math.Min(mdown.X, mMove.X), Math.Min(mdown.Y, mMove.Y), Math.Abs(mdown.X - mMove.X), Math.Abs(mdown.Y - mMove.Y));
            if (rect.Width == 0 || rect.Height == 0) return;
            using (Graphics p = bitmapOfSeries1.CreateGraphics())
            {               
                Bitmap btmp = new Bitmap(rect.Width, rect.Height);
                setRamkaVidelenie(rect);
            }           
        }
        private void bitmapOfSeries1_MouseUp(object sender, MouseEventArgs e)//метод обработки рамки выделения при отжатии кнопки мыши
        {           
            is_m_down = false;
            is_m_still_down = false;
            if(isRamka == true)
            {
                buttonUvelichit.Location = new Point(rect.Width + 10 + rect.Location.X + DataOfDiag.innerMarginLeft, rect.Location.Y + DataOfDiag.innerMarginTop);
                buttonUvelichit.Visible = true;
                bitmapOfSeries1.mouseUp();
                bitmapOfSeries1.drawRectangle(rect);               
                bitmapOfSeries1.setRamkaClear();               
            }
            else
            {
                buttonUvelichit.Visible = false;
            }
        }
        private void timerForScreen_Tick(object sender, EventArgs e)//таймер
        {            
            if(is_m_down == true)
            {
                is_m_still_down = true;               
            }
            else
            {
                is_m_still_down = false;
            }
            timerForScreen.Enabled = false;
        }
        public void setRamkaClear()//очистка рамки
        {
            if(isRamka == true)
            {
                buttonUvelichit.Visible = false;                
                isRamka = false;   
            }
        }
        public void setRamkaVidelenie(Rectangle rect)//отрисовка рамки выделения
        {
            isRamka = true;
            bitmapOfSeries1.setRamkaVidelenie(rect);
        }
        private void buttonUvelichit_Click(object sender, EventArgs e)//обработка кнопки "Увеличить"
        {
            bitmapOfSeries1.Hide();
            buttonCancelUvelechenie.Visible = true;
            setRamkaClear();
            bitmapOfSeries1.clearRectangle();
            int nachTime = (int)((float)(rect.Location.X - startCoordinates.X) / (float)minute2pixelUvel);        
            int endTime = (int)((float)(rect.Location.X + rect.Width - startCoordinates.X) / (float)minute2pixelUvel);
            int endRad = (int)((float)(lineSizeY - rect.Location.Y  + DataOfDiag.innerMarginTop ) / (float)Radiation2pixelUvel);
            int nachRad = (int)((float)(lineSizeY - rect.Location.Y + DataOfDiag.innerMarginTop - rect.Height)/(float)Radiation2pixelUvel);
            try
            {
                setDeleniyaOSsText(nachTime, endTime, nachRad, endRad);//добавление осей в массив
                drawDeleniyaOSsText();

            }
            catch { }//отрисовка описание делений по осям   
            minute2pixelUvel = (float)lineSizeX /(endTime - nachTime);
            Radiation2pixelUvel = (float)lineSizeX /(endRad - nachRad);            
            bitmapOfSeries1.setSettings(nachTime, (endTime - nachTime) + "", nachRad, (endRad - nachRad) + "", DataOfDiag.isLinesOfSer, DataOfDiag.isPointsOfSer, DataOfDiag.radius);
            try
            {
                bitmapOfSeries1.setDataSource(DtForSeries, isDataSourceSeries);
            }
            catch
            {
            }            
            bitmapOfSeries1.Show();
        }
        private void buttonCancelUvelechenie_Click(object sender, EventArgs e)//метод обработки отмены увелечения
        {
            bitmapOfSeries1.Hide();
            buttonCancelUvelechenie.Visible = false;
            minute2pixelUvel = minute2pixel;
            Radiation2pixelUvel = Radiation2pixel;
            try
            {
                setDeleniyaOSsText(0, DataOfDiag.totalMinutes, 0, DataOfDiag.totalRadiation);//добавление осей в массив
                drawDeleniyaOSsText();
            }
            catch { }//отрисовка описание делений по осям           
            bitmapOfSeries1.setSettings(0, DataOfDiag.totalMinutes + "", 0, DataOfDiag.totalRadiation + "", DataOfDiag.isLinesOfSer, DataOfDiag.isPointsOfSer, DataOfDiag.radius);
            try
            {
                bitmapOfSeries1.setDataSource(DtForSeriesReturn, isDataSourceSeries);
            }
            catch
            {
            }          
            bitmapOfSeries1.Show();
        }
    }
}
