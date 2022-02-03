using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubiectExamen
{
    
    class Comanda
    {

        private int id;
        private int cantitate;
        private float pret;

        

        public Comanda( int id, int cantitate, float pret)
        {
            this.id = id;
            this.cantitate = cantitate;
            this.pret = pret;
        }

        public int Id { get => id; }
        public int Cantitate { get => cantitate; set => cantitate = value; }
        public float Pret { get => pret; set => pret = value; }
    }
}
