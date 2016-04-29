using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato
{
    class Program
    {
        /*Inicio Declaración de variables globales*/
        
        /*Inicio Declaración de variables globales*/
        static void Main(string[] args)
        {
            string name1 = "";
            string name2 = "";





            asignacion();
            Console.Read();
            Console.WriteLine("Nombre del jugador 1: ");
            name1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Nombre del jugador 2: ");
            name2 = Console.ReadLine();
           

            instrucciones();
            Console.Read();
            asignacion();

        }

        static void instrucciones()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al juego del gato. A continuación dos jugadores deben de colocar un símbolo en el tablero uno a la vez, el jugador que logre completar una linea de tres simbolos completos ganará el luego, en caso que ninguno lo logre se considerará empate. El juego asigna aleatoriamente el simbolo para cada jugador.");
            tablero();
        }

        static void tablero()
        {

            int[] posiciones = new int [9];


            for (int x=0; x<=8; x++)
            {
                posiciones[x] = x+1;
            }
            //Console.WriteLine("\nLas casillas disponibles están marcadas con un número");
            Console.WriteLine("\n     "+posiciones[0]+ " | "+ posiciones[1]+"  | "+ posiciones[2]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + posiciones[3] + " | " + posiciones[4] + "  | " + posiciones[5]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + posiciones[6] + " | " + posiciones[7] + "  | " + posiciones[8]);

        }

        static void asignacion()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int n = r.Next(0, 10);
            Console.WriteLine(n);

        }
    }
}
