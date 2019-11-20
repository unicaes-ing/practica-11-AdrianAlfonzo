using System;
using System.IO;

namespace ONCE
{
    //------------------UNICAES------------------
    //---Facultad de Ingenería y Arquitectura---
    //--INGENIERÍA EN DESARROLLO DE SOFTWARE--
    //-Última fecha de modificación: 19.11.19
    //-------Luis Adrián Alfonzo Morán-------
    class Ejercicio2Guia11
    {
        static void Main(string[] args)
        {
            Leer();
        }
        static void Leer()
        {
            try
            {
                FileStream nameStream = new FileStream("empleados.dat", FileMode.Open, FileAccess.Read);
                BinaryReader nameBinary = new BinaryReader(nameStream);
                string name = nameBinary.ReadString();
                int phone = nameBinary.ReadInt32();
                int birth = nameBinary.ReadInt32();
                decimal money = nameBinary.ReadDecimal();
                Console.WriteLine("Datos del empleado: ");
                Console.WriteLine();
                Console.WriteLine("Nombre: {0}", name);
                Console.WriteLine("Télefono: {0}", phone);
                Console.WriteLine("Fecha de Nacimiento: {0}", birth);
                Console.WriteLine("Salario ${0}", money);
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un problema con el archivo binario...");
            }
        }
    }
}
