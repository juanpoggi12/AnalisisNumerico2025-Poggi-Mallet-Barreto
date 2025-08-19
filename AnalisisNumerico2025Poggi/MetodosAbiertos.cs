using AnalisisNumerico2025Poggi;
using Calculus;
using Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MetodosAbiertos
{
    private Calculo analizador;

    public MetodosAbiertos(string funcion)
    {
        analizador = new Calculo();
        if (!analizador.Sintaxis(funcion, 'x'))
            throw new ArgumentException("Función inválida.");
        // La función queda cargada internamente en el objeto analizador
    }

    public Resultado NewtonRaphson(double xi, double tolerancia, int maxIteraciones)
    {
        Resultado resultado = new Resultado();
        double xr = xi;

        for (int i = 0; i < maxIteraciones; i++)
        {
            double fxi = analizador.EvaluaFx(xr);
            double dfxi = analizador.Dx(xr);

            if (Math.Abs(dfxi) < 1e-10)
                break;

            double xrNuevo = xr - fxi / dfxi;
            double error = Math.Abs((xrNuevo - xr) / xrNuevo);

            resultado.Iteraciones.Add(new Datos(
                iteracion: i + 1,
                xi: xr,
                xd: null,
                fxi: fxi,
                fxd: null,
                dfxi: dfxi,
                xr: xrNuevo,
                error: error
            ));

            if (error < tolerancia)
                break;

            xr = xrNuevo;
        }

        resultado.Raiz = xr;
        return resultado;
    }

    public Resultado Secante(double xi, double xd, double tolerancia, int maxIteraciones)
    {
        Resultado resultado = new Resultado();

        for (int i = 0; i < maxIteraciones; i++)
        {
            double fxi = analizador.EvaluaFx(xi);
            double fxd = analizador.EvaluaFx(xd);

            if (Math.Abs(fxd - fxi) < 1e-10)
                break;

            double xr = xd - fxd * (xd - xi) / (fxd - fxi);
            double error = Math.Abs((xr - xd) / xr);

            resultado.Iteraciones.Add(new Datos(
                iteracion: i + 1,
                xi: xi,
                xd: xd,
                fxi: fxi,
                fxd: fxd,
                dfxi: null,
                xr: xr,
                error: error
            ));

            if (error < tolerancia)
                break;

            xi = xd;
            xd = xr;
        }

        resultado.Raiz = xd;
        return resultado;
    }
}
