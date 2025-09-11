using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.SistemasEcuaciones
{
    public static class Ecuaciones
    {
        public static ResultadoSistema ResolverGaussJordan(double[,] matriz)
        {
            return GaussJordan.Resolver(matriz);
        }

        public static ResultadoSistema ResolverGaussSeidel(double[,] matriz, double tolerancia = 0.001, int maxIteraciones = 1000)
        {
            return GaussSeidel.Resolver(matriz, tolerancia, maxIteraciones);
        }
    }
}
