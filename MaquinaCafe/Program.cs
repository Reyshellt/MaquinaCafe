using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCafe
{
    internal class Program
    {
        // Cantidad inicial de ingredientes
        static int vasosPequenos = 2;
        static int vasosMedianos = 5;
        static int vasosGrandes = 5;
        static int azucarDisponible = 10; // cucharadas
        static int cafeDisponible = 30; // onzas de café

        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido a la máquina dispensadora de café!");

            // Bucle continuo hasta que se agoten los recursos
            while (true)
            {
                if (cafeDisponible == 0)
                {
                    Console.WriteLine("No hay suficiente café disponible.");
                    break;
                }

                if (vasosPequenos == 0 && vasosMedianos == 0 && vasosGrandes == 0)
                {
                    Console.WriteLine("No hay vasos disponibles.");
                    break;
                }

                if (azucarDisponible == 0)
                {
                    Console.WriteLine("No hay suficiente azúcar disponible.");
                    break;
                }

                // Selección del tamaño de vaso
                int tamanoVaso = SeleccionarTamanoVaso();
                if (tamanoVaso == 0)
                {
                    Console.WriteLine("No hay vasos disponibles del tamaño seleccionado.");
                    continue;
                }

                // Selección de la cantidad de azúcar
                int cucharadasAzucar = SeleccionarAzucar();
                if (cucharadasAzucar > azucarDisponible)
                {
                    Console.WriteLine("No hay suficiente azúcar disponible.");
                    continue;
                }

                // Verificación de café disponible
                if (tamanoVaso > cafeDisponible)
                {
                    Console.WriteLine("No hay suficiente café disponible.");
                    continue;
                }

                // Dispensar café
                RecogerVaso(tamanoVaso, cucharadasAzucar);

                // Preguntar si el usuario desea otro café
                Console.WriteLine("\n¿Deseas otro café? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();

                if (respuesta != "S")
                {
                    Console.WriteLine("Gracias por usar la máquina dispensadora de café. ¡Hasta luego!");
                    break;
                }
            }
        }

        static int SeleccionarTamanoVaso()
        {
            Console.WriteLine("\nSelecciona el tamaño de vaso:");
            Console.WriteLine("1. Pequeño (3 Oz)");
            Console.WriteLine("2. Mediano (5 Oz)");
            Console.WriteLine("3. Grande (7 Oz)");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            int tamano = 0;

            switch (opcion)
            {
                case "1":
                    if (vasosPequenos > 0)
                    {
                        tamano = 3;
                        vasosPequenos--;
                    }
                    break;
                case "2":
                    if (vasosMedianos > 0)
                    {
                        tamano = 5;
                        vasosMedianos--;
                    }
                    break;
                case "3":
                    if (vasosGrandes > 0)
                    {
                        tamano = 7;
                        vasosGrandes--;
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            return tamano;
        }

        static int SeleccionarAzucar()
        {
            Console.Write("\n¿Cuántas cucharadas de azúcar quieres? (0-5): ");
            int cucharadasAzucar;
            if (!int.TryParse(Console.ReadLine(), out cucharadasAzucar) || cucharadasAzucar < 0 || cucharadasAzucar > 5)
            {
                Console.WriteLine("Cantidad inválida de azúcar. No se agregará azúcar.");
                cucharadasAzucar = 0;
            }
            return cucharadasAzucar;
        }

        static void RecogerVaso(int tamanoVaso, int cucharadasAzucar)
        {
            // Restar el café y el azúcar disponible
            cafeDisponible -= tamanoVaso;
            azucarDisponible -= cucharadasAzucar;

            Console.WriteLine("\n--- Recogiendo tu café ---");
            Console.WriteLine($"Tamaño del vaso: {tamanoVaso} Oz");
            Console.WriteLine($"Cucharadas de azúcar: {cucharadasAzucar}");
            Console.WriteLine("¡Disfruta tu café!");
        }

    }
}
