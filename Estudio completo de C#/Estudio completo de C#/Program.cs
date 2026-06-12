using System.Diagnostics;

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
                case 3:
                    EjemploCamposDeValorEnClase();
                    break;
                case 4:
                    EjemploBenchmarkRendimiento();
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

        /// <summary>
        /// Ejemplo 3: Demuestra dónde se almacenan los campos de valor dentro de una clase
        /// </summary>
        private static void EjemploCamposDeValorEnClase()
        {
            ArchivoHelper.Inicializar("Ubicación en Memoria: Campos de Valor en Clases");

            ArchivoHelper.AgregarTitulo("¿Dónde viven los int dentro de una class?");
            ArchivoHelper.AgregarLinea("Respuesta: En el **HEAP**, junto con el resto del objeto.");
            ArchivoHelper.AgregarLinea();

            // Caso 1: int como variable local → STACK
            int vidaLocal = 100;
            ArchivoHelper.AgregarLinea($"### Caso 1: Variable local");
            ArchivoHelper.AgregarLinea($"```csharp");
            ArchivoHelper.AgregarLinea($"int vidaLocal = {vidaLocal};");
            ArchivoHelper.AgregarLinea($"```");
            ArchivoHelper.AgregarLinea($"📍 **Ubicación**: STACK (es una variable local del método)");
            ArchivoHelper.AgregarLinea();

            // Caso 2: int como campo de clase → HEAP
            Jugador jugador = new Jugador { Nombre = "Ana", Puntuacion = 500 };
            ArchivoHelper.AgregarLinea($"### Caso 2: Campo de una clase");
            ArchivoHelper.AgregarLinea($"```csharp");
            ArchivoHelper.AgregarLinea($"Jugador jugador = new Jugador {{ Nombre = \"Ana\", Puntuacion = 500 }};");
            ArchivoHelper.AgregarLinea($"```");
            ArchivoHelper.AgregarLinea($"📍 **Ubicación** del `int Puntuacion`: **HEAP** (vive dentro del objeto)");
            ArchivoHelper.AgregarLinea();

            // Caso 3: int dentro de un array → HEAP
            int[] numeros = new int[] { 1, 2, 3 };
            ArchivoHelper.AgregarLinea($"### Caso 3: Array de ints");
            ArchivoHelper.AgregarLinea($"```csharp");
            ArchivoHelper.AgregarLinea($"int[] numeros = new int[] {{ 1, 2, 3 }};");
            ArchivoHelper.AgregarLinea($"```");
            ArchivoHelper.AgregarLinea($"📍 **Ubicación**: **HEAP** (los arrays son tipos de referencia)");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarTitulo("Resumen Visual", 3);
            ArchivoHelper.AgregarLinea("```");
            ArchivoHelper.AgregarLinea("STACK:                    HEAP:");
            ArchivoHelper.AgregarLinea("┌─────────────┐          ┌──────────────────┐");
            ArchivoHelper.AgregarLinea("│vidaLocal=100│          │ Objeto Jugador   │");
            ArchivoHelper.AgregarLinea("└─────────────┘          │  ├─Nombre→\"Ana\" │");
            ArchivoHelper.AgregarLinea("                         │  └─Puntuacion=500│ ← ¡En Heap!");
            ArchivoHelper.AgregarLinea("┌─────────────┐          └──────────────────┘");
            ArchivoHelper.AgregarLinea("│numeros ────────────────→ Array [1,2,3]    │");
            ArchivoHelper.AgregarLinea("└─────────────┘          └──────────────────┘");
            ArchivoHelper.AgregarLinea("```");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarSeparador();

            Console.WriteLine($"✅ Resultados guardados exitosamente en 'salida.md'");
        }

        private static void EjemploBenchmarkRendimiento()
        {
            ArchivoHelper.Inicializar("Benchmark: Stack vs Heap - Rendimiento Real");

            ArchivoHelper.AgregarTitulo("Comparación de Rendimiento");
            ArchivoHelper.AgregarLinea("Vamos a crear 10 millones de objetos y medir el tiempo.");
            ArchivoHelper.AgregarLinea();

            const int cantidad = 10_000_000;
            Stopwatch sw = new Stopwatch();

            // ========================================
            // TEST 1: Struct (Stack)
            // ========================================
            sw.Start();
            for (int i = 0; i < cantidad; i++)
            {
                Coordenada c = new Coordenada { X = i, Y = i * 2 };
                // Simulamos algo de trabajo
                int resultado = c.X + c.Y;
            }
            sw.Stop();
            long tiempoStruct = sw.ElapsedMilliseconds;

            ArchivoHelper.AgregarTitulo("Test 1: Struct (Tipo de Valor)", 3);
            ArchivoHelper.AgregarLinea($"```csharp");
            ArchivoHelper.AgregarLinea($"for (int i = 0; i < {cantidad}; i++)");
            ArchivoHelper.AgregarLinea($"{{");
            ArchivoHelper.AgregarLinea($"    Coordenada c = new Coordenada {{ X = i, Y = i * 2 }};");
            ArchivoHelper.AgregarLinea($"    int resultado = c.X + c.Y;");
            ArchivoHelper.AgregarLinea($"}}");
            ArchivoHelper.AgregarLinea($"```");
            ArchivoHelper.AgregarLinea($"⏱️ **Tiempo: {tiempoStruct} ms**");
            ArchivoHelper.AgregarLinea($"📍 **Memoria: STACK** (asignación instantánea)");
            ArchivoHelper.AgregarLinea();

            // ========================================
            // TEST 2: Class (Heap)
            // ========================================
            sw.Restart();
            for (int i = 0; i < cantidad; i++)
            {
                Jugador j = new Jugador { Nombre = "Jugador" + i, Puntuacion = i * 2 };
                // Simulamos algo de trabajo
                int resultado = j.Puntuacion + j.Puntuacion;
            }
            sw.Stop();
            long tiempoClass = sw.ElapsedMilliseconds;

            ArchivoHelper.AgregarTitulo("Test 2: Class (Tipo de Referencia)", 3);
            ArchivoHelper.AgregarLinea($"```csharp");
            ArchivoHelper.AgregarLinea($"for (int i = 0; i < {cantidad}; i++)");
            ArchivoHelper.AgregarLinea($"{{");
            ArchivoHelper.AgregarLinea($"    Jugador j = new Jugador {{ Nombre = \"Jugador\" + i, Puntuacion = i * 2 }};");
            ArchivoHelper.AgregarLinea($"    int resultado = j.Puntuacion + j.Puntuacion;");
            ArchivoHelper.AgregarLinea($"}}");
            ArchivoHelper.AgregarLinea($"```");
            ArchivoHelper.AgregarLinea($"⏱️ **Tiempo: {tiempoClass} ms**");
            ArchivoHelper.AgregarLinea($"📍 **Memoria: HEAP** (asignación + GC)");
            ArchivoHelper.AgregarLinea();

            // ========================================
            // COMPARACIÓN
            // ========================================
            double ratio = (double)tiempoClass / tiempoStruct;

            ArchivoHelper.AgregarTitulo("Resultado", 3);
            ArchivoHelper.AgregarLinea($"| Tipo | Tiempo | Memoria |");
            ArchivoHelper.AgregarLinea($"|------|--------|---------|");
            ArchivoHelper.AgregarLinea($"| Struct | {tiempoStruct} ms | Stack |");
            ArchivoHelper.AgregarLinea($"| Class | {tiempoClass} ms | Heap |");
            ArchivoHelper.AgregarLinea();
            ArchivoHelper.AgregarLinea($"🚀 **El struct fue {ratio:F2}x más rápido**");
            ArchivoHelper.AgregarLinea();
            ArchivoHelper.AgregarLinea($"### ¿Por qué?");
            ArchivoHelper.AgregarLinea($"- El struct se asigna en el Stack (movimiento de puntero)");
            ArchivoHelper.AgregarLinea($"- La class se asigna en el Heap (búsqueda de espacio + GC)");
            ArchivoHelper.AgregarLinea($"- Con 10 millones de objetos, el GC trabaja mucho más");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarSeparador();

            Console.WriteLine($"✅ Benchmark completado. Struct: {tiempoStruct}ms, Class: {tiempoClass}ms");
            Console.WriteLine($"✅ Resultados guardados en 'salida.md'");
        }

        /// <summary>
        /// Ejemplo 5: Uso de punteros en C# (Requiere código no seguro)
        /// </summary>
        private static unsafe void EjemploPunteros()
        {
            ArchivoHelper.Inicializar("El Mundo de los Punteros en C#");
            ArchivoHelper.AgregarTitulo("Manipulación Directa de Memoria");
            ArchivoHelper.AgregarLinea("Advertencia: Esto omite la seguridad de tipos de C#.");
            ArchivoHelper.AgregarLinea();

            // ---------------------------------------------------------
            // CASO 1: Variable local en el Stack
            // ---------------------------------------------------------
            int numero = 42;

            // & obtiene la dirección de memoria de 'numero'
            int* punteroANumero = &numero;

            ArchivoHelper.AgregarTitulo("1. Variable Local (Stack)", 3);
            ArchivoHelper.AgregarLinea($"- Valor original: `{numero}`");
            // Convertimos la dirección a un número largo para mostrarla en Hexadecimal
            ArchivoHelper.AgregarLinea($"- Dirección de memoria: `0x{(long)punteroANumero:X}`");

            // * desreferencia: accede al valor en esa dirección y lo modifica
            *punteroANumero = 100;

            ArchivoHelper.AgregarLinea($"- Valor después de modificar vía puntero: `{numero}`");
            ArchivoHelper.AgregarLinea();

            // ---------------------------------------------------------
            // CASO 2: Array en el Heap (Requiere 'fixed')
            // ---------------------------------------------------------
            int[] arreglo = { 10, 20, 30 };

            ArchivoHelper.AgregarTitulo("2. Array en el Heap (Usando 'fixed')", 3);
            ArchivoHelper.AgregarLinea($"- Array original: `[{string.Join(", ", arreglo)}]`");

            // 'fixed' congela el array en memoria para que el GC no lo mueva
            fixed (int* punteroAlArray = arreglo)
            {
                // Leemos el primer elemento (índice 0)
                int primerElemento = *punteroAlArray;

                // Modificamos el segundo elemento (índice 1) usando aritmética de punteros
                // (puntero + 1) avanza 4 bytes (tamaño de un int)
                *(punteroAlArray + 1) = 99;

                ArchivoHelper.AgregarLinea($"- Primer elemento leído vía puntero: `{primerElemento}`");
                ArchivoHelper.AgregarLinea($"- Se modificó el índice 1 a `99` usando aritmética de punteros.");
            } // Aquí termina el 'fixed', el GC ya puede mover el array si lo necesita.

            ArchivoHelper.AgregarLinea($"- Array final: `[{string.Join(", ", arreglo)}]`");
            ArchivoHelper.AgregarLinea();

            ArchivoHelper.AgregarSeparador();

            Console.WriteLine("✅ Ejemplo de punteros guardado en 'salida.md'");
        }
    }
}
}