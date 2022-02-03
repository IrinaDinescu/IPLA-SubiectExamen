using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SubExamen2021
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;
            Worksheet currentSheet = Globals.ThisAddIn.Application.ActiveSheet;

            currentSheet.Cells[1, 5].Formula = "=Sum(" + selection.Address + ")";
            currentSheet.Cells[1, 6].Formula = "=AVERAGE(" + selection.Address + ")";
         

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            var formular = new Form1();
            formular.Show();
        }
    }
}
