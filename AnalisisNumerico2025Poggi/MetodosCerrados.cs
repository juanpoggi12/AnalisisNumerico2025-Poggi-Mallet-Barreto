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

        public Resultado algoritmoMetodoCerrado(Datos datos)
        {
            var funcion = datos.funcion;
            if(funcion(datos.xi * datos.xd) > 0)
            {

            }
        }

    }
}
