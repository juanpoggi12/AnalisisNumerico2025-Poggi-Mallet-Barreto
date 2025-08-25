using AnalisisNumerico2025Poggi;
using Calculus;
using System;
using System.Collections.Generic;

public class MetodosAbiertos
{
    private Calculo analizador;

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

        Resultado resultado = new Resultado();
        double xrAnterior = xi;
        double xr = xi;
        double error = 0;

     
        double fxi = analizador.EvaluaFx(xi);
        if (Math.Abs(fxi) < tolerancia)
        {
            resultado.Raiz = xi;
            resultado.Message = "xi es raíz";
            return resultado;
        }

        for (int i = 1; i <= maxIteraciones; i++)
        {
            double derivada = analizador.Dx(xr);
            if (double.IsNaN(derivada) || Math.Abs(derivada) < 1e-10)
            {
                resultado.Message = "El método diverge. No encuentra raíz (derivada nula o NaN).";
                break;
            }

            xr = CalcularXr("tangente", xr, 0); 
            if (double.IsNaN(xr))
            {
                resultado.Message = "El método diverge. No encuentra raíz (xr es NaN).";
                break;
            }

            error = Math.Abs((xr - xrAnterior) / xr);

            resultado.Iteraciones.Add(new Datos(
                iteracion: i,
                xi: xrAnterior,
                xd: null,
                fxi: analizador.EvaluaFx(xrAnterior),
                fxd: null,
                dfxi: derivada,
                xr: xr,
                error: error
            ));

            if (Math.Abs(analizador.EvaluaFx(xr)) < tolerancia || error < tolerancia)
            {
                resultado.Raiz = xr;
                resultado.Message = "xr es raíz";
                break;
            }

            xrAnterior = xr;
        }

        if (resultado.Raiz == 0)
        {
            resultado.Raiz = xr;
            resultado.Message = "Devuelve xr por superar iteraciones";
        }
        return resultado;
    }

    public Resultado Secante(double xi, double xd, double tolerancia, int maxIteraciones)
    {
        if (tolerancia <= 0) throw new ArgumentException("La tolerancia debe ser positiva.");
        if (maxIteraciones <= 0) throw new ArgumentException("Las iteraciones deben ser mayores a cero.");

        Resultado resultado = new Resultado();
        double xrAnterior = 0, xr = 0, error = 0;

        
        double fxi = analizador.EvaluaFx(xi);
        if (Math.Abs(fxi) < tolerancia)
        {
            resultado.Raiz = xi;
            resultado.Message = "xi es raíz";
            return resultado;
        }
        double fxd = analizador.EvaluaFx(xd);
        if (Math.Abs(fxd) < tolerancia)
        {
            resultado.Raiz = xd;
            resultado.Message = "xd es raíz";
            return resultado;
        }

        for (int i = 1; i <= maxIteraciones; i++)
        {
            xr = CalcularXr("secante", xi, xd);
            if (double.IsNaN(xr))
            {
                resultado.Message = "El método diverge. No encuentra raíz (xr es NaN).";
                break;
            }

            error = i == 1 ? 0 : Math.Abs((xr - xrAnterior) / xr);

            resultado.Iteraciones.Add(new Datos(
                iteracion: i,
                xi: xi,
                xd: xd,
                fxi: analizador.EvaluaFx(xi),
                fxd: analizador.EvaluaFx(xd),
                dfxi: null,
                xr: xr,
                error: error
            ));

            if (Math.Abs(analizador.EvaluaFx(xr)) < tolerancia || (i > 1 && error < tolerancia))
            {
                resultado.Raiz = xr;
                resultado.Message = "xr es raíz";
                break;
            }

            xi = xd;
            xd = xr;
            xrAnterior = xr;
        }

        if (resultado.Raiz == 0)
        {
            resultado.Raiz = xr;
            resultado.Message = "Devuelve xr por superar iteraciones";
        }
        return resultado;
    }


    private double CalcularXr(string metodo, double xi, double xd)
    {
        if (metodo == "tangente")
        {
            double derivada = analizador.Dx(xi);
            if (double.IsNaN(derivada) || Math.Abs(derivada) < 1e-10)
                return double.NaN;
            return xi - analizador.EvaluaFx(xi) / derivada;
        }
        else if (metodo == "secante")
        {
            double fxi = analizador.EvaluaFx(xi);
            double fxd = analizador.EvaluaFx(xd);
            if (Math.Abs(fxd - fxi) < 1e-10)
                return double.NaN;
            return (fxd * xi - fxi * xd) / (fxd - fxi);
        }
        return double.NaN;
    }
}
