using System;
using System.IO;

namespace ONCE
{
    //------------------UNICAES------------------
    //---Facultad de Ingenería y Arquitectura---
    //--INGENIERÍA EN DESARROLLO DE SOFTWARE--
    //-Última fecha de modificación: 19.11.19
    //-------Luis Adrián Alfonzo Morán-------
    class Program
    {
        static void Main(string[] args)
        {
            Escribir();
        }
        static void Escribir()
        {
            try
            {
                Console.Write("Nombre: ");
                string name = Console.ReadLine();
                Console.Write("Teléfono: ");
                int phone = Convert.ToInt32(Console.ReadLine());
                Console.Write("Fecha de Nacimiento: ");
                int birth = Convert.ToInt32(Console.ReadLine());
                Console.Write("Salario: $");
                decimal money = Convert.ToDecimal(Console.ReadLine());
                FileStream nombreStream = new FileStream("empleados.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter binarioo = new BinaryWriter(nombreStream);
                binarioo.Write(name);
                binarioo.Write(phone);
                binarioo.Write(birth);
                binarioo.Write(money);
                nombreStream.Close();
                binarioo.Close();
                Console.WriteLine();
                Console.WriteLine("El empleado fue almacenado correctamente.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un problema con el archivo binario...");
            }
        }
    }
}