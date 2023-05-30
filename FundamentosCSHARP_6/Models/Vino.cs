using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP_6.Models
{
    internal class Vino : Bebida, IBebidaAlcoholica
    { 
        public int Alcohol { get; set; }

        public void MaxRecomendado()
        {
            Console.WriteLine("El maximo recomendado son 3 copas.");
        }

        public Vino(int Cantidad, string Nombre = "Vino"): base(Nombre, Cantidad)
        {

        }
    }
}
