using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubiectExamen_EX2
{
    public partial class Form2 : Form
    {
        Comanda comanda;
        public Form2(Comanda _comanda)
        {
            comanda = (Comanda)_comanda;
            InitializeComponent();

            float valoare = comanda.Cantitate * comanda.Pret;
            this.textBox2.Text = valoare.ToString();

            this.textBox1.Text = comanda.ToString();
            this.textBox1.AppendText(Environment.NewLine);

            //subscriere la eveniment
            /*comanda.atributActualizat += new Comanda.actualizareAtributHandler(this.functie_pe_eveniment);
            comanda.atributActualizat += new Comanda.actualizareAtributHandler(this.functie_pe_eveniment_actualizeaza_valoare);*/

            comanda.atributActualizat += this.functie_pe_eveniment;
            comanda.atributActualizat += this.functie_pe_eveniment_actualizeaza_valoare;

        }

        public void functie_pe_eveniment(Comanda c, EventArgs args)
        {
            this.textBox1.Text += c.ToString();
            this.textBox1.AppendText(Environment.NewLine);

        }

        public void functie_pe_eveniment_actualizeaza_valoare(Comanda c, EventArgs arg)
        {
            float valoare = c.Cantitate * c.Pret;
            this.textBox2.Text = valoare.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
