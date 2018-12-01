using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace PrPr5
{
    class ListtoDataTableConverter//конвертер из листа в таблицу
    {
        public DataTable ToDataTable(List<SummRadiation> items)
        {
            DataTable dataTable = new DataTable();
            //Get all the properties            
            foreach (var a in items[0].prikol.Keys)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(a);
            }
            for (int i = 0; i < items.Count; i++) {
                var values = new object[items[i].prikol.Count];
                int j = 0;
                foreach (KeyValuePair<string, string> AS in items[i].prikol) {
                    values[j] = AS.Value;
                    j++;
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
