using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi
{
    public class Resultado
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public double Raiz { get; set; }
        public List<Datos> Iteraciones { get; set; } = new List<Datos>();

        public Resultado() { }

        public Resultado(bool success, string message)
        {
            Success = success;
            Message = message;
            Iteraciones = new List<Datos>();
        }
    }
}
