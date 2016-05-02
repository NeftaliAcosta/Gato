using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato
{
    class jugador
    {

        public string nombre { get; set; }
        public string caracter{ get; set; }
        public int puntos { get; set; }

    }

    class tablero
    {
        public string[] position = new string[9];
    }
   

   
}
