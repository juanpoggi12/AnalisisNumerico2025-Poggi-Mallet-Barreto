using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi.Integracion
{
    public class RectaModificadaService
    {
        private Tuple<double, double> ObtenerCoeficientesFuncion(string funcion)
        {
            if (string.IsNullOrWhiteSpace(funcion))
                throw new ArgumentException("La función no puede estar vacía.");

            var regex = new Regex(@"y\s*=\s*([+-]?\d+(?:[.,]\d+)?)\s*x\s*([+-]\s*\d+(?:[.,]\d+)?)");
            var match = regex.Match(funcion);

            if (!match.Success)
                throw new FormatException("Formato inválido. Ejemplo esperado: y = 2.5x - 1.3");

            string a1Str = match.Groups[1].Value.Replace(',', '.');
            string a0Str = match.Groups[2].Value.Replace(',', '.').Replace(" ", "");

            double a1 = double.Parse(a1Str, CultureInfo.InvariantCulture);
            double a0 = double.Parse(a0Str, CultureInfo.InvariantCulture);

            return Tuple.Create(a1, a0);
        }

        public ResultadoRectaModificada CalcularRRectaModificada(List<double[]> puntos, string funcionModificada, int decimales = 6, double? tolerancia = null)
        {
            if (puntos == null || puntos.Count < 2)
                throw new InvalidOperationException("Se requieren al menos 2 puntos.");

            var (a1, a0) = ObtenerCoeficientesFuncion(funcionModificada);

            double sumY = puntos.Sum(p => p[1]);
            double yProm = sumY / puntos.Count;

            double st = 0.0;
            double sr = 0.0;

            foreach (var p in puntos)
            {
                double yi = p[1];
                double yHat = a1 * p[0] + a0;

                st += Math.Pow(yProm - yi, 2);
                sr += Math.Pow(yHat - yi, 2);
            }

            if (st == 0)
            {
                return new ResultadoRectaModificada
                {
                    A1 = Math.Round(a1, decimales),
                    A0 = Math.Round(a0, decimales),
                    RPorcentaje = 0,
                    CantidadPuntos = puntos.Count,
                    SumatoriaY = Math.Round(sumY, decimales),
                    Mensaje = "Varianza total nula (st=0). No se puede calcular r."
                };
            }

            double r = Math.Sqrt(Math.Max(0.0, (st - sr) / st)) * 100.0;

            string mensaje = tolerancia.HasValue
                ? (r >= tolerancia.Value ? "Efectividad del ajuste: Aceptable" : "Efectividad del ajuste: No aceptable")
                : "Efectividad calculada sobre la recta modificada.";

            return new ResultadoRectaModificada
            {
                A1 = Math.Round(a1, decimales),
                A0 = Math.Round(a0, decimales),
                RPorcentaje = Math.Round(r, decimales),
                CantidadPuntos = puntos.Count,
                SumatoriaY = Math.Round(sumY, decimales),
                Mensaje = mensaje
            };
        }
    }

}
