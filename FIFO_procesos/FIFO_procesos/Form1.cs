using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFO_procesos
{
    public partial class Form1 : Form
    {
        static Random aleatorio = new Random();
        Procesador proceso = new Procesador();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            int contadorVacio = 0;
            int contadorProcesoCompletos = 0;
            int contadorProcesosLlegaron = 0;

            for(int i = 1; i < 300; i++)
            {
                if(aleatorio.Next(1,101) <= 35)
                {
                    Proceso nuevo = new Proceso();
                    proceso.Enqueue(nuevo);
                    contadorProcesosLlegaron++;
                }
                Proceso vProceso = proceso.Peek();

                if (vProceso != null)
                {
                    vProceso.ciclos--;

                    if (vProceso.ciclos == 0)
                    {
                        proceso.Dequeue();
                        contadorProcesoCompletos++;
                    }
                }
                else
                {
                    contadorVacio++;
                }
            }

            txtProcesos.Text = "Ciclos que estuvo vacío: " + contadorVacio.ToString() + Environment.NewLine + proceso.ProcesosPendientes() + Environment.NewLine +
                                "Procesos completos: " + contadorProcesoCompletos.ToString() + Environment.NewLine +
                                "Procesos que llegaron: " + contadorProcesosLlegaron.ToString() + Environment.NewLine;

        }
    }
}
