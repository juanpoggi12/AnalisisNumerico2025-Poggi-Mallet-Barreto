using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public class TestSistemas
    {
        public static void Probar()
        {
            double[,] matriz = new double[,]
            {
                 { 1, 1, 1,   6 },
    { 0, 2, 5,  -4 },
    { 2, 5, -1, 27 }

            };

            Console.WriteLine("Probando Gauss-Jordan:");
            var resultadoJordan = Ecuaciones.ResolverGaussJordan(matriz);
            MostrarResultado(resultadoJordan);

            Console.WriteLine("\nProbando Gauss-Seidel:");
            var resultadoSeidel = Ecuaciones.ResolverGaussSeidel(matriz);
            MostrarResultado(resultadoSeidel);
        }

        private static void MostrarResultado(ResultadoSistema resultado)
        {
            Console.WriteLine("Solución:");
            for (int i = 0; i < resultado.Solucion.Length; i++)
                Console.WriteLine($"x{i + 1} = {Math.Round(resultado.Solucion[i], 4)}");

            Console.WriteLine("\nMatriz final:");
            if (resultado.MatrizReducida != null)
            {
                int filas = resultado.MatrizReducida.GetLength(0);
                int columnas = resultado.MatrizReducida.GetLength(1);
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                        Console.Write($"{Math.Round(resultado.MatrizReducida[i, j], 4)}\t");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No aplica matriz reducida (Gauss-Seidel).");
            }
        }
    }
}
