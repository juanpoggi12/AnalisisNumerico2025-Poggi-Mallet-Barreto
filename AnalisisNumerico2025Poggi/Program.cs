using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string funcion = "x^3 - x - 2"; // función con raíz real cerca de x = 1.5
                double xi = 1.5;
                double xd = 2.0;
                double tolerancia = 0.0001;
                int maxIteraciones = 100;

                MetodosAbiertos metodo = new MetodosAbiertos(funcion);

                Console.WriteLine("Método Newton-Raphson:");
                var resultadoNR = metodo.NewtonRaphson(xi, tolerancia, maxIteraciones);
                MostrarResultado(resultadoNR);

                Console.WriteLine("\nMétodo Secante:");
                var resultadoSecante = metodo.Secante(xi, xd, tolerancia, maxIteraciones);
                MostrarResultado(resultadoSecante);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void MostrarResultado(Resultado resultado)
        {
            Console.WriteLine($"Raíz aproximada: {resultado.Raiz}");
            foreach (var paso in resultado.Iteraciones)
            {
                Console.WriteLine($"Iteración {paso.Iteracion}: Xr = {paso.Xr}, Error = {paso.Error}");
            }
        }
    }
}
