using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public class ResultadoSistema
    {
        public double[] Solucion { get; set; }
        public double[,] MatrizReducida { get; set; }
        public List<double[,]> Pasos { get; set; } = new List<double[,]>();
    }
}
