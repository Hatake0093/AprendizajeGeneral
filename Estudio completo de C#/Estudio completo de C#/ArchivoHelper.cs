public static class ArchivoHelper
{
    private static readonly string NombreArchivo = "salida.md";

    /// <summary>
    /// Escribe contenido al archivo de salida, agregándolo al final sin borrar lo anterior.
    /// </summary>
    public static void Escribir(string contenido)
    {
        File.AppendAllText(NombreArchivo, contenido);
    }

    /// <summary>
    /// Agrega un título de sección al archivo.
    /// </summary>
    public static void AgregarTitulo(string titulo, int nivel = 2)
    {
        string hashes = new string('#', nivel);
        Escribir($"{hashes} {titulo}\n\n");
    }

    /// <summary>
    /// Agrega un separador visual entre secciones.
    /// </summary>
    public static void AgregarSeparador()
    {
        Escribir("\n---\n\n");
    }

    /// <summary>
    /// Agrega texto simple con salto de línea.
    /// </summary>
    public static void AgregarLinea(string texto = "")
    {
        Escribir($"{texto}\n");
    }

    /// <summary>
    /// Inicializa el archivo con un encabezado general (útil para empezar un nuevo documento).
    /// </summary>
    public static void Inicializar(string tituloDocumento)
    {
        string contenido = $"# {tituloDocumento}\n\n*Generado el {DateTime.Now:dd/MM/yyyy HH:mm:ss}*\n\n---\n\n";
        File.WriteAllText(NombreArchivo, contenido); // WriteAllText sobrescribe todo
    }
}
