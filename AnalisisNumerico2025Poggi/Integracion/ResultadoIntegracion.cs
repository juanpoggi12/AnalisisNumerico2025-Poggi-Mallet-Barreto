using System.Collections.Generic;

namespace AnalisisNumerico2025Poggi.Integracion
{
    public sealed class ResultadoIntegracion
    {
        public string Metodo { get; set; } = "";
        public string Funcion { get; set; } = "";
        public double Xi { get; set; }
        public double Xd { get; set; }
        public int Subintervalos { get; set; } // n (si aplica)
        public double Resultado { get; set; }
        public List<string> Advertencias { get; set; } = new();
        public string Mensaje { get; set; } = "";
    }
}