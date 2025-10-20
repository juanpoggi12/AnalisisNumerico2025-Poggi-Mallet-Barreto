using System;
using System.Globalization;

namespace AnalisisNumerico2025Poggi.Integracion
{
    public static class TestIntegracion
    {
        public static void Probar()
        {
            var integ = new IntegracionNumerica();

            Console.WriteLine("=== Pruebas Integración Numérica ===");

            // 1) Trapecios Simple con 1/x en [0.5, 1.5]
            try
            {
                var r1 = integ.TrapeciosSimple("1/x", 0.5, 1.5);
                Console.WriteLine($"Trapecios Simple: f=1/x, [0.5,1.5] -> Área={r1.Resultado.ToString("G6", CultureInfo.InvariantCulture)}");
                if (r1.Advertencias.Count > 0) Console.WriteLine("Warn: " + string.Join(" | ", r1.Advertencias));
            }
            catch (Exception ex) { Console.WriteLine("Error TS: " + ex.Message); }

            // 2) Trapecios Múltiple con sin(x) en [0, π], n=100
            try
            {
                var r2 = integ.TrapeciosMultiple("sin(x)", 0.0, Math.PI, 100);
                Console.WriteLine($"Trapecios Múltiple: f=sin(x), [0,π], n=100 -> Área={r2.Resultado.ToString("G6", CultureInfo.InvariantCulture)} (valor real=2)");
            }
            catch (Exception ex) { Console.WriteLine("Error TM: " + ex.Message); }

            // 3) Simpson 1/3 Simple con x^2 en [0, 2]
            try
            {
                var r3 = integ.Simpson13Simple("x^2", 0.0, 2.0);
                Console.WriteLine($"Simpson 1/3 Simple: f=x^2, [0,2] -> Área={r3.Resultado.ToString("G6", CultureInfo.InvariantCulture)} (valor real=8/3≈2.666666)");
            }
            catch (Exception ex) { Console.WriteLine("Error S1/3S: " + ex.Message); }

            // 4) Simpson 1/3 Múltiple con x en [0, 1], n=10 (par)
            try
            {
                var r4 = integ.Simpson13Multiple("x", 0.0, 1.0, 10);
                Console.WriteLine($"Simpson 1/3 Múltiple: f=x, [0,1], n=10 -> Área={r4.Resultado.ToString("G6", CultureInfo.InvariantCulture)} (valor real=1/2=0.5)");
                if (r4.Advertencias.Count > 0) Console.WriteLine("Warn: " + string.Join(" | ", r4.Advertencias));
            }
            catch (Exception ex) { Console.WriteLine("Error S1/3M: " + ex.Message); }

            // 5) Simpson 3/8 Simple con x^3 en [0, 1]
            try
            {
                var r5 = integ.Simpson38Simple("x^3", 0.0, 1.0);
                Console.WriteLine($"Simpson 3/8 Simple: f=x^3, [0,1] -> Área={r5.Resultado.ToString("G6", CultureInfo.InvariantCulture)} (valor real=1/4=0.25)");
            }
            catch (Exception ex) { Console.WriteLine("Error S3/8: " + ex.Message); }

            // 6) Combinado: sin(x) en [0, π], n=101 (impar)
            try
            {
                var r6 = integ.Simpson13_38Combinado("sin(x)", 0.0, Math.PI, 101);
                Console.WriteLine($"Combinado (1/3+3/8): f=sin(x), [0,π], n=101 -> Área={r6.Resultado.ToString("G6", CultureInfo.InvariantCulture)}");
                if (r6.Advertencias.Count > 0) Console.WriteLine("Warn: " + string.Join(" | ", r6.Advertencias));
            }
            catch (Exception ex) { Console.WriteLine("Error Comb: " + ex.Message); }

            Console.WriteLine("=== Fin de pruebas ===");
        }
    }
}