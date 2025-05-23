using System;
using System.IO;

namespace InvestigadorAI
{
    public class FileManager
    {
        private readonly string _basePath = @"C:\\Users\\joseg\\OneDrive\\Escritorio\\Programacion 1\\Proyecto Final 1\\Documentos Generados";

        public FileManager()
        {
            Console.WriteLine("FileManager inicializado en: " + _basePath);
        }

        public string CrearCarpetaTema(string tema)
        {
            var folderName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{SanitizarNombre(tema)}";
            var fullPath = Path.Combine(_basePath, folderName);

            Directory.CreateDirectory(fullPath);
            Console.WriteLine("Carpeta creada: " + fullPath);
            return fullPath;
        }

        public string ObtenerRutaWord(string folderPath, string tema)
        {
            return Path.Combine(folderPath, SanitizarNombre(tema) + ".docx");
        }

        public string ObtenerRutaPpt(string folderPath, string tema)
        {
            return Path.Combine(folderPath, SanitizarNombre(tema) + ".pptx");
        }

        private string SanitizarNombre(string nombre)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                nombre = nombre.Replace(c, '_');
            }
            return nombre;
        }
    }
}
