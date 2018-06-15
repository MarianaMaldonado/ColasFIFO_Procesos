using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO_procesos
{
    class Proceso
    {
        public int ciclos { get; set; }
        public Proceso siguiente { get; set; }

        static Random aleatorio = new Random();

        public Proceso()
        {
            ciclos = aleatorio.Next(4, 15);

            siguiente = null;
        }
    }
}
