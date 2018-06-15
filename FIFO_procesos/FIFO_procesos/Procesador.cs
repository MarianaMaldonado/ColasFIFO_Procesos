using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO_procesos
{
    class Procesador
    {
        Proceso inicio, ultimo, temporal;

        public Procesador()
        {
            inicio = null;
            ultimo = null;
        }

        public void Enqueue(Proceso nuevo)
        {
            if(inicio == null)
            {
                inicio = nuevo;
                ultimo = nuevo;
            }
            else
            {
                ultimo.siguiente = nuevo;
                ultimo = nuevo;
            }
        }

        public Proceso Dequeue()
        {
            if (inicio == null)
                return null;
            else
            {
                temporal = inicio;
                inicio = inicio.siguiente;
                return temporal;
            }
            
        }

        public Proceso Peek()
        {
            return inicio;
        }

        public string ProcesosPendientes()
        {
            int procesosPendientes = 0;
            int sumaProcesosPendientes = 0;
            temporal = inicio;

            while(temporal != null)
            {
                sumaProcesosPendientes += temporal.ciclos;
                procesosPendientes++;
                temporal = temporal.siguiente;
            }

            string Pendientes = "Procesos pendientes: " + procesosPendientes.ToString() + Environment.NewLine + "Suma procesos pendientes: " + sumaProcesosPendientes.ToString();

            return Pendientes;
        }
    }
}
