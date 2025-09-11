using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public static class GaussSeidel
    {
        public static ResultadoSistema Resolver(
            double[,] matriz,
            double tolerancia = 0.001,
            int maxIteraciones = 1000)
        {
            int n1 = matriz.GetLength(0);
            int m = matriz.GetLength(1);

            var resultado = new ResultadoSistema();
            if (m != n1 + 1)
                resultado.Advertencias.Add(
                      "La matriz no es diagonalmente dominante; Gauss–Seidel podría no converger.");


            int n = matriz.GetLength(0);

            double[] vectorResultado = new double[n];
            double[] vectorAnterior = new double[n];
            int contador = 0;

            // 1) Validar diagonal dominante
            if (!EsDiagonalmenteDominante(matriz))
                Console.WriteLine("⚠️ Advertencia: La matriz no es diagonalmente dominante. Gauss-Seidel podría no converger.");


            // 2) Iteraciones
            while (contador < maxIteraciones)
            {
                contador++;

                for (int i = 0; i < n; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < n; j++)
                        if (j != i)
                            suma += matriz[i, j] * vectorResultado[j];

                    double pivote = matriz[i, i];
                    if (pivote == 0)
                        throw new Exception(
                            $"Pivote cero en fila {i}. No se puede continuar.");

                    double b = matriz[i, n];
                    vectorResultado[i] = (b - suma) / pivote;

                    for (int k = 0; k < n; k++)
                        if (double.IsNaN(vectorResultado[k]) || double.IsInfinity(vectorResultado[k]))
                            throw new Exception("Gauss-Seidel diverge (NaN o ∞ detectado)");
                }

                // 3) Comprobar convergencia (norma infinita)
                double maxDiferencia = 0;
                for (int i = 0; i < n; i++)
                {
                    double diff = Math.Abs(vectorResultado[i] - vectorAnterior[i]);
                    if (diff > maxDiferencia)
                        maxDiferencia = diff;
                }

                // 4) Guardar estado actual
                double[,] estado = new double[n, n + 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        estado[i, j] = matriz[i, j];
                    estado[i, n] = vectorResultado[i];
                }
                resultado.Pasos.Add(estado);

                if (maxDiferencia < tolerancia)
                    break;

                Array.Copy(vectorResultado, vectorAnterior, n);
            }

            if (contador == maxIteraciones)
                throw new Exception(
                    "Gauss-Seidel no convergió en el número máximo de iteraciones.");

            resultado.Solucion = (double[])vectorResultado.Clone();
            resultado.MatrizReducida = null;
            return resultado;
        }

        private static bool EsDiagonalmenteDominante(double[,] matriz)
        {
            int n = matriz.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                double suma = 0;
                for (int j = 0; j < n; j++)
                    if (j != i)
                        suma += Math.Abs(matriz[i, j]);

                if (Math.Abs(matriz[i, i]) < suma)
                    return false;
            }
            return true;
        }
    }

}
