using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generador
{
    class Error
    {
        public String codigo;
        public String mensaje;

        public Error(String c,String m)
        {
            codigo = c;
            mensaje = m;
        }
    }
}
