using System;
using FundamentosCSHARP_6.Models;

namespace FundamentosCSHARP_6
{
    class Program
    {
        static void Main(string[] args)
        {
            CervezaBD cervezaBD = new CervezaBD();

            while (true)
            {
                Console.WriteLine("----MENÚ----");
                Console.WriteLine("1. Registrar cerveza");
                Console.WriteLine("2. Eliminar cerveza");
                Console.WriteLine("3. Editar cerveza");
                Console.WriteLine("4. Mostrar lista de cervezas");
                Console.WriteLine("5. Salir");
                Console.WriteLine("-------------");

                Console.WriteLine("Seleccione una opcion: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        RegistrarCerveza(cervezaBD);
                        break;
                    case "2":
                        EliminarCerveza(cervezaBD);
                        break;
                    case "3":
                        EditarCerveza(cervezaBD);
                        break;
                    case "4":
                        MostrarCervezas(cervezaBD);
                        break;
                    case "5":
                        Console.WriteLine("¡Hasta Luego!");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida. Intente de nuevo.");
                        break;

                }
                Console.WriteLine();
            }
        }
        static void RegistrarCerveza(CervezaBD cervezaBD)
        {
            Console.Write("---- Registro de Cerveza ----");

            Console.Write("Ingrese el nombre de la cerveza: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la marca de la cerveza: ");
            string marca = Console.ReadLine();

            Console.Write("Ingrese el contenido de alcohol de la cerveza: ");
            int alcohol = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el contenido de la cerveza: ");
            int cantidad = int.Parse(Console.ReadLine());

            Cerveza cerveza = new Cerveza(cantidad, nombre);
            cerveza.Marca = marca;
            cerveza.Alcohol = alcohol;

            cervezaBD.Add(cerveza);

            Console.WriteLine("Cerveza registrada exitosamente...");
        }
        static void EliminarCerveza(CervezaBD cervezaBD)
        {
            Console.WriteLine("--- Eliminacion de cerveza ---");
            Console.WriteLine("Ingrese el ID de la  cerveza que desea eliminar: ");
            int id = int.Parse(Console.ReadLine());

            cervezaBD.Delete(id);
            Console.WriteLine("Cerveza eliminada exitosamente.");
        }
        static void EditarCerveza(CervezaBD cervezaBD)
        {
            Console.WriteLine("--- Edicion de cerveza ---");

            Console.WriteLine("Ingrese el ID de la cerveza que desea editar: ");
            int id = int.Parse(Console.ReadLine());

            Cerveza cerveza = cervezaBD.Get().Find(c=> c.Id == id);
            if (cerveza != null)
            {
                Console.Write("Ingrese el nuevo nombre de la cerveza: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese la nueva marca de la cerveza: ");
                string marca = Console.ReadLine();

                Console.Write("Ingrese el nuevo contenido de alcohol de la cerveza: ");
                int alcohol = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la nueva cantidad de cervezas: ");
                int cantidad = int.Parse(Console.ReadLine());

                cerveza.Nombre = nombre;
                cerveza.Marca = marca;
                cerveza.Alcohol = alcohol;
                cerveza.Cantidad = cantidad;

                cervezaBD.Edit(cerveza, id);

                Console.WriteLine("Cerveza editada exitosamente...");
            }
            else
            {
                Console.WriteLine("No se encontro una cerveza con el ID especificado.");
            }

        }
        static void MostrarCervezas(CervezaBD cervezaBD)
        {
            Console.WriteLine("--- Lista de cervezas ---");
            List<Cerveza> cervezas = cervezaBD.Get();

            foreach (Cerveza cerveza in cervezas)
            {
                Console.WriteLine($"ID: {cerveza.Id}");
                Console.WriteLine($"Nombre: {cerveza.Nombre}");
                Console.WriteLine($"Marca: {cerveza.Marca}");
                Console.WriteLine($"Alcohol: {cerveza.Alcohol}");
                Console.WriteLine($"Cantidad: {cerveza.Cantidad}");
                Console.WriteLine("-------------------------------");

            }
        }
    }
}