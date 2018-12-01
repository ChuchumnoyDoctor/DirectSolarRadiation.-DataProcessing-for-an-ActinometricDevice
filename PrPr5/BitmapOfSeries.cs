using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static PrPr5.Seria;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PrPr5
{
    public partial class BitmapOfSeries : UserControl
    {
        public delegate void onSaveAndExit(DataEventValueShow e);
        public event onSaveAndExit OnSaveAndExit;
        public BitmapOfSeries()
        {
            InitializeComponent();
            bmp = new Bitmap(this.Width, this.Height);//новая битмапа
            g = Graphics.FromImage(bmp);//изображение к ней     
            bmpp = new Bitmap(this.Width, this.Height);//новая битмапа
            p = Graphics.FromImage(bmpp);//изображение к ней        
            this.BackColor = Color.Transparent;//прозрачный цвет
            this.Controls.Add(dr1 = new DrawRamka());//добавляем контрол рамки
            dr1.Hide();// и прячем её
        }
        DataRow bufBufRow;
        List<Seria> series;
        Bitmap bmp;
        Graphics g;
        Bitmap bmpp;
        Graphics p;
        DrawRamka dr1;
        List<PointCoorGrValue> fpoint = new List<PointCoorGrValue>();
        public int Radius { get; set; }
        public int diapazon { get; set; }
        public string StartIzmer { get { return startIzmer; } set { startIzmer = value; } }// Начало времени измерения
        public string EndIzmer { get { return endIzmer; } set { endIzmer = value; } }  // Конец времени измерения
        public string StepIzmer { get { return stepIzmer; } set { stepIzmer = value; } } // шаг/интервал измерения
        public bool isDS { get; set; } //источник данных
        bool issLines = true;
        bool issPoints = true;
        int nachaloTime;
        int nachaloRad;
        string startIzmer;//начало измер    
        string endIzmer;//конец измер
        string stepIzmer;//интервал измер
        Point startCoordinates;//начало координат
        float minute2pixel;//коэфициент перевода из минут в пиксели 
        float Radiation2pixel;//коэфициент перевода из радиации в пиксели     
        private int totalMinutes;
        private int totalRadiation;
        DataTable dataTable;
        int ValueStep;
        List<Seria> bufSeries;
        public List<Seria> getSeriesFromDiagramma()//получить графики из диаграммы
        {
            return series;
        }
        public void setSeriesFromDiagramma(List<Seria> s) // отправить диаграмме графики
        {
            series = s;
        }
        public void setDataSource(DataTable dt, bool isDataSourceSeries) // отправить источник данных
        {
            bitmapClear();
            dataTable = new DataTable();
            dataTable = dt;
            isDS = isDataSourceSeries;
            if (isDS == true)
            {
                ValueStep = int.Parse(StepIzmer);
            }
            else
            {
                ValueStep = int.Parse(StepIzmer);
            }
            series = convertDT2List(dataTable);
            reDrawPictureBox();
            reDraw();
        }
        public void bitmapClear()//чистка битмапы
        {
            this.Controls.Clear();
            foreach (PointCoorGrValue fp in fpoint)
            {
                this.Controls.Remove(fp);
            }
            this.Controls.Add(dr1 = new DrawRamka());
            dr1.Hide();
        }
        public void reDrawGraphics()//перерисовка графиков
        {
            foreach (Seria seria in series)
            {
                if (seria == series[series.Count - 1])
                { continue; }
                else
                {
                    if (!seria.GetIsDrawing())
                    {
                        seria.points.ForEach(t => t.Hide());
                        continue;
                    }
                    PointTypes ptype = seria.GetPtype();                    
                    seria.points.ForEach(t => t.show());
                    List<Point> convertedPts = seria.points.ConvertAll<Point>(t => t.pointScreen);
                    if(issLines)
                    g.DrawCurve(new Pen(seriesProperty[ptype], 2f), convertedPts.ToArray());
                }     
            }
            reDrawSSeria();
        }
        public void reDrawSSeria()//перерисовка последнего графика S
        {
            Seria sSeria = series[series.Count - 1];
            if (!sSeria.GetIsDrawing())
            {
                sSeria.points.ForEach(t => t.Hide());                
            }
            PointTypes ptype = sSeria.GetPtype();          
            sSeria.points.ForEach(t => t.show());
            List<Point> convertedPts = sSeria.points.ConvertAll<Point>(t => t.pointScreen);
        }
        private void BitmapOfSeries_Paint(object sender, PaintEventArgs e)//создание графики
        {
            e.Graphics.DrawImageUnscaled(bmp, Point.Empty);
            e.Graphics.DrawImageUnscaled(bmpp, Point.Empty);
        }
        public Point transormToScreenCoordinate(Point p)//перевод точки из датасорс в экранные координаты
        {
            Point realPoint = new Point(startCoordinates.X + (int)(p.X * minute2pixel), (int)((startCoordinates.Y - (int)(p.Y * Radiation2pixel))));
            return realPoint;
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
        public void pointMouseClick(object sender, EventArgs e)//кликабельная кнопка
        {
            PointCoorGrValue point = (PointCoorGrValue)sender;
            DataEventValueShow args = new DataEventValueShow();
            args.x = point.realPoint.Key;
            args.y = point.realPoint.Value;
            args.locx = point.Location.X;
            args.locy = point.Location.Y;
            string legText = "";
            foreach(Seria s in bufSeries)
            {
                foreach(PointCoorGrValue ss in s.points)
                {
                    if(ss == point)
                    { legText =  s.GetLegendText();}
                }    
            }
            args.legendText = legText;
            OnSaveAndExit.Invoke(args);          
        }      
        public List<Seria> convertDT2List(DataTable dt)//конверт из таблицы в лист
        {
            DataTable DT = new DataTable();

            DT = dt;
            bufSeries = new List<Seria>();
            fpoint = new List<PointCoorGrValue>();
            DataTable bufDT = DT;
            DataTable bufBufDT = new DataTable();
            for (int i = 0; i < bufDT.Columns.Count; i++)
            {
                string clName = bufDT.Columns[i].ColumnName;
                bufBufDT.Columns.Add(clName);
            }
            bufBufRow = bufBufDT.NewRow();
            int colvoColumns;
            colvoColumns = bufDT.Columns.Count;
            /*
            for (int i = 0; i < bufDT.Rows.Count; i++)
            {
                DataRow dR = (bufDT.Rows[i]);
                string bufTime = dR[0].ToString();
                if (bufTime == "")
                {
                    bufTime = "0";
                }
                int intBufTime;
                try
                {
                    intBufTime = parseStringTime(bufTime);
                }
                catch
                {
                    intBufTime = int.Parse(bufTime);
                }
                if (intBufTime < nachaloTime)
                {                   
                }
                else
                {
                    bufBufRow[0] = bufTime;
                    if (intBufTime > totalMinutes + nachaloTime)
                    {                        
                    }
                    else
                    {
                        for (int ii = 1; ii < colvoColumns; ii++)
                        {
                            string bufRad = dR[ii].ToString();
                            if (bufRad == "")
                            {
                                bufRad = "0";
                            }
                            if (float.Parse(bufRad) < nachaloRad)
                            {
                                bufBufRow[ii] = nachaloRad;
                            }
                            else
                            {
                                if (float.Parse(bufRad) > totalRadiation + nachaloRad)
                                {
                                    bufBufRow[ii] = totalRadiation + nachaloRad;
                                }
                                else
                                {
                                    bufBufRow[ii] = dR[ii];
                                }
                            }                            
                        }
                    }
                }
                bufBufDT.Rows.Add(bufBufRow);
            }
            */
            /*for (int i = 0; i < DT.Columns.Count - 1; i++)
            {
                fpoint = new List<PointCoorGrValue>();
                bufSeries.Add(new Seria() { });
                for (int j = 0; j < DT.Rows.Count - ValueStep; j = j + ValueStep)
                {
                    int z = 0;
                    int end = 0;
                    if (diapazon>j)
                    {
                        z = j;
                        end = j + diapazon;
                    }
                    else
                    {
                        if (diapazon > DT.Rows.Count - ValueStep - j)
                        {
                            z = j-diapazon;
                            end =j;
                        }
                        else
                        {
                            z = j - diapazon;
                            end = j + diapazon;
                        }
                    }
                    for (int y = z; y < end; y++)
                    {*/
            if (isDS == false)//тип источника данных
            {
                issLines = false;
                issPoints = true;
            }
            this.Hide();
            for (int i = 0; i < DT.Columns.Count - 1; i++)//раскидываем тейбл на графики
            {
                fpoint = new List<PointCoorGrValue>();
                bufSeries.Add(new Seria() { });
                for (int uu = 0; uu < DT.Rows.Count - ValueStep; uu += ValueStep)
                {
                    for (int u = uu + diapazon; u < uu - diapazon + ValueStep; u++)
                    {
                        if (u == uu + diapazon)
                        {
                            int CoordinatePointY = 0;//буффер
                            int MaximumValue;
                            try { MaximumValue = (int)float.Parse((DT.Rows[u][1].ToString())); }
                            catch
                            {
                                MaximumValue = 0;
                            }
                            int MinimumValue;
                            try { MinimumValue = (int)float.Parse((DT.Rows[u][1].ToString())); }
                            catch
                            {
                                MinimumValue = 0;
                            }                          
                            int z = 0;
                            int end = 0;
                            if (diapazon > uu)
                            {
                                z = uu;
                                end = uu + diapazon;
                            }
                            else
                            {
                                if (diapazon > DT.Rows.Count - ValueStep - uu)
                                {
                                    z = uu - diapazon;
                                    end = uu;
                                }
                                else
                                {
                                    z = uu - diapazon;
                                    end = uu + diapazon;
                                }
                            }
                            for (int y = z; y < end; y++)
                            {
                                CoordinatePointY = 0;
                                //Коор У
                                try
                                {
                                    CoordinatePointY = (int)float.Parse((DT.Rows[y][i + 1].ToString()));
                                }
                                catch
                                {
                                    CoordinatePointY = 0;
                                }                               
                                string time = DT.Rows[y][0].ToString();
                                int x = this.parseStringTime(time);
                                //Добавить точку
                                Point vb = new Point(x, CoordinatePointY);
                                PointCoorGrValue p = new PointCoorGrValue(Radius) { pointScreen = transormToScreenCoordinate(vb), realPoint = new KeyValuePair<string, string>(time, CoordinatePointY + ""), pointColor = seriesProperty[(PointTypes)i], visible = issPoints };
                                if (parseStringTime(StartIzmer) < x & x < parseStringTime(EndIzmer))
                                {
                                    this.Controls.Add(p);
                                    p.Click += pointMouseClick;
                                    fpoint.Add(p);
                                }
                            }
                        }
                        else
                        {
                            string time;
                            time = DT.Rows[u][0].ToString();
                            //Коор Х,У Дроу точка
                            //Добавить точку
                            int CoordinatePointY = 0;
                            //Коор У
                            int x = this.parseStringTime(time);
                            try
                            {
                                CoordinatePointY = (int)float.Parse((DT.Rows[u][i + 1].ToString()));
                            }
                            catch
                            {
                                CoordinatePointY = 0;
                            }
                          
                            Point vb = new Point(x, CoordinatePointY);
                            PointCoorGrValue p = new PointCoorGrValue(Radius) { pointScreen = transormToScreenCoordinate(vb), realPoint = new KeyValuePair<string, string>(time, ""), pointColor = seriesProperty[(PointTypes)i], visible = false };
                            if (parseStringTime(StartIzmer) < x & x < parseStringTime(EndIzmer))
                            {
                                fpoint.Add(p);
                            }
                        }
                    }
                }
                bufSeries[i].points = fpoint;//массив точек
                bufSeries[i].SetIsDrawing(issLines);// bool отрисовки
                bufSeries[i].SetPtype((PointTypes)i);// тип цвета отрисовки
                bufSeries[i].SetLegendText(DT.Columns[i + 1].ColumnName);//название графика

            }           
            if (isDS == true)//проверка на источник данных
            {
                //список графиков. график S в конце списка
                int IndexRGraphic;//индекс S графика
                IndexRGraphic = (int)DT.Columns.Count - 1;//Порядковый номер последнего S графика
                bufSeries.Add(new Seria() { });//пустой массив точек             
                fpoint = new List<PointCoorGrValue>();
                for (int uu = 0; uu < DT.Rows.Count; uu += ValueStep)
                {
                    for (int u = uu + diapazon; u < uu - diapazon + ValueStep; u++)
                    {
                        if (u == uu + diapazon)
                        {
                            int CoordinatePointY = 0;//буффер                           
                            int z = 0;
                            int end = 0;
                            if (diapazon > uu)
                            {
                                z = uu;
                                end = uu + diapazon;
                            }
                            else
                            {
                                if (diapazon > DT.Rows.Count- uu - ValueStep)
                                {
                                    z = uu - diapazon;
                                    end = DT.Rows.Count-1;
                                }
                                else
                                {
                                    z = uu - diapazon;
                                    end = uu + diapazon;
                                }
                            }
                            int MaximumValue;
                            int MinimumValue;
                            try
                            {
                                MaximumValue = (int)float.Parse((DT.Rows[z][1].ToString()));
                                MinimumValue = (int)float.Parse((DT.Rows[z][1].ToString()));
                            }
                            catch
                            {
                                MaximumValue = 0;
                                MinimumValue = 0;
                            }                          
                            for (int y = z; y < end; y++)
                            {
                                for (int i = 0; i < DT.Columns.Count - 1; i++)
                                {
                                    int max;
                                    try
                                    {
                                        max = (int)float.Parse((DT.Rows[y][i + 1].ToString()));
                                    }
                                    catch
                                    {
                                        max = 0;
                                    }
                                    if (max > MaximumValue)
                                    {
                                        MaximumValue = max;
                                    }
                                    int min;
                                    try
                                    {
                                        min = (int)float.Parse((DT.Rows[y][i + 1].ToString()));
                                    }
                                    catch
                                    {
                                        min = 0;
                                    }
                                    if (min < MinimumValue)
                                    {
                                        MinimumValue = min;
                                    }
                                }
                                CoordinatePointY = Math.Abs(MaximumValue - MinimumValue);
                                string time;
                                int x;
                                time = DT.Rows[y][0].ToString();
                                x = this.parseStringTime(time);
                                //Коор Х,У Дроу точка
                                //Добавить точку
                                Point vb = new Point(x, CoordinatePointY);
                                PointCoorGrValue p = new PointCoorGrValue(Radius) { pointScreen = transormToScreenCoordinate(vb), realPoint = new KeyValuePair<string, string>(time, CoordinatePointY + ""), pointColor = seriesProperty[(PointTypes)IndexRGraphic], visible = true };
                                if (parseStringTime(StartIzmer) < x & x < parseStringTime(EndIzmer))
                                {
                                    this.Controls.Add(p);
                                    p.Click += pointMouseClick;
                                    fpoint.Add(p);
                                }
                                else
                                {
                                    p = new PointCoorGrValue(Radius) { pointScreen = transormToScreenCoordinate(vb), realPoint = new KeyValuePair<string, string>(time, ""), pointColor = seriesProperty[(PointTypes)IndexRGraphic], visible = false };
                                    fpoint.Add(p);
                                }
                            }
                        }
                        else
                        {
                            string time;
                            time = DT.Rows[u][0].ToString();
                            int CoordinatePointY = 0;
                            //Коор У
                            int x = this.parseStringTime(time);
                            Point vb = new Point(x, CoordinatePointY);
                            PointCoorGrValue p = new PointCoorGrValue(Radius) { pointScreen = transormToScreenCoordinate(vb), realPoint = new KeyValuePair<string, string>(time, ""), pointColor = seriesProperty[(PointTypes)IndexRGraphic], visible = false };
                            fpoint.Add(p);
                        }
                    }
                }            
                bufSeries[IndexRGraphic].SetPtype((PointTypes)IndexRGraphic);//тип последнего графика
                bufSeries[IndexRGraphic].points = fpoint;//массив точек
                bufSeries[IndexRGraphic].SetIsDrawing(true);// bool отрисовки
                bufSeries[IndexRGraphic].SetLegendText("S', Вт/м2");//название графика
                if (bufSeries[IndexRGraphic].points.Count < bufSeries[IndexRGraphic - 1].points.Count)
                {                    
                    for (int i = bufSeries[IndexRGraphic].points.Count; i < bufSeries[IndexRGraphic - 1].points.Count; i++)
                    {
                        string time;
                        time = DT.Rows[i][0].ToString();
                        int CoordinatePointY = 0;
                        //Коор У
                        int x = this.parseStringTime(time);
                        Point vb = new Point(x, CoordinatePointY);
                        PointCoorGrValue p = new PointCoorGrValue(5) { pointScreen = transormToScreenCoordinate(vb), realPoint = new KeyValuePair<string, string>(time, ""), pointColor = seriesProperty[(PointTypes)IndexRGraphic], visible = false };
                        fpoint.Add(p);
                    }
                    bufSeries[IndexRGraphic].points = fpoint;
                }
            }
            this.Show();
            return bufSeries;
        }
        public void setSettings(int nMin, string tMin, int nRad, string tRad, bool isLines, bool isPoints, int radiusPoint)
        {
            this.Radius = radiusPoint;//радиус
            totalMinutes = int.Parse(tMin);//максимальное значение по оси Х
            totalRadiation = int.Parse(tRad);//максимальное значение по оси Y
            nachaloTime = nMin;//начало оси времени
            nachaloRad = nRad;//начало оси радиации
            issLines = isLines;//отрисовка линий графиков
            issPoints = isPoints;//отрисовки точек графиков
            minute2pixel = (float)this.Width / totalMinutes;//коэфициент из минут в пиксели
            Radiation2pixel = (float)this.Height / totalRadiation;//коэфициент из радиации в пиксели            
        }
        public void reDrawPictureBox()//переотрисовка основы
        {
            startCoordinates = new Point(0, this.Height);//начало координат  
            bmp = new Bitmap(this.Width, this.Height);//новая битмапа
            g = Graphics.FromImage(bmp);//изображение к ней                          
        }
        public void reDraw()//переотрисовка
        {           
            reDrawGraphics();           
            dr1.BringToFront();         
            this.Invalidate();//обновить            
        }
        public void mouseUp()//вывести кликабельные точки наповерх
        {
            foreach (Control pp in this.Controls)
            {
                if (pp.GetType() == typeof(PointCoorGrValue))
                {
                    pp.BringToFront();
                }
            }
        }
        public void drawRectangle(Rectangle rect)//нарисовать рамку
        {
            clearRectangle();
            p.DrawRectangle(new Pen(Color.Black), rect);
            this.Invalidate();            
        }
        public void clearRectangle()//почистить рамку
        {
            bmpp = new Bitmap(this.Width, this.Height);//новая битмапа
            p = Graphics.FromImage(bmpp);//изображение к ней  
            this.Invalidate();
        }
        public void setRamkaVidelenie(Rectangle rect)// отправить рамку выделения
        {          
            dr1.setRamkaVidelenie(rect);
            dr1.Show();           
        }
        private void BitmapOfSeries_Resize(object sender, EventArgs e)//при изменении битмапы
        {
            reDrawPictureBox();
        }
        public void setRamkaClear()//чистка рекламы
        {            
            dr1.Hide();          
        }
    }   
    public class DataEventValueShow: EventArgs // аргументы для кликабельной точки
    {
        public string legendText { get; set; } // название графика
        public string x { get; set; } //значение х
        public string y { get; set; } //значение у
        public int locx { get; set; } //локейшн х
        public int locy { get; set; } //локейшн у
    }
}
