using System;
using System.IO;

namespace PruebasCSharp
{
    /// <summary>
    /// Estructura para demostrar tipos de valor
    /// </summary>
    public struct Coordenada
    {
        public int X;
        public int Y;

        public override string ToString() => $"X={X}, Y={Y}";
    }

    /// <summary>
    /// Clase para demostrar tipos de referencia
    /// </summary>
    public class Jugador
    {
        public string Nombre { get; set; }
        public int Puntuacion { get; set; }

        public override string ToString() => $"Nombre={Nombre}, Puntuación={Puntuacion}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            int salida = args.Length > 0 && int.TryParse(args[0], out int arg) ? arg : 0;

            try
            {
                EjecutarEjemplo(salida);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al ejecutar el ejemplo: {ex.Message}");
            }
        }

        /// <summary>
        /// Ejecuta el ejemplo seleccionado
        /// </summary>
        private static void EjecutarEjemplo(int opcion)
        {
            switch (opcion)
            {
                case 0:
                    EjemploVariableTipoValor();
                    break;
                case 1:
                    EjemploVariableTipoReferencia();
                    break;
                case 2:
                    EjemploStackVsHeap();
                    break;
                default:
                    Console.WriteLine($"⚠️ Opción {opcion} no válida. Usando opción 0 por defecto.");
                    EjemploVariableTipoValor();
                    break;
            }
        }

        /// <summary>
        /// Ejemplo 0: Demuestra el comportamiento de tipos de valor (struct)
        /// </summary>
        private static void EjemploVariableTipoValor()
        {
            ArchivoHelper.Inicializar("Pruebas de Tipos en C#");
            ArchivoHelper.AgregarTitulo("Prueba de Tipos de Valor (struct)");
            ArchivoHelper.AgregarLinea("Este ejemplo demuestra cómo los tipos de valor se copian de forma independiente al asignarlos.");
            ArchivoHelper.AgregarLinea();

            Coordenada punto1 = new Coordenada { X = 10, Y = 20 };

            ArchivoHelper.AgregarTitulo("Estado Inicial", 3);
            ArchivoHelper.AgregarLinea($"- `punto1`: {punto1}");
            ArchivoHelper.AgregarLinea();

            // Al asignar, se copia todo el valor. 'punto2' es una copia independiente.
            Coordenada punto2 = punto1;

            // Modificamos la copia
            punto2.X = 99;

            ArchivoHelper.AgregarTitulo("Estado Final (después de modificar punto2)", 3);
            ArchivoHelper.AgregarLinea($"- `punto1`: {punto1} *(No se vio afectado)*");
            ArchivoHelper.AgregarLinea($"- `punto2`: {punto2} *(Modificado)*");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarSeparador();

            Console.WriteLine($"✅ Resultados guardados exitosamente en 'salida.md'");
        }

        /// <summary>
        /// Ejemplo 1: Demuestra el comportamiento de tipos de referencia (class)
        /// </summary>
        private static void EjemploVariableTipoReferencia()
        {
            ArchivoHelper.Inicializar("Pruebas de Tipos en C#");
            ArchivoHelper.AgregarTitulo("Prueba de Tipos de Referencia (class)");
            ArchivoHelper.AgregarLinea("Este ejemplo demuestra cómo los tipos de referencia comparten el mismo objeto en memoria.");
            ArchivoHelper.AgregarLinea();

            Jugador jugador1 = new Jugador { Nombre = "Ana", Puntuacion = 100 };

            ArchivoHelper.AgregarTitulo("Estado Inicial", 3);
            ArchivoHelper.AgregarLinea($"- `jugador1`: {jugador1}");
            ArchivoHelper.AgregarLinea();

            // Al asignar, se copia la REFERENCIA. Ambas apuntan al MISMO objeto.
            Jugador jugador2 = jugador1;

            // Modificamos a través de la segunda referencia
            jugador2.Nombre = "Beatriz";
            jugador2.Puntuacion = 250;

            ArchivoHelper.AgregarTitulo("Estado Final (después de modificar jugador2)", 3);
            ArchivoHelper.AgregarLinea($"- `jugador1`: {jugador1} *(¡Se vio afectado!)*");
            ArchivoHelper.AgregarLinea($"- `jugador2`: {jugador2}");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarSeparador();

            Console.WriteLine($"✅ Resultados guardados exitosamente en 'salida.md'");
        }

        /// <summary>
        /// Ejemplo 2: Demuestra la diferencia entre Stack y Heap
        /// </summary>
        private static void EjemploStackVsHeap()
        {
            ArchivoHelper.Inicializar("Pruebas de Tipos en C#");
            ArchivoHelper.AgregarTitulo("Stack vs Heap");
            ArchivoHelper.AgregarLinea("Este ejemplo muestra cómo los tipos de valor van al Stack y los de referencia al Heap.");
            ArchivoHelper.AgregarLinea();

            // Tipo de valor: todo en el Stack
            int numero = 42;
            ArchivoHelper.AgregarLinea($"- `int numero = {numero}` → Todo en el STACK");

            // Tipo de referencia: referencia en Stack, objeto en Heap
            Jugador jugador = new Jugador { Nombre = "Carlos", Puntuacion = 500 };
            ArchivoHelper.AgregarLinea($"- `Jugador jugador` → Referencia en STACK, objeto en HEAP");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarSeparador();

            Console.WriteLine($"✅ Resultados guardados exitosamente en 'salida.md'");
        }
    }
}