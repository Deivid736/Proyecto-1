using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace InvestigadorAI
{
    public class WordGenerator
    {
        private readonly string _templatePath;

        public WordGenerator(string templatePath)
        {
            _templatePath = templatePath;
            Console.WriteLine("WordGenerator inicializado con la plantilla: " + templatePath);
        }

        public void CrearDocumento(string tema, string contenido, string rutaSalida)
        {
            Console.WriteLine("Creando documento Word...");
            var wordApp = new Word.Application();
            Word.Document doc = null;

            try
            {
                doc = wordApp.Documents.Open(_templatePath);

                ReemplazarMarcador(doc, "TEMA", tema);
                ReemplazarMarcador(doc, "CONTENIDO", contenido);

                doc.SaveAs2(rutaSalida);
                Console.WriteLine("Documento Word guardado en: " + rutaSalida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el documento Word: " + ex.Message);
            }
            finally
            {
                doc?.Close(false);
                wordApp.Quit(false);
            }
        }

        private void ReemplazarMarcador(Word.Document doc, string marcador, string texto)
        {
            if (doc.Bookmarks.Exists(marcador))
            {
                var range = doc.Bookmarks[marcador].Range;
                range.Text = texto;

                // Al reemplazar el texto, se pierde el marcador. Lo volvemos a agregar.
                doc.Bookmarks.Add(marcador, range);
            }
            else
            {
                Console.WriteLine($"Marcador '{marcador}' no encontrado en la plantilla.");
            }
        }
    }
}