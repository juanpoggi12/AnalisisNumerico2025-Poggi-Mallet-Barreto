using System;
using Calculus;

namespace AnalisisNumerico2025Poggi
{
    public enum ClosedMethod { Biseccion, ReglaFalsa }

    public class Solver
    {
        private readonly Calculo calc = new Calculo();

        private void SetFunction(string fx, char var)
        {
            if (!calc.Sintaxis(fx, var))
                throw new ArgumentException("Función inválida para Calculus.dll");
        }

        /// <summary>
        /// Método genérico que implementa el algoritmo de métodos cerrados
        /// (bisección o regla falsa) con corte por |f(xr)| < tol o error relativo
        /// </summary>
        public double Resolver(string fx, char var, double xi, double xd,
                               double tol = 1e-6, int maxIter = 100,
                               ClosedMethod metodo = ClosedMethod.Biseccion)
        {
            SetFunction(fx, var);

            double fxi = calc.EvaluaFx(xi);
            double fxd = calc.EvaluaFx(xd);

            if (fxi * fxd > 0)
                throw new ArgumentException("El intervalo no encierra una raíz (f(xi)*f(xd) > 0)");

            if (Math.Abs(fxi) == 0) return xi;
            if (Math.Abs(fxd) == 0) return xd;

            double xrAnterior = double.NaN;
            double xr = 0;

            for (int i = 1; i <= maxIter; i++)
            {
                xr = CalcularXr(metodo, xi, xd);   // <- acá está el método que faltaba
                double fxr = calc.EvaluaFx(xr);

                double error = double.PositiveInfinity;
                if (!double.IsNaN(xrAnterior) && xr != 0)
                    error = Math.Abs((xr - xrAnterior) / xr);

                if (Math.Abs(fxr) < tol || error < tol)
                    return xr;

                // Actualizar intervalo por cambio de signo
                if (fxi * fxr > 0)
                {
                    xi = xr;
                    fxi = fxr;
                }
                else
                {
                    xd = xr;
                    fxd = fxr;
                }

                xrAnterior = xr;
            }

            // Si agotó iteraciones, devolvemos la mejor aproximación
            return xr;
        }

        /// <summary>
        /// Calcula xr según el método cerrado elegido.
        /// Bisección: (xi + xd)/2
        /// Regla Falsa: (f(xd)*xi - f(xi)*xd)/(f(xd) - f(xi))
        /// </summary>
        private double CalcularXr(ClosedMethod metodo, double xi, double xd)
        {
            switch (metodo)
            {
                case ClosedMethod.Biseccion:
                    return (xi + xd) / 2.0;
                case ClosedMethod.ReglaFalsa:
                    double fxi = calc.EvaluaFx(xi);
                    double fxd = calc.EvaluaFx(xd);
                    return (fxd * xi - fxi * xd) / (fxd - fxi);
                default:
                    throw new ArgumentOutOfRangeException(nameof(metodo));
            }
        }

        // Wrappers “directos” por si querés llamar sin enum:
        public double Biseccion(string fx, char var, double a, double b,
                                double tol = 1e-6, int maxIter = 100)
            => Resolver(fx, var, a, b, tol, maxIter, ClosedMethod.Biseccion);

        public double ReglaFalsa(string fx, char var, double a, double b,
                                 double tol = 1e-6, int maxIter = 100)
            => Resolver(fx, var, a, b, tol, maxIter, ClosedMethod.ReglaFalsa);
    }
}
