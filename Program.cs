using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ESTUDIANTES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool program = true;

            List<string[]> students = new List<string[]>();
            List<double[]> califications = new List<double[]>(); // T1, T2, T3, T4


            /*
             * Ordenar el menu de opciones de acuerdo al funcionamiento del programa. [21-11-22, 02:07 a.m]
             */
            do
            {
                Console.Clear();

                Console.WriteLine("------------------");
                Console.WriteLine(" MENU DE OPCIONES ");
                Console.WriteLine("------------------\n");
                Console.WriteLine("1. Agregar estudiante");
                Console.WriteLine("2. Listar estudiantes");
                Console.WriteLine("3. Ingresar notas del estudiante");
                Console.WriteLine("4. Listar notas de cada estudiante");
                Console.WriteLine("5. Modificar nota de estudiante");
                Console.WriteLine("6. Eliminar estudiante");
                Console.WriteLine("7. Salir del programa\n");

                Console.Write("Selecciona una opcion: ");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                option = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (option)
                {
                    case 1: // Agregar estudiante
                        Console.Clear();

                        students.Add(newStudent(3));

                        Console.ReadKey(true);
                        break;
                    case 2: // Listar estudiantes
                        Console.Clear();

                        Console.WriteLine("--------------------");
                        Console.WriteLine(" LISTAR ESTUDIANTES ");
                        Console.WriteLine("--------------------\n");

                        for (int i = 0; i < students.Count; i++) // String[]
                        {
                            Console.Write("{0}. ", i);

                            for (int j = 0; j < students[i].Length; j++) // [i]
                            {
                                if (j == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("[{0}] ", students[i][j]);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                } else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("{0} ", students[i][j]);
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (students.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No se han encontrado registros");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        Console.ReadKey(true);
                        break;
                    case 3: // Ingresar notas de estudiantes
                        Console.Clear();

                        if (students.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Debe ingresar, como minimo, un estudiante.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            califications.Add(addCalifications(4));
                        }

                        Console.ReadKey(true);
                        break;
                    case 4: // Listar notas de cada estudiante
                        Console.Clear();

                        double prom;

                        Console.WriteLine("---------------------");
                        Console.WriteLine("     LISTAR NOTAS    ");
                        Console.WriteLine("---------------------\n");


                        // Estudiantes
                        for (int i = 0; i < students.Count; i++) // String[]
                        {
                            Console.WriteLine("Estudiante {0}", i + 1);

                            for (int j = 0; j < students[i].Length; j++) // [i]
                            {
                                if (j == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("[{0}] ", students[i][j]);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("{0} ", students[i][j]);
                                }
                            }

                            Console.WriteLine("\n");

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            for (int j = 0; j < califications[i].Length; j++)
                            {
                                Console.WriteLine("Nota T{0} = {1}", j + 1, califications[i][j]);
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;

                            Console.WriteLine();

                            prom = calAverage(califications[i]);

                            if (prom >= 14.00)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("[Aprobado] ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("{0}\n", prom);
                            } else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("[Desaprobado] ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("{0}\n", prom);
                            }

                            Console.WriteLine("\n================================");
                            Console.WriteLine();
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (students.Count == 0 || califications.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No se han encontrado registros.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        Console.ReadKey(true);
                        break;
                    case 5: // Modificar nota de estudiante
                        Console.Clear();
                        double num_reem = 0, ind = 0;

                        int estudiante;

                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("  MODIFICAR DATOS DE ESTUDIANTE  ");
                        Console.WriteLine("---------------------------------\n");

                        Console.Write("* Ingrese estudiante : ");
                        estudiante = int.Parse(Console.ReadLine());
                        Console.Write("* Ingresa la nota del trabajo a reemplazar T[1-4]: ");
                        ind = int.Parse(Console.ReadLine());
                        Console.Write("* Ingresar nota a reemplazar: ");
                        num_reem = int.Parse(Console.ReadLine());
                        for (int i = 0; i < califications.Count; i++)
                        {
                            if (i == estudiante)
                            {
                                for (int j = 0; j < califications[i].Length; j++)
                                {

                                    if (j == ind - 1)
                                    {

                                        califications[i][j] = num_reem;

                                    }
                                }

                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nLa nota ha sido actualizada.");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.ReadKey(true);
                        break;
                    case 6: // Eliminar estudiante
                        Console.Clear();

                        int index;
                        bool searchStatus = true;

                        if (students.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No se han encontrado registros para eliminar.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine(" ELIMINAR ESTUDIANTE ");
                            Console.WriteLine("---------------------\n");

                            Console.Write("Indice del estudiante a eliminar: ");

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            index = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;

                            // Eliminar estudiante
                            for (int i = 0; i < students.Count; i++)
                            {
                                if (index == i)
                                {
                                    students.RemoveAt(i);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("El estudiante ha sido eliminado");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                else
                                {
                                    searchStatus = false;
                                }
                            }

                            //Eliminar notas de dicho estudiante en relacion con su indice
                            for (int i = 0; i < califications.Count; i++)
                            {
                                if (index == i)
                                {
                                    califications.RemoveAt(i);
                                }
                            }

                            if (searchStatus != true)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("No se a encontrado dicho indice.");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }

                        Console.ReadKey(true);
                        break;
                    case 7: // Fin del programa
                        Console.Clear();

                        Console.WriteLine("Presiona una tecla para salir...");
                        Console.ReadKey(true);

                        program = false;
                        break;
                    default:
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingresa una opcion valida.");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.ReadKey(true);
                        break;
                }

            } while (program);
        }

        // Funcion que genera arreglo de estudiantes dinamicos y diferenciados

        public static string[] newStudent(int amountData)
        {
            string value;
            string[] array = new string[amountData];

            if (amountData != 0)
            {

                Console.WriteLine("--------------------");
                Console.WriteLine("  NUEVO ESTUDIANTE  ");
                Console.WriteLine("--------------------\n");

                for (int i = 0; i < array.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write("Nombres: ");

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            value = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;

                            array[i] = value;
                            break;

                        case 1:
                            Console.Write("Apellidos: ");

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            value = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;

                            array[i] = value;
                            break;

                        case 2:
                            Console.Write("Codigo: ");

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            value = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;

                            array[i] = value;
                            break;

                    }
                }
            }
            return array;
        }

        // Funcion que genera arreglo de notas dinamicos y diferenciados

        public static double[] addCalifications(int lim) // lim => cantidad de notas (T1, T2, ... Tx)
        {
            int value;
            double[] array = new double[lim];

            if (lim != 0)
            {

                Console.WriteLine("---------------------------------");
                Console.WriteLine("       NOTAS DEL ESTUDIANTE      ");
                Console.WriteLine("---------------------------------\n");

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("Nota T{0}: ", i + 1);

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    value = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Gray;

                    array[i] = value;

                    if (i == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nNotas actualizadas al estudiante.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            return array;
        }

        // Funcion que calcula el promedio de notas para un estudiante

        public static double calAverage(double[] arr) // 20 18 20 20 -> length = 4, total = 78, average = 78/4 = 19.5
        {
            double total = 0;
            double average;

            for (int i = 0; i < arr.Length; i++)
            {
                total = arr[i] + total;
            }

            average = total / arr.Length;

            return average;
        }
    }
}
