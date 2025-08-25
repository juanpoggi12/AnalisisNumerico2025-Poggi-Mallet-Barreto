using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculus; 
namespace AnalisisNumerico2025Poggi
{
    public class MetodosCerrados
    {
        public Datos Datos;

        public Resultado algoritmoMetodoCerrado(string funcion, Datos datos)
        {
            var analizador = new Calculo();
            if (!analizador.Sintaxis(funcion, 'x'))
                throw new ArgumentException("Función inválida.");

            // Aquí puedes usar analizador.EvaluaFx(datos.Xi) y analizador.EvaluaFx(datos.Xd)
            if (datos.Xd == null)
                throw new ArgumentException("Xd no puede ser null.");

            if (analizador.EvaluaFx(datos.Xi) * analizador.EvaluaFx(datos.Xd.Value) > 0)
            {
                return new Resultado { Message = "No hay cambio de signo en el intervalo." };
            }
            return new Resultado();
        }

    }
}
