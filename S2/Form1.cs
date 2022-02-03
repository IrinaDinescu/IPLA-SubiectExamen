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
    public partial class Form1 : Form
    {
        ErrorProvider er = new ErrorProvider();
        Comanda comanda;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comanda = new Comanda(1, 3, 270.05f);

            this.textBox1.Text = comanda.Id.ToString();
            this.textBox2.Text = comanda.Cantitate.ToString();
            this.textBox3.Text = comanda.Pret.ToString();

            Form2 form2 = new Form2(comanda);
            form2.Show();
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                er.SetError(textBox2, "Spatiul nu poate fi gol");

            }
            else if (textBox2.Text == "")
            {
                er.SetError(textBox3, "Spatiu nu poate fi gol");
            }
            else
            {
                try
                {
                    comanda.Cantitate = Convert.ToInt32(this.textBox2.Text);
                    comanda.Pret = float.Parse(this.textBox3.Text);

                }
                catch
                {
                    MessageBox.Show("Revizuiti datele introduse!");
                }
                finally
                {

                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
