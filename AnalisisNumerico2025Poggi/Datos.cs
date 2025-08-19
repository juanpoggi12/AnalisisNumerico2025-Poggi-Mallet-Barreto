using System.Linq.Expressions;
using Calculus;
using System;
namespace AnalisisNumerico2025Poggi
{
    public class Datos
    {
        public int Iteracion { get; set; }
        public double Xi { get; set; }
        public double? Xd { get; set; }
        public double Fxi { get; set; }
        public double? Fxd { get; set; }
        public double? Dfxi { get; set; }
        public double Xr { get; set; }
        public double Error { get; set; }

        public Datos() { }

        public Datos(int iteracion, double xi, double? xd, double fxi, double? fxd, double? dfxi, double xr, double error)
        {
            Iteracion = iteracion;
            Xi = xi;
            Xd = xd;
            Fxi = fxi;
            Fxd = fxd;
            Dfxi = dfxi;
            Xr = xr;
            Error = error;
        }
    }
}
