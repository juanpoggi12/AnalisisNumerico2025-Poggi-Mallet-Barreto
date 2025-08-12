using System.Linq.Expressions;
using Calculus;
namespace AnalisisNumerico2025Poggi
{
    public class Datos
    {
        //Ingresar funcion, iteraciones, tolerancia, xi, xd, método
        public string FuncionString {  get; set; }
        public Func<double, double> Funcion {  get; set; }
        public string Metodo { get; set; }
        public int Iteraciones { get; set; }
        public double Tolerancia { get; set; }
        public double Xi {  get; set; }
        public double Xd { get; set; }

        public Datos(string funcionString, string metodo, int iteraciones, double tolerancia, double xi, double xd)
        {
            FuncionString = funcionString;
            Funcion = new Expression(funcionString);
        }

    }
}
