using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SubiectExamen_EX2
{
    public class Comanda
    {
        private int id;
        private int cantitate;
        private float pret;

        public delegate void actualizareAtributHandler(Comanda source, EventArgs args);
        public event actualizareAtributHandler atributActualizat;

        public Comanda(int id, int cantitate, float pret)
        {
            this.id = id;
            this.cantitate = cantitate;
            this.pret = pret;
        }

        public int Id { get => id; }
        public int Cantitate { 
            get => cantitate;
            set { if(cantitate!=value){
                    cantitate = value;
                    atributActualizat?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public float Pret { get => pret;
            set
            {
                if (pret != value)
                {
                    pret = value;
                    atributActualizat?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        protected virtual void OnAtributActualizat()
        {
            if(atributActualizat != null)
            {
                atributActualizat(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            float valoare = cantitate * pret;
            return "Comanda: " + Id + " Cantitate: " + Cantitate + " Pret: " + Pret +" Valoare " + valoare ;
        }
    }
}
