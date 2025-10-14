using System;
using System.Collections.Generic;
using System.Linq;
using AnalisisNumerico2025Poggi.SistemasEcuaciones;

namespace AnalisisNumerico2025Poggi.Regresion
{
    public static class RegresionPolinomial
    {
        // puntos: List<double[]> donde punto[0] = x, punto[1] = y
        // grado: k (2..10)
        // tolerancia: 0.8 => 80%
        public static ResultadoRegresion Calcular(List<double[]> puntos, int grado, double tolerancia = 0.8, int decimales = 4)
        {
            if (puntos == null || puntos.Count < grado + 1)
                throw new ArgumentException($"Se requieren al menos {grado + 1} puntos para un polinomio de grado {grado}.");

            if (grado < 1 || grado > 10)
                throw new ArgumentOutOfRangeException(nameof(grado), "El grado debe estar entre 1 y 10.");

            int n = puntos.Count;
            int dimension = grado + 1;
            double[,] matriz = new double[dimension, dimension + 1];

            // Construir matriz aumentada: A[i,j] = Σ x^(i+j) ; b[i] = Σ y · x^i
            foreach (var p in puntos)
            {
                double x = p[0], y = p[1];
                for (int fila = 0; fila < dimension; fila++)
                {
                    for (int col = 0; col < dimension; col++)
                        matriz[fila, col] += Math.Pow(x, fila + col);

                    matriz[fila, dimension] += y * Math.Pow(x, fila);
                }
            }

            // Resolver por Gauss-Jordan (tu implementación)
            var resSis = GaussJordan.Resolver(matriz);
            double[] coef = (double[])resSis.Solucion.Clone(); // a0..ak

            // Calcular ST y SR
            double promY = puntos.Average(p => p[1]);
            double st = 0, sr = 0;

            foreach (var p in puntos)
            {
                double x = p[0], y = p[1];

                // f(x) = Σ ai x^i
                double fx = 0;
                for (int i = 0; i < coef.Length; i++)
                    fx += coef[i] * Math.Pow(x, i);

                st += Math.Pow(y - promY, 2);
                sr += Math.Pow(y - fx, 2);
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

            var resultado = new ResultadoRegresion
            {
                Coeficientes = coef,
                Funcion = FuncionBuilder.Construir(coef, decimales),
                R = Math.Round(r, 4),
                ST = st,
                SR = sr,
                ECM = Math.Round(sr / n, 3),
                Grado = grado
            };

            if (resultado.R < tolerancia * 100)
                resultado.Advertencias.Add($"El ajuste es pobre (R={resultado.R}%). Considere aumentar el grado o revisar outliers.");

            return resultado;
        }
    }
}