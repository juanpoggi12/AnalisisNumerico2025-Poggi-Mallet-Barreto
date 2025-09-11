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
            int n = matriz.GetLength(0); // Cantidad de ecuaciones
            int m = matriz.GetLength(1); // Cantidad de columnas (n+1)
            var resultado = new ResultadoSistema();

            // Clonamos la matriz para no modificar la original
            double[,] A = (double[,])matriz.Clone();

            // Paso 1: Recorrer cada fila (pivote)
            for (int i = 0; i < n; i++)
            {
                double pivote = A[i, i];

                if (pivote == 0)
                    throw new Exception($"Pivote cero en fila {i}. El sistema no se puede resolver con este método sin pivoteo.");

                // Normalizar la fila del pivote
                for (int k = 0; k < m; k++)
                    A[i, k] = A[i, k] / pivote;

                // Hacer ceros en la columna del pivote para las demás filas
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        double factor = A[j, i];
                        for (int k = 0; k < m; k++)
                            A[j, k] = A[j, k] - factor * A[i, k];
                    }
                }

                // Guardar el estado actual de la matriz
                resultado.Pasos.Add((double[,])A.Clone());
            }

            // Paso 2: Extraer soluciones
            double[] solucion = new double[n];
            for (int i = 0; i < n; i++)
                solucion[i] = A[i, m - 1];

            resultado.Solucion = solucion;
            resultado.MatrizReducida = A;

            return resultado;
        }
    }
}
