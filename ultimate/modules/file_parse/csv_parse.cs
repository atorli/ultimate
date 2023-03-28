using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace project_a.modules.file_parse
{
    internal static class csv_parse
    {
        
        public static DataTable parse(string file_path)
        {
            DataTable dt = new DataTable();
            
            DataColumn col1 = new DataColumn();
            col1.DataType = typeof(string);
            col1.ColumnName = "item_address";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.DataType = typeof(string);
            col2.ColumnName = "desc";
            dt.Columns.Add(col2);

            string[]? lines = File.ReadAllLines(file_path);

            if(lines is not null && lines.Length > 0)
            {
                foreach(string line in lines)
                {
                    DataRow row = dt.NewRow();
                    string[] items = line.Split(',');

                    if(items.Length >= 2 ) 
                    {
                        row[0] = items[0];
                        row[1] = items[1];
                        dt.Rows.Add(row);
                    }
                }
            }

            return dt;
        }


    }
}
