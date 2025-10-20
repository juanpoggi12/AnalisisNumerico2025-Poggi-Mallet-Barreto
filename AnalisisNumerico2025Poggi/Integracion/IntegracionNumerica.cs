using Calculus;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AnalisisNumerico2025Poggi.Integracion
{
    // Se asume que existe Calculo con API:
    //   bool Sintaxis(string f, char variable)
    //   double EvaluaFx(double x)
    // Ajusta el using/namespaces si Calculo está en otro lugar del proyecto.
    public sealed class IntegracionNumerica
    {
        private static void ValidarRango(string funcion, double xi, double xd)
        {
            if (string.IsNullOrWhiteSpace(funcion))
                throw new ArgumentException("Debe ingresar una función (ej: 1/x, sin(x), x^2 + 3x).");

            if (double.IsNaN(xi) || double.IsNaN(xd))
                throw new ArgumentException("Xi y Xd deben ser valores numéricos válidos.");

            if (xd <= xi)
                throw new ArgumentException("Xd debe ser mayor que Xi.");
        }

        private static Calculo CrearCalculoValidando(string funcion)
        {
            var calc = new Calculo();
            if (!calc.Sintaxis(funcion, 'x'))
                throw new ArgumentException("Función mal ingresada. Revise la sintaxis.");
            return calc;
        }

        private static void ChequearSingularidad(Calculo fx, double xi, double xd, List<string> warnings)
        {
            // Chequeo básico: evalúa extremos. Si son NaN/Inf, avisar.
            double fi = fx.EvaluaFx(xi);
            double fd = fx.EvaluaFx(xd);
            if (double.IsNaN(fi) || double.IsInfinity(fi))
                warnings.Add($"Advertencia: f(xi) es inválida (NaN/Inf). Revise discontinuidades cercanas a xi={xi.ToString("G", CultureInfo.InvariantCulture)}.");

            if (double.IsNaN(fd) || double.IsInfinity(fd))
                warnings.Add($"Advertencia: f(xd) es inválida (NaN/Inf). Revise discontinuidades cercanas a xd={xd.ToString("G", CultureInfo.InvariantCulture)}.");
        }

        // -----------------------
        // Trapecios Simple
        // -----------------------
        public ResultadoIntegracion TrapeciosSimple(string funcion, double xi, double xd)
        {
            ValidarRango(funcion, xi, xd);
            var calc = CrearCalculoValidando(funcion);
            var res = BaseResult("Trapecios Simple", funcion, xi, xd, n: 1);

            ChequearSingularidad(calc, xi, xd, res.Advertencias);

            double area = ((calc.EvaluaFx(xi) + calc.EvaluaFx(xd)) * (xd - xi)) / 2.0;
            res.Resultado = area;
            res.Mensaje = "Área calculada exitosamente (Trapecios Simple).";
            return res;
        }

        // -----------------------
        // Trapecios Múltiple
        // -----------------------
        public ResultadoIntegracion TrapeciosMultiple(string funcion, double xi, double xd, int n)
        {
            ValidarRango(funcion, xi, xd);
            if (n <= 0) throw new ArgumentException("n debe ser un entero > 0.");
            var calc = CrearCalculoValidando(funcion);
            var res = BaseResult("Trapecios Múltiple", funcion, xi, xd, n);

            double h = (xd - xi) / n;
            double sum = 0.0;
            // i = 1..n-1
            for (int i = 1; i < n; i++)
            {
                double x = xi + h * i;
                double fx = calc.EvaluaFx(x);
                if (double.IsNaN(fx) || double.IsInfinity(fx))
                    res.Advertencias.Add($"Advertencia: f({x.ToString("G", CultureInfo.InvariantCulture)}) es inválida (NaN/Inf).");

                sum += fx;
            }

            double area = (h / 2.0) * (calc.EvaluaFx(xi) + 2.0 * sum + calc.EvaluaFx(xd));
            res.Resultado = area;
            res.Mensaje = "Área calculada exitosamente (Trapecios Múltiple).";
            return res;
        }

        // -----------------------
        // Simpson 1/3 Simple
        // -----------------------
        public ResultadoIntegracion Simpson13Simple(string funcion, double xi, double xd)
        {
            ValidarRango(funcion, xi, xd);
            var calc = CrearCalculoValidando(funcion);
            var res = BaseResult("Simpson 1/3 Simple", funcion, xi, xd, n: 2);

            double h = (xd - xi) / 2.0;
            double f0 = calc.EvaluaFx(xi);
            double f1 = calc.EvaluaFx(xi + h);
            double f2 = calc.EvaluaFx(xd);

            res.Resultado = (h / 3.0) * (f0 + 4.0 * f1 + f2);
            res.Mensaje = "Área calculada exitosamente (Simpson 1/3 Simple).";
            return res;
        }

        // -----------------------
        // Simpson 1/3 Múltiple (n debe ser par)
        // -----------------------
        public ResultadoIntegracion Simpson13Multiple(string funcion, double xi, double xd, int n)
        {
            ValidarRango(funcion, xi, xd);
            if (n <= 0) throw new ArgumentException("n debe ser un entero > 0.");
            var calc = CrearCalculoValidando(funcion);
            var res = BaseResult("Simpson 1/3 Múltiple", funcion, xi, xd, n);

            double h = (xd - xi) / n;

            double sumImpares = 0.0; // i = 1,3,5,...,n-1
            double sumPares = 0.0;   // i = 2,4,6,...,n-2
            for (int i = 1; i < n; i++)
            {
                double x = xi + h * i;
                double fx = calc.EvaluaFx(x);
                if (i % 2 == 0) sumPares += fx; else sumImpares += fx;
            }

            res.Resultado = (h / 3.0) * (calc.EvaluaFx(xi) + 4.0 * sumImpares + 2.0 * sumPares + calc.EvaluaFx(xd));

            if (n % 2 != 0)
                res.Advertencias.Add("n es impar: Simpson 1/3 múltiple requiere n par. Considere usar la versión combinada con 3/8.");

            res.Mensaje = "Área calculada exitosamente (Simpson 1/3 Múltiple).";
            return res;
        }

        // -----------------------
        // Simpson 3/8 Simple
        // -----------------------
        public ResultadoIntegracion Simpson38Simple(string funcion, double xi, double xd)
        {
            ValidarRango(funcion, xi, xd);
            var calc = CrearCalculoValidando(funcion);
            var res = BaseResult("Simpson 3/8 Simple", funcion, xi, xd, n: 3);

            double h = (xd - xi) / 3.0;
            double f0 = calc.EvaluaFx(xi);
            double f1 = calc.EvaluaFx(xi + h);
            double f2 = calc.EvaluaFx(xi + 2.0 * h);
            double f3 = calc.EvaluaFx(xd);

            res.Resultado = (3.0 * h / 8.0) * (f0 + 3.0 * f1 + 3.0 * f2 + f3);
            res.Mensaje = "Área calculada exitosamente (Simpson 3/8 Simple).";
            return res;
        }

        // -----------------------------------------
        // Combinado: Simpson 3/8 + Simpson 1/3 mult
        // -----------------------------------------
        // Idea: si n es impar, aplicamos 3/8 a los últimos 3 subintervalos,
        // luego 1/3 múltiple al resto (n-3), que ya será par.
        public ResultadoIntegracion Simpson13_38Combinado(string funcion, double xi, double xd, int n)
        {
            ValidarRango(funcion, xi, xd);
            if (n <= 0) throw new ArgumentException("n debe ser un entero > 0.");
            var calc = CrearCalculoValidando(funcion);
            var res = BaseResult("Simpson 1/3 + 3/8 Combinado", funcion, xi, xd, n);

            double h = (xd - xi) / n;
            double resultado = 0.0;

            if (n % 2 != 0)
            {
                // Tomamos últimos 3 subintervalos con 3/8
                double nuevoXi = xi + h * (n - 3);
                // 3/8 en [nuevoXi, xd]
                double f0 = calc.EvaluaFx(nuevoXi);
                double f1 = calc.EvaluaFx(nuevoXi + h);
                double f2 = calc.EvaluaFx(nuevoXi + 2.0 * h);
                double f3 = calc.EvaluaFx(xd);
                double area38 = (3.0 * h / 8.0) * (f0 + 3.0 * f1 + 3.0 * f2 + f3);
                resultado += area38;

                // Ahora aplicamos 1/3 múltiple en [xi, nuevoXi] con n-3 (par)
                int nRestante = n - 3;
                if (nRestante > 0)
                {
                    double h2 = (nuevoXi - xi) / nRestante;
                    double sumImpares = 0.0, sumPares = 0.0;
                    for (int i = 1; i < nRestante; i++)
                    {
                        double x = xi + h2 * i;
                        double fx = calc.EvaluaFx(x);
                        if (i % 2 == 0) sumPares += fx; else sumImpares += fx;
                    }
                    double area13 = (h2 / 3.0) * (calc.EvaluaFx(xi) + 4.0 * sumImpares + 2.0 * sumPares + calc.EvaluaFx(nuevoXi));
                    resultado += area13;
                }

                res.Advertencias.Add("Se aplicó Simpson 3/8 en los últimos 3 subintervalos por n impar, y Simpson 1/3 en el resto.");
            }
            else
            {
                // n par: equivale a Simpson 1/3 múltiple clásico
                double sumImpares = 0.0, sumPares = 0.0;
                for (int i = 1; i < n; i++)
                {
                    double x = xi + h * i;
                    double fx = calc.EvaluaFx(x);
                    if (i % 2 == 0) sumPares += fx; else sumImpares += fx;
                }
                resultado = (h / 3.0) * (calc.EvaluaFx(xi) + 4.0 * sumImpares + 2.0 * sumPares + calc.EvaluaFx(xd));
                res.Advertencias.Add("n par: se aplicó Simpson 1/3 múltiple.");
            }

            res.Resultado = resultado;
            res.Mensaje = "Área calculada exitosamente (Combinado).";
            return res;
        }

        // -----------------------
        // Helper para construir DTO
        // -----------------------
        private static ResultadoIntegracion BaseResult(string metodo, string funcion, double xi, double xd, int n)
        {
            return new ResultadoIntegracion
            {
                Metodo = metodo,
                Funcion = funcion,
                Xi = xi,
                Xd = xd,
                Subintervalos = n
            };
        }
    }
}