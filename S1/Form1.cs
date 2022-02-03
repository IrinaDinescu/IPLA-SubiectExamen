using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubiectExamen
{
    public partial class Form1 : Form
    {
        int indicator_1;
        float indicator_2;
        Ribbon1 r;
        public Form1(int _indicator_1, float _indicator_2, Ribbon1 ribbon)
        {
            InitializeComponent();
            this.indicator_1 = _indicator_1;
            this.indicator_2 = _indicator_2;
            this.r = ribbon;

            this.textBox1.Text = indicator_1.ToString();
            this.textBox2.Text = indicator_2.ToString();


            //subscriere la eveniment
            r.indicatoriActualizati += new Ribbon1.actualizareIndicator(functie_pe_eveniment);
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void functie_pe_eveniment(int i1, float i2)
        {
            this.textBox1.Text = i1.ToString();
            this.textBox2.Text = i2.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
