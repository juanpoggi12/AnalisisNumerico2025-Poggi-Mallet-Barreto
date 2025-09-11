using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public static class GaussSeidel
    {
        public static ResultadoSistema Resolver(double[,] matriz, double tolerancia = 0.001, int maxIteraciones = 1000)
        {
            int n = matriz.GetLength(0); // Cantidad de ecuaciones
            var resultado = new ResultadoSistema();

            double[] vectorResultado = new double[n];
            double[] vectorAnterior = new double[n];

            bool esSolucion = false;
            int contador = 0;

            // Lista para guardar pasos intermedios
            resultado.Pasos = new List<double[,]>();

            while (contador < maxIteraciones && !esSolucion)
            {
                contador++;

                for (int i = 0; i < n; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                            suma += matriz[i, j] * vectorResultado[j];
                    }

                    double coeficienteIncognita = matriz[i, i];
                    double terminoIndependiente = matriz[i, n]; // última columna
                    vectorResultado[i] = (terminoIndependiente - suma) / coeficienteIncognita;
                }

                // Verificar convergencia
                int contadorMismoResultado = 0;
                for (int i = 0; i < n; i++)
                {
                    if (Math.Round(vectorResultado[i], 4) == Math.Round(vectorAnterior[i], 4))
                        contadorMismoResultado++;
                }

                esSolucion = (contadorMismoResultado == n);

                // Guardar copia de la iteración actual
                double[,] estado = new double[n, n + 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        estado[i, j] = matriz[i, j];
                    estado[i, n] = vectorResultado[i]; // reemplazamos columna de resultados por valores actuales
                }
                resultado.Pasos.Add(estado);

                // Actualizar vector anterior
                Array.Copy(vectorResultado, vectorAnterior, n);
            }

            if (!esSolucion)
                throw new Exception("Gauss-Seidel no convergió en el número máximo de iteraciones.");

            resultado.Solucion = (double[])vectorResultado.Clone();
            resultado.MatrizReducida = null; // No aplica matriz reducida como en Gauss-Jordan

            return resultado;
        }
    }
}
