using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public static class GaussJordan
    {
        public static ResultadoSistema Resolver(double[,] matriz)
        {
            int n = matriz.GetLength(0);
            int m = matriz.GetLength(1);
            if (m != n + 1)
                throw new ArgumentException(
                    $"La matriz debe tener {n} columnas de coeficientes más 1 de términos independientes (total {n + 1}), " +
                    $"pero tiene {m} columnas.");

            var resultado = new ResultadoSistema();

            // Clonar para no modificar la original
            double[,] A = (double[,])matriz.Clone();

            for (int i = 0; i < n; i++)
            {
                // 1) Pivoteo parcial: buscar la fila con mayor |A[k,i]|, k >= i
                int filaMax = i;
                double maxVal = Math.Abs(A[i, i]);
                for (int k = i + 1; k < n; k++)
                {
                    double val = Math.Abs(A[k, i]);
                    if (val > maxVal)
                    {
                        maxVal = val;
                        filaMax = k;
                    }
                }

                if (maxVal == 0)
                    throw new Exception(
                        $"Columna {i} es cero en todas las filas a partir de la fila {i}. El sistema no tiene solución única.");

                if (filaMax != i)
                {
                    SwapRows(A, i, filaMax);
                    resultado.Pasos.Add((double[,])A.Clone());
                }

                // 2) Normalizar la fila pivote
                double pivote = A[i, i];
                for (int j = 0; j < m; j++)
                    A[i, j] /= pivote;

                resultado.Pasos.Add((double[,])A.Clone());

                // 3) Hacer ceros en la columna i para todas las filas k != i
                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;
                    double factor = A[k, i];
                    for (int j = 0; j < m; j++)
                        A[k, j] -= factor * A[i, j];
                }

                resultado.Pasos.Add((double[,])A.Clone());
            }

            // 4) Extraer solución
            double[] solucion = new double[n];
            for (int i = 0; i < n; i++)
                solucion[i] = A[i, m - 1];

            resultado.Solucion = solucion;
            resultado.MatrizReducida = A;
            return resultado;
        }

        private static void SwapRows(double[,] A, int row1, int row2)
        {
            int columnas = A.GetLength(1);
            for (int j = 0; j < columnas; j++)
            {
                double temp = A[row1, j];
                A[row1, j] = A[row2, j];
                A[row2, j] = temp;
            }
        }
    }
}
