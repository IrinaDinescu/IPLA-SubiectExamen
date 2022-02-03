using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;

namespace SubExamen2021
{
    public partial class Form1 : Form
        
    {
        Excel.Worksheet currentSheet = null;
        public Form1()
        {
            InitializeComponent();
            if (Globals.ThisAddIn.Application.ActiveSheet != null)
            {
                currentSheet = Globals.ThisAddIn.Application.ActiveSheet;
                currentSheet.SelectionChange += CurrentSheet_SelectionChange;
            }

            Globals.ThisAddIn.Application.SheetActivate += (sh) =>
            {
                currentSheet = sh as Excel.Worksheet;
                currentSheet.SelectionChange += CurrentSheet_SelectionChange;
            };

            Globals.ThisAddIn.Application.SheetDeactivate += (sh) =>
            {
                if (currentSheet != null)
                {
                    currentSheet.SelectionChange -= CurrentSheet_SelectionChange;
                }
            };
        }
        private void CurrentSheet_SelectionChange(Excel.Range range)
        {

            Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;

            currentSheet.Cells[3, 5].Formula = "=Sum(" + selection.Address + ")";
            currentSheet.Cells[3, 6].Formula = "=AVERAGE(" + selection.Address + ")";

            textBox1.Text = currentSheet.Cells[3, 5].Value2 + ",    " + currentSheet.Cells[3, 6].Value2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
