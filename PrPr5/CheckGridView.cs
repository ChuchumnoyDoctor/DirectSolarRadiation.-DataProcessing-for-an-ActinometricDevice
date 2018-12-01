using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrPr5
{
    public partial class CheckGridView : UserControl
    {
        public delegate void onSaveAndExit(DataEventKolvoCheck e);
        public event onSaveAndExit OnSaveAndExit;
        public CheckGridView()//пользовательский элемент с табличной частью
        {
            InitializeComponent();
        }
        public List<KeyValuePair<object, DataGridViewColumn>> headerCheck { get; set; } = new List<KeyValuePair<object, DataGridViewColumn>>();//список из ключа и столбца
        int kolvo;
        private void CheckGridView_Resize(object sender, EventArgs e)//срабатывает при изменении размера
        {
            dataGridView1.Size = new Size(this.Width, this.Height - checkedListBox1.Height);
            dataGridView1.Location = new Point(0, checkedListBox1.Height);
        }
        public void clear()//метод очистки
        {
            checkedListBox1.Items.Clear();
            dataGridView1.Columns.Clear();
        }
        public void fiilData(DataTable data)//заполнение табличной части
        {  
            for (int i = 0; i < data.Columns.Count; i++)
            {
                dataGridView1.Columns.Add(makeColumn(data.Columns[i].ColumnName));
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }         
            dataGridView1.DataSource = data;
            shetCheck();
        }
        public DataGridViewTextBoxColumn makeColumn(string header)//создание столбца
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = header;
            col.HeaderText = header;            
            checkedListBox1.Items.Add(header, true);
            headerCheck.Add(new KeyValuePair<object, DataGridViewColumn>(checkedListBox1.Items[checkedListBox1.Items.Count-1], col));
            col.DataPropertyName = header;
            return col;
        }
        public void shetCheck()//счет "включенных" столбцов
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns) col.Visible = false;
            kolvo = 0;
            foreach (int item in checkedListBox1.CheckedIndices)
            {
                dataGridView1.Columns[item].Visible = true;
                kolvo++;
            }
            DataEventKolvoCheck args = new DataEventKolvoCheck();
            args.kolvoCheck = kolvo;
            OnSaveAndExit.Invoke(args);
        }
        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)//когда изменяется значение чекбокса
        {
            shetCheck();
        }
        public int getKolvoCheck()// получить кол-во включенных чекбоксов
        {
            return kolvo;
        }
        public DataTable returnTable()//возвращение таблицы из табличной части
        {        
            DataTable dt;
            DataGridView dgv = dataGridView1;
            dt = DataGridView2DataTable(dgv);// Взята таблица на основе гридвью           
            {    
                for(int i=0; i< dgv.Columns.Count;i++)//перебор столбцов гридвью                
                {
                    if (!dgv.Columns[i].Visible)//проверка столбца на скрытие
                    {                        
                        dt.Columns.Remove(dgv.Columns[i].Name);//удаление столбцов из таблицы по имени в гридвью
                    }
                }
            }      
            return dt;            
        }
        public DataTable DataGridView2DataTable(DataGridView dgv, int minRow = 0)//Simply Use this Function For Conversion it would return Datatble
        {
            DataTable dt = new DataTable();
            // Header columns
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dt.Columns.Add(dc);
            }
            // Data cells
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            // Related to the bug arround min size when using ExcelLibrary for export
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = " ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void CheckGridView_Resize_1(object sender, EventArgs e)//при изменении размера
        {
            dataGridView1.Height = this.Height - checkedListBox1.Height;
        }
    }
    public class DataEventKolvoCheck : EventArgs // аргумент
    {
        public int kolvoCheck { get; set; }      
    }
}
