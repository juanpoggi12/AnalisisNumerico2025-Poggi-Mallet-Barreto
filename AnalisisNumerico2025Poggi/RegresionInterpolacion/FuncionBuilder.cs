using System;
using System.Globalization;
using System.Text;

namespace AnalisisNumerico2025Poggi.Regresion
{
    public static class FuncionBuilder
    {
        // Construye: y = a_k x^k + ... + a1 x + a0 (omitimos términos con coeficiente 0)
        // Redondeo configurable; usa formato con signos integrados.
        public static string Construir(double[] coeficientes, int decimales = 4)
        {
            if (coeficientes == null || coeficientes.Length == 0)
                return "y = 0";

            var sb = new StringBuilder();
            sb.Append("y = ");

            // Recorremos de mayor a menor grado para que sea natural en la UI
            for (int i = coeficientes.Length - 1; i >= 0; i--)
            {
                double ai = Math.Round(coeficientes[i], decimales);
                if (ai == 0) continue;

                string term;
                if (i == 0)
                    term = $"{ai:+0.####;-0.####}";
                else if (i == 1)
                    term = $"{ai:+0.####;-0.####}x";
                else
                    term = $"{ai:+0.####;-0.####}x^{i}";

                sb.Append(term);
            }

            // Si todos los coeficientes fueron 0:
            if (sb.ToString().Trim() == "y =")
                sb.Append(" 0");

            return sb.ToString();
        }
    }
}