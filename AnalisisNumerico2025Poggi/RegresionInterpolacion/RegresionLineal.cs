using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalisisNumerico2025Poggi.Regresion
{
    public static class RegresionLineal
    {
        // puntos: List<double[]> donde punto[0] = x, punto[1] = y
        // tolerancia: 0.8 => 80%
        public static ResultadoRegresion Calcular(List<double[]> puntos, double tolerancia = 0.8, int decimales = 4)
        {
            if (puntos == null || puntos.Count < 2)
                throw new ArgumentException("Se requieren al menos 2 puntos para regresión lineal.");

            int n = puntos.Count;
            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

            foreach (var p in puntos)
            {
                double x = p[0], y = p[1];
                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumX2 += x * x;
            }

            double denom = n * sumX2 - Math.Pow(sumX, 2);
            if (denom == 0)
                throw new Exception("Denominador n*ΣX² - (ΣX)² = 0. No se puede calcular pendiente (distribución de puntos degenerada).");

            double a1 = (n * sumXY - sumX * sumY) / denom;
            double a0 = (sumY - a1 * sumX) / n;

            double promY = sumY / n;
            double st = 0, sr = 0;
            foreach (var p in puntos)
            {
                double x = p[0], y = p[1];
                st += Math.Pow(y - promY, 2);
                sr += Math.Pow(y - (a1 * x + a0), 2);
            }

            double r;
            if (st == 0)
            {
                r = 0;
            }
            else
            {
                r = (st - sr) / st * 100.0;
            }

            var coef = new double[] { a0, a1 };
            var resultado = new ResultadoRegresion
            {
                Coeficientes = coef,
                Funcion = FuncionBuilder.Construir(coef, decimales), // y = a1x + a0
                R = Math.Round(r, 2),
                ST = st,
                SR = sr,
                ECM = Math.Round(sr / n, 3),
                Grado = 1
            };

            if (resultado.R < tolerancia * 100)
                resultado.Advertencias.Add($"El ajuste es pobre (R={resultado.R}%). Considere aumentar el grado o revisar outliers.");

            return resultado;
        }
    }
}