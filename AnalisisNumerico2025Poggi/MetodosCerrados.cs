using System;
using Calculus;

namespace AnalisisNumerico2025Poggi
{
    public enum ClosedMethod { Biseccion, ReglaFalsa }

    public class MetodosCerrados
    {
        private readonly Calculo calc = new Calculo();

        private void SetFunction(string fx, char var)
        {
            if (!calc.Sintaxis(fx, var))
                throw new ArgumentException("Función inválida para Calculus.dll");
        }

        public ResultadoRaiz Resolver(string fx, char var, double xi, double xd,
                                      double tol = 1e-6, int maxIter = 100,
                                      ClosedMethod metodo = ClosedMethod.Biseccion)
        {
            SetFunction(fx, var);

            double fxi = calc.EvaluaFx(xi);
            double fxd = calc.EvaluaFx(xd);

            if (fxi * fxd > 0)
                throw new ArgumentException("El intervalo no encierra una raíz (f(xi)*f(xd) > 0)");

            if (Math.Abs(fxi) == 0)
                return new ResultadoRaiz { Raiz = xi, Iteraciones = 0, Error = 0, Mensaje = "Xi es raíz exacta" };

            if (Math.Abs(fxd) == 0)
                return new ResultadoRaiz { Raiz = xd, Iteraciones = 0, Error = 0, Mensaje = "Xd es raíz exacta" };

            double xrAnterior = double.NaN;
            double xr = 0;
            double error = 1.0; // convención

            for (int i = 1; i <= maxIter; i++)
            {
                xr = CalcularXr(metodo, xi, xd, fxi, fxd);
                double fxr = calc.EvaluaFx(xr);

                // error relativo a partir de la segunda iteración
                if (!double.IsNaN(xrAnterior) && Math.Abs(xr) > 0)
                    error = Math.Abs((xr - xrAnterior) / xr);

                // criterio de parada por función o por error
                if (Math.Abs(fxr) < tol || (!double.IsNaN(xrAnterior) && error < tol))
                {
                    return new ResultadoRaiz
                    {
                        Raiz = xr,
                        Iteraciones = i,
                        Error = (Math.Abs(fxr) < tol) ? 0.0 : error,
                        Mensaje = "Convergió correctamente"
                    };
                }

                // Actualizar intervalo
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

            return new ResultadoRaiz
            {
                Raiz = xr,
                Iteraciones = maxIter,
                Error = error,
                Mensaje = "No convergió: se alcanzó el máximo de iteraciones"
            };
        }

        private double CalcularXr(ClosedMethod metodo, double xi, double xd, double fxi, double fxd)
        {
            switch (metodo)
            {
                case ClosedMethod.Biseccion:
                    return (xi + xd) / 2.0;

                case ClosedMethod.ReglaFalsa:
                    double denom = fxd - fxi;
                    if (Math.Abs(denom) < 1e-14)
                    {
                        // muy plano; volver a punto medio para evitar explosiones numéricas
                        return (xi + xd) / 2.0;
                    }
                    return (fxd * xi - fxi * xd) / denom;

                default:
                    throw new ArgumentOutOfRangeException(nameof(metodo));
            }
        }

        // Wrappers
        public ResultadoRaiz Biseccion(string fx, char var, double a, double b,
                                       double tol = 1e-6, int maxIter = 100)
            => Resolver(fx, var, a, b, tol, maxIter, ClosedMethod.Biseccion);

        public ResultadoRaiz ReglaFalsa(string fx, char var, double a, double b,
                                        double tol = 1e-6, int maxIter = 100)
            => Resolver(fx, var, a, b, tol, maxIter, ClosedMethod.ReglaFalsa);
    }
}
