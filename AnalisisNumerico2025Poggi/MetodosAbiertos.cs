using AnalisisNumerico2025Poggi;
using Calculus;
using System;

public class MetodosAbiertos
{
    private readonly Calculo analizador;

    public MetodosAbiertos(string funcion)
    {
        if (string.IsNullOrWhiteSpace(funcion))
            throw new ArgumentException("La función no puede estar vacía.");

        analizador = new Calculo();
        if (!analizador.Sintaxis(funcion, 'x'))
            throw new ArgumentException("Función inválida.");
    }

    public Resultado NewtonRaphson(double xi, double tolerancia, int maxIteraciones)
    {
        if (tolerancia <= 0) throw new ArgumentException("La tolerancia debe ser positiva.");
        if (maxIteraciones <= 0) throw new ArgumentException("Las iteraciones deben ser mayores a cero.");

        var resultado = new Resultado();
        double xrAnterior = xi;
        double xr = xi;
        double error = 1.0; // convención

        // chequeo rápido: xi ya es raíz
        if (Math.Abs(analizador.EvaluaFx(xi)) < tolerancia)
        {
            resultado.Raiz = xi;
            resultado.Message = "xi es raíz";
            return resultado;
        }

        for (int i = 1; i <= maxIteraciones; i++)
        {
            double derivada = analizador.Dx(xrAnterior);
            if (double.IsNaN(derivada) || Math.Abs(derivada) < 1e-12)
            {
                resultado.Message = "Derivada ~ 0: el método no puede continuar.";
                resultado.Raiz = xrAnterior;
                return resultado;
            }

            xr = CalcularXrNewton(xrAnterior, derivada);

            if (double.IsNaN(xr) || double.IsInfinity(xr))
            {
                resultado.Message = "xr inválido (NaN/∞): el método diverge.";
                resultado.Raiz = xrAnterior;
                return resultado;
            }

            if (Math.Abs(xr) > 0)
                error = Math.Abs((xr - xrAnterior) / xr);

            resultado.Iteraciones.Add(new Datos(
                iteracion: i,
                xi: xrAnterior,
                xd: null,
                fxi: analizador.EvaluaFx(xrAnterior),
                fxd: null,
                dfxi: derivada,
                xr: xr,
                error: (i == 1 ? 1.0 : error)
            ));

            if (Math.Abs(analizador.EvaluaFx(xr)) < tolerancia || (i > 1 && error < tolerancia))
            {
                resultado.Raiz = xr;
                resultado.Message = "Convergió correctamente";
                return resultado;
            }

            xrAnterior = xr;
        }

        resultado.Raiz = xr;
        resultado.Message = "No convergió: se alcanzó el máximo de iteraciones";
        return resultado;
    }

    public Resultado Secante(double xi, double xd, double tolerancia, int maxIteraciones)
    {
        if (tolerancia <= 0) throw new ArgumentException("La tolerancia debe ser positiva.");
        if (maxIteraciones <= 0) throw new ArgumentException("Las iteraciones deben ser mayores a cero.");

        var resultado = new Resultado();
        double xrAnterior = double.NaN, xr = 0.0, error = 1.0;

        // chequeos rápidos
        double fxi0 = analizador.EvaluaFx(xi);
        if (Math.Abs(fxi0) < tolerancia)
        {
            resultado.Raiz = xi;
            resultado.Message = "xi es raíz";
            return resultado;
        }

        double fxd0 = analizador.EvaluaFx(xd);
        if (Math.Abs(fxd0) < tolerancia)
        {
            resultado.Raiz = xd;
            resultado.Message = "xd es raíz";
            return resultado;
        }

        for (int i = 1; i <= maxIteraciones; i++)
        {
            xr = CalcularXrSecante(xi, xd);

            if (double.IsNaN(xr) || double.IsInfinity(xr))
            {
                resultado.Message = "xr inválido (NaN/∞): el método diverge.";
                resultado.Raiz = (double.IsNaN(xrAnterior) ? xi : xrAnterior);
                return resultado;
            }

            if (!double.IsNaN(xrAnterior) && Math.Abs(xr) > 0)
                error = Math.Abs((xr - xrAnterior) / xr);

            resultado.Iteraciones.Add(new Datos(
                iteracion: i,
                xi: xi,
                xd: xd,
                fxi: analizador.EvaluaFx(xi),
                fxd: analizador.EvaluaFx(xd),
                dfxi: null,
                xr: xr,
                error: (i == 1 ? 1.0 : error)
            ));

            if (Math.Abs(analizador.EvaluaFx(xr)) < tolerancia || (i > 1 && error < tolerancia))
            {
                resultado.Raiz = xr;
                resultado.Message = "Convergió correctamente";
                return resultado;
            }

            // avanzar la secuencia
            xi = xd;
            xd = xr;
            xrAnterior = xr;
        }

        resultado.Raiz = xr;
        resultado.Message = "No convergió: se alcanzó el máximo de iteraciones";
        return resultado;
    }

    // ======================
    // Métodos privados
    // ======================

    private double CalcularXrNewton(double x, double derivadaEnX)
    {
        double fx = analizador.EvaluaFx(x);
        return x - fx / derivadaEnX;
    }

    private double CalcularXrSecante(double xi, double xd)
    {
        double fxi = analizador.EvaluaFx(xi);
        double fxd = analizador.EvaluaFx(xd);
        double denom = fxd - fxi;
        if (Math.Abs(denom) < 1e-14)
            return double.NaN;
        return (fxd * xi - fxi * xd) / denom;
    }
}
