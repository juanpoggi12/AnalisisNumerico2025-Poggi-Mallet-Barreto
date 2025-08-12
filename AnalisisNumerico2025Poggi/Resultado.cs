using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisNumerico2025Poggi
{
    public class Resultado
    {
        public bool Success;
        public string Message;

        public Resultado(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
