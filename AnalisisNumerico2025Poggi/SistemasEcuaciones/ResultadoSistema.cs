using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public class ResultadoSistema
    {
        public double[] Solucion { get; set; }
        public double[,] MatrizReducida { get; set; }
        public List<double[,]> Pasos { get; set; } = new List<double[,]>();
        public List<string> Advertencias { get; set; } // warning-level messages

        public ResultadoSistema()
        {
            Pasos = new List<double[,]>();
            Advertencias = new List<string>();
        }

    }
}
