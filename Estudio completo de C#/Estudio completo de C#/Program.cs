
// ============================================
// ESTRUCTURA DE EJEMPLO
// ============================================
struct Coordenada
{
    public int X;
    public int Y;
}

// ============================================
// PROGRAMA PRINCIPAL
// ============================================
class Program
{
    static void Main()
    {
        ArchivoHelper.Inicializar("Pruebas de Tipos en C#");

        ArchivoHelper.AgregarTitulo("Prueba de Tipos de Valor (struct)");
        ArchivoHelper.AgregarLinea("Este ejemplo demuestra cómo los tipos de valor se copian de forma independiente al asignarlos.");
        ArchivoHelper.AgregarLinea();

        Coordenada punto1 = new Coordenada { X = 10, Y = 20 };

        ArchivoHelper.AgregarTitulo("Estado Inicial", 3);
        ArchivoHelper.AgregarLinea($"- `punto1`: X={punto1.X}, Y={punto1.Y}");
        ArchivoHelper.AgregarLinea();

        // Al asignar, se copia todo el valor. 'punto2' es una copia independiente.
        Coordenada punto2 = punto1;

        // Modificamos la copia
        punto2.X = 99;

        ArchivoHelper.AgregarTitulo("Estado Final (después de modificar punto2)", 3);
        ArchivoHelper.AgregarLinea($"- `punto1`: X={punto1.X}, Y={punto1.Y} *(No se vio afectado)*");
        ArchivoHelper.AgregarLinea($"- `punto2`: X={punto2.X}, Y={punto2.Y} *(Modificado)*");
        ArchivoHelper.AgregarLinea();

        // Agregar separador para la siguiente prueba
        ArchivoHelper.AgregarSeparador();

        Console.WriteLine($"✅ Resultados guardados exitosamente en 'salida.md'");
    }
}