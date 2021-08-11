using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace POS_HealthyRoasters
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(){}

        public void CreateNewFile(string name)
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = wb.Worksheets[1];
            this.ws.Name = name;
        }

        public void WriteToCellHeader(int i, string s)
        {
            ws.Cells[1, i].Value2 = s;
        }

        public void WriteToCell(int i, int j, string s)
        {
            ws.Cells[i + 2, j + 1].Value2 = s;
        }

        public void SaveAs(string path)
        {
            excel.DisplayAlerts = false;
            ws.Protect("dmasdn8ndasunyu12unsuadvty2b1ib9d");
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }
    }
}
