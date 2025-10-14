using AnalisisNumerico2025Poggi.Integracion;
using AnalisisNumerico2025Poggi.SistemasEcuaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi
{
    class Program
    {
        static void Main(string[] args)
        {
            TestIntegracion.Probar();
            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Console.ReadKey();
        }
    }
}
