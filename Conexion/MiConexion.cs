using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class MiConexion
    {
        private static string url = "http://localhost:3000/api";

        //private static string url = "http://programacionspps.online/api";

        public static string getConexion()
        {
            return url;
        }

    }
}
