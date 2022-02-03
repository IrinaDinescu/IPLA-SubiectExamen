using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;

namespace SubiectExamen
{
    public partial class Ribbon1
    {
        private bool isFirst = true;

        public delegate void actualizareIndicator(int indicator_1, float indicator_2);
        public event actualizareIndicator indicatoriActualizati;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btn_B_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;

            if(selection != null)
            {
                object[,] holder = selection.Value;
                int row_count = selection.Rows.Rows.Count;
                int column_count = selection.Columns.Columns.Count;

                int indicator_1 = 0;
                float indicator_2 = 0;

                if(column_count == 3)
                {
                    for(int q = 0; q <row_count; q++)
                    {
                        try
                        {
                            int id = Convert.ToInt32(holder[q + 1, 1]);
                            int cantitate = Convert.ToInt32(holder[q + 1, 2]);
                            float pret = Convert.ToSingle(holder[q + 1, 3]);

                            //indicator 1 = numar total de comenzi
                            indicator_1 += cantitate;

                            //indicator 2  =  valoarea totala
                            indicator_2 += cantitate * pret;
                       
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                    if (isFirst)
                    {
                        isFirst = false;
                        Form1 f1 = new Form1(indicator_1, indicator_2, this);
                        f1.Show();
                    }
                    else
                    {
                        indicatoriActualizati?.Invoke(indicator_1, indicator_2);
                    }

                }
               

            }
        }

        private void btn_A_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Range selection = Globals.ThisAddIn.Application.Selection as Excel.Range;
            Excel.Worksheet currentSheet = Globals.ThisAddIn.Application.ActiveSheet;

            currentSheet.Cells[1, 5].Formula = "=Sum(" + selection.Address + ")";
            currentSheet.Cells[1, 6].Formula = "=AVERAGE(" + selection.Address + ")";
        }
    }
}
