using System;
using System.Collections.Generic;

namespace AnalisisNumerico2025Poggi.Regresion
{
    public class ResultadoRegresion
    {
        public double[] Coeficientes { get; set; }          // a0..ak en orden creciente (a0 + a1 x + a2 x^2 + ...)
        public string Funcion { get; set; }                 // "y = ..."
        public double R { get; set; }                       // porcentaje 0..100
        public double ST { get; set; }                      // suma de cuadrados respecto al promedio
        public double SR { get; set; }                      // suma de cuadrados de residuos respecto al modelo
        public double ECM { get; set; }                     // Error cuadrático medio = SR / n
        public int Grado { get; set; }                      // 1 para lineal; k para polinomial
        public List<string> Advertencias { get; set; }      // mensajes para la UI (no bloqueantes)

        public ResultadoRegresion()
        {
            Advertencias = new List<string>();
        }
    }
}