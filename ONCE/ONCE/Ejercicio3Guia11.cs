using System;
using System.IO;

namespace ONCE
{
    //------------------UNICAES------------------
    //---Facultad de Ingenería y Arquitectura---
    //--INGENIERÍA EN DESARROLLO DE SOFTWARE--
    //-Última fecha de modificación: 19.11.19
    //-------Luis Adrián Alfonzo Morán-------
    class Ejercicio3Guia11
    {
        static void Main(string[] args)
        {
            int size = 20 + 9 + 16 + 4;
            FileStream nameStream;
            BinaryWriter fileBinary;
            int option;
            try
            {
                do
                {
                    nameStream = new FileStream("student.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fileBinary = new BinaryWriter(nameStream);
                    BinaryReader fileReader = new BinaryReader(nameStream);
                    int numberSize = Convert.ToInt32(Math.Ceiling((decimal)nameStream.Length / size));
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Universidad Católica de El Salvador");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("[1] Agregar alumno");
                        Console.WriteLine("[2] Mostrar alumnos");
                        Console.WriteLine("[3] Buscar alumno");
                        Console.WriteLine("[4] Salir");
                        Console.WriteLine();
                        if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4)
                        {
                            switch (option)
                            {
                                case 1:
                                    try
                                    {
                                        Console.Clear();
                                        numberSize = Convert.ToInt32(Math.Ceiling((decimal)nameStream.Length / size));
                                        fileBinary.BaseStream.Seek(numberSize * size, SeekOrigin.Begin);
                                        Console.WriteLine("Información");
                                        Console.Write("¿Cuál es su carnet? ");
                                        string id = Console.ReadLine();
                                        if (id.Length > 9)
                                            id = id.Substring(0, 9);
                                        else
                                            id.PadRight(9, ' ');
                                        Console.Write("¿Cuál es su nombre? ");
                                            string name = Console.ReadLine();
                                        if (name.Length > 20)
                                            name = name.Substring(0, 20);
                                        else
                                            name.PadRight(20, ' ');
                                        Console.Write("¿Cuántos años tiene? ");
                                            int age = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("¿Cuál es su C.U.M.? ");
                                            decimal cum = Convert.ToDecimal(Console.ReadLine());
                                        fileBinary.Write(id);
                                        fileBinary.Write(name);
                                        fileBinary.Write(age);
                                        fileBinary.Write(cum);
                                        Console.WriteLine();
                                        Console.WriteLine("Datos agregados satisfactoriamente...");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        bool answer;
                                        do
                                        {
                                            answer = false;
                                            Console.Clear();
                                            Console.WriteLine("[1] Todos los alumnos");
                                            Console.WriteLine("[2] Buscar por CUM");
                                            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 2)
                                            {
                                                Console.Clear();
                                                switch (option)
                                                {
                                                    case 1:
                                                        try
                                                        {
                                                            numberSize = Convert.ToInt32(Math.Ceiling((decimal)nameStream.Length / size));
                                                            fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                                                            Console.Clear();
                                                            Console.WriteLine("Información de los estudiantes");
                                                            Console.WriteLine("================================================================");
                                                            Console.WriteLine("{0, -4} {1, -9} {2, -20} {3, -10} {4, -3}",
                                                                "No", "Carnet", "Nombre", "Edad", "CUM");
                                                            Console.WriteLine("================================================================");
                                                            int number = 1;

                                                            do
                                                            {
                                                                string id = fileReader.ReadString();
                                                                string name = fileReader.ReadString();
                                                                int age = fileReader.ReadInt32();
                                                                decimal cum = fileReader.ReadDecimal();
                                                                Console.Write("{0, -5}", number);
                                                                Console.Write("{0, -10}", id);
                                                                Console.Write("{0, -21}", name);
                                                                Console.Write("{0, -11}", age + " años");
                                                                Console.Write("{0, -4}", cum.ToString("N1"));
                                                                Console.WriteLine();
                                                                fileReader.BaseStream.Seek(number * size, SeekOrigin.Begin);
                                                                number++;
                                                            } while (true);
                                                        }
                                                        catch (Exception) { }
                                                        break;
                                                    case 2:
                                                        try
                                                        {
                                                            Console.Clear();
                                                            Console.Write("¿En cuánto a CUM con cuánto se basará la busqueda? ");
                                                            decimal findCUM = Convert.ToDecimal(Console.ReadLine());
                                                            numberSize = Convert.ToInt32(Math.Ceiling((decimal)nameStream.Length / size));
                                                            fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                                                            Console.Clear();
                                                            Console.WriteLine("Información de los estudiantes");
                                                            Console.WriteLine("================================================================");
                                                            Console.WriteLine("{0, -4} {1, -9} {2, -20} {3, -10} {4, -3}",
                                                                "No", "Carnet", "Nombre", "Edad", "CUM");
                                                            Console.WriteLine("================================================================");
                                                            int number = 1, numbertwo = 1;
                                                            decimal cum;
                                                            do
                                                            {
                                                                string id = fileReader.ReadString();
                                                                string name = fileReader.ReadString();
                                                                int age = fileReader.ReadInt32();
                                                                cum = fileReader.ReadDecimal();
                                                                if (findCUM == cum)
                                                                {
                                                                    Console.Write("{0, -5}", numbertwo);
                                                                    Console.Write("{0, -10}", id);
                                                                    Console.Write("{0, -21}", name);
                                                                    Console.Write("{0, -11}", age + " años");
                                                                    Console.Write("{0, -4}", cum.ToString("N1"));
                                                                    Console.WriteLine();
                                                                    numbertwo++;
                                                                }
                                                                fileReader.BaseStream.Seek(number * size, SeekOrigin.Begin);
                                                                number++;
                                                            } while (findCUM != cum && true);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("No se encuentra con el CUM específico...");
                                                        }
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Deben ser valores que comprendan de 1 a 2...");
                                                answer = true;
                                            }
                                        } while (answer == true);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }
                                    break;
                                case 3:
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("¿Con qué carnet se realizará la busqueda?");
                                        string id = Console.ReadLine();
                                        numberSize = Convert.ToInt32(Math.Ceiling((decimal)nameStream.Length / size));
                                        fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                                        int number = 1;
                                        string idtwo;
                                        do
                                        {
                                            idtwo = fileReader.ReadString();
                                            string name = fileReader.ReadString();
                                            int age = fileReader.ReadInt32();
                                            decimal cum = fileReader.ReadDecimal();
                                            if (id == idtwo)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Existe un match...");
                                                Console.WriteLine();
                                                Console.WriteLine("Ésta es la información que se encontró: ");
                                                Console.WriteLine();
                                                Console.WriteLine("Carnet: " + idtwo);
                                                Console.WriteLine("Nombre: " + name);
                                                Console.WriteLine("Edad: " + age + " años");
                                                Console.WriteLine("CUM: " + cum.ToString("N1"));
                                            }
                                            fileReader.BaseStream.Seek(number * size, SeekOrigin.Begin);
                                            number++;
                                        } while (id != idtwo && true);
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("No se encuentra con el carnet específico...");
                                    }
                                    break;
                            }
                            if (option != 4)
                            {
                            }
                            Console.Clear();
                        }
                    } while (option != 4);
                    Console.ReadKey();
                    fileBinary.Close();
                    fileReader.Close();
                } while (option != 4);
            }
            catch (Exception)
            {
            }
        }
    }
}

