/*
 Autor: Neftalí Acosta
 AUtor URL: https://neftaliacosta.com
 URL: https://github.com/NeftaliAcosta/Gato/wiki
 Contacto: hola@neftaliacosta.com
 Versión: 1.6.2
 Ultima fecha de actualización: 17/10/2016
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Gato
{
    class Program
    {
        /*Inicio Declaración de variables globales*/


        /*Inicio Declaración de variables globales*/
        static void Main(string[] args)
        {
            bdconection myconect = new bdconection();
            string resp = "";
            do{
                
                menu();
                resp = Console.ReadLine().ToLower();
                switch (resp)
                    {
                        case "a":
                            Console.Clear();
                            inicio();
                            Console.WriteLine("Seleccionaste A");
                            break;
                        case "b":
                            Console.Clear();
                            myconect.consultar();
                            Console.WriteLine("Seleccionaste B");
                            break;
                        case "x":
                            Console.Clear();
                            Console.WriteLine("Seleccionaste C");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Seleccion invalida");
                            break;


                    }
                }while(resp != "X");

            

    
        }
        static void menu()
        {
            Console.Clear();
            Console.WriteLine("Juego del Gato V: 1.6");
            Console.WriteLine("");
            Console.WriteLine("=========MENÚ========");
            Console.WriteLine("Presiona 'A' para iniciar una partida");
            Console.WriteLine("Presiona 'B' para ver el marcador");
            Console.WriteLine("Presiona 'X' para salir");
        }

        static void inicio()
        {
            jugador jugador1 = new jugador();
            jugador jugador2 = new jugador();
            instrucciones();
            Console.WriteLine("Escriba el nombre del jugador 1");
            jugador1.nombre = Console.ReadLine();
            Console.WriteLine("Escriba el nombre del jugador 2");
            jugador2.nombre = Console.ReadLine();
            Random r = new Random(DateTime.Now.Millisecond);
            int n = r.Next(0, 10);

            if (n > 5)
            {
                jugador1.caracter = "X";
                jugador2.caracter = "O";
            }
            else
            {
                jugador1.caracter = "O";
                jugador2.caracter = "X";
            }
            Console.WriteLine("---ASIGNACION---");
            Console.WriteLine(jugador1.nombre + ":" + jugador1.caracter);
            Console.WriteLine(jugador2.nombre + ":" + jugador2.caracter);
            Console.WriteLine("¡Preparando la partida!.........");
            System.Threading.Thread.Sleep(2000);
            ipartida(jugador1.nombre, jugador1.caracter, jugador2.nombre, jugador2.caracter);
        }
        static void instrucciones()
        {
            tablero mitab = new tablero();
            Console.Clear();
            Console.WriteLine("Bienvenido al juego del gato. A continuación dos jugadores deben de colocar un símbolo en el tablero uno a la vez, el jugador que logre completar una linea de tres simbolos completos ganará el juego, en caso que ninguno lo logre se considerará empate. El juego asigna aleatoriamente el simbolo para cada jugador.");
            formateador(mitab.position);
        }

        static void ipartida(string n1, string c1, string n2, string c2)
        {
            bdconection mycon = new bdconection();
            Console.Clear();
            jugador j1 = new jugador();
            jugador j2 = new jugador();
            tablero mytablero = new tablero();
            j1.nombre = n1;
            j1.caracter = c1;
            j2.nombre = n2;
            j2.caracter = c2;

            bool esnumero;
            string spotition;
            string var = "";
            int var2 = 0;
            int ipotition;
            int njugador = 1;
            bool ganador = true;


            while (ganador)
            {
                Console.Clear();
                formateador(mytablero.position);

                if (njugador == 1)
                {

                    Console.Write(j1.nombre + " selecciona una posición");
                    spotition = Console.ReadLine();
                    try
                    {
                        esnumero= Int32.TryParse(spotition, out ipotition);
                        ipotition = ipotition - 1;
                        if (esnumero && ipotition < 0 || ipotition > 8)
                        {
                            Console.WriteLine("La posicion no existe, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                        else if (esnumero && String.IsNullOrEmpty(mytablero.position[ipotition]))
                        {
                            mytablero.position[ipotition] = j1.caracter;
                            var2 = var2 + 1;
                        }
                        else if (esnumero == false)
                        {
                            Console.WriteLine("¡TURNO PERDIDO! No ingresaste una posicion :(");
                            System.Threading.Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("Posicion ocupada, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Posicion invalidad, turno perdido :(");
                    }

                }
                if (njugador == 2)
                {

                    Console.Write(j2.nombre + " selecciona una posición");
                    spotition = Console.ReadLine();
                    try
                    {
                        esnumero = Int32.TryParse(spotition, out ipotition);
                        ipotition = ipotition - 1;
                        if (esnumero && ipotition < 0 || ipotition > 8)
                        {
                            Console.WriteLine("La posicion no existe, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                        else if (esnumero && String.IsNullOrEmpty(mytablero.position[ipotition]))
                        {
                            mytablero.position[ipotition] = j2.caracter;
                            var2 = var2 + 1;
                        }
                        else if (esnumero == false)
                        {
                            Console.WriteLine("¡TURNO PERDIDO! No ingresaste una posicion :(");
                            System.Threading.Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("Posicion ocupada, perdiste el turno :(");
                            System.Threading.Thread.Sleep(1000);

                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Posicion invalidad, turno perdido :(");
                    }

                }

                var = validarganador(mytablero.position);
                if (var == "X")
                {
                    if (j1.caracter == "X")
                    {
                        Console.WriteLine("¡¡¡Felicidades " + j1.nombre + " ganaste la partida!!!");
                        System.Threading.Thread.Sleep(6000);
                        mycon.insertar(j1.nombre);
                    }
                    else
                    {
                        Console.WriteLine("¡¡¡Felicidades " + j2.nombre + " ganaste la partida!!!");
                        System.Threading.Thread.Sleep(6000);
                        mycon.insertar(j2.nombre);
                    }
                    ganador = false;
                }
                else if (var == "O")
                {
                    if (j1.caracter == "O")
                    {
                        Console.WriteLine("¡¡¡Felicidades " + j1.nombre + " ganaste la partida!!!");
                        System.Threading.Thread.Sleep(6000);
                        mycon.insertar(j1.nombre);
                    }
                    else
                    {
                        Console.WriteLine("¡¡¡Felicidades " + j2.nombre + " ganaste la partida!!!");
                        System.Threading.Thread.Sleep(6000);
                        mycon.insertar(j2.nombre);
                    }
                    ganador = false;
                }

                if (var2 == 9)
                {
                    Console.WriteLine("Esta machaca fue empate!!!");
                    System.Threading.Thread.Sleep(6000);
                    ganador = false;
                }

                if (njugador == 1)
                {
                    njugador = 2;
                }
                else if (njugador == 2)
                {
                    njugador = 1;
                }
            }



        }

        static void formateador(string[] tab)
        {
            var nuevoTab = new string[tab.Length];
            tab.CopyTo(nuevoTab, 0);
            for (int i=0; i<=8; i++)
            {
                if (nuevoTab[i]== null)
                {
                    int x = i + 1;
                    nuevoTab[i]= Convert.ToString(x);
                }
            }
            Console.WriteLine("\n     " + nuevoTab[0] + " | " + nuevoTab[1] + "  | " + nuevoTab[2]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + nuevoTab[3] + " | " + nuevoTab[4] + "  | " + nuevoTab[5]);
            Console.WriteLine("\n   ___  ___  ___");
            Console.WriteLine("\n     " + nuevoTab[6] + " | " + nuevoTab[7] + "  | " + nuevoTab[8]);

            

        }


        static string validarganador(string[] array)
        {
            string ganador="";
            if(array[0]=="X" && array[1]=="X" && array[2]=="X")
            {
                ganador = "X";
            }
            else if (array[0] == "O" && array[1] == "O" && array[2] == "O")
            {
                ganador = "O";
            }
            else if (array[3] == "X" && array[4] == "X" && array[5] == "X")
            {
                ganador = "X";
            }
            else if (array[3] == "O" && array[4] == "O" && array[5] == "O")
            {
                ganador = "O";
            }
            else if (array[6] == "X" && array[7] == "X" && array[8] == "X")
            {
                ganador = "X";
            }
            else if (array[6] == "O" && array[7] == "O" && array[8] == "O")
            {
                ganador = "O";
            }
            else if (array[0] == "X" && array[3] == "X" && array[6] == "X")
            {
                ganador = "X";
            }
            else if (array[0] == "O" && array[3] == "O" && array[6] == "O")
            {
                ganador = "O|";
            }
            else if (array[1] == "X" && array[4] == "X" && array[7] == "X")
            {
                ganador = "X";
            }
            else if (array[1] == "O" && array[4] == "O" && array[7] == "O")
            {
                ganador = "O";
            }
            else if (array[2] == "X" && array[5] == "X" && array[8] == "X")
            {
                ganador = "X";
            }
            else if (array[2] == "O" && array[5] == "O" && array[8] == "O")
            {
                ganador = "O";
            }
            else if (array[0] == "X" && array[4] == "X" && array[8] == "X")
            {
                ganador = "X";
            }
            else if (array[0] == "O" && array[4] == "O" && array[8] == "O")
            {
                ganador = "O";
            }
            else if (array[2] == "X" && array[4] == "X" && array[6] == "X")
            {
                ganador = "X";
            }
            else if (array[2] == "O" && array[4] == "O" && array[6] == "O")
            {
                ganador = "O";
            }
           
            
            return ganador;
        }
    }
}
