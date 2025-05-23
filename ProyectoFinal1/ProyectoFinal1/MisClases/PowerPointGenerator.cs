using System;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using OfficeCore = Microsoft.Office.Core;

namespace InvestigadorAI
{
    public class PowerPointGenerator
    {
        public void CrearPresentacion(string tema, string contenido, string rutaSalida)
        {
            Console.WriteLine("Creando presentación PowerPoint...");

            //var pptApp = new PowerPoint.Application { Visible = OfficeCore.MsoTriState.msoFalse };
            PowerPoint.Presentation presentation = null;
            var pptApp = new PowerPoint.Application(); // <- sin establecer Visible
            try
            {
                // Aquí es donde se evita que se abra PowerPoint
                presentation = pptApp.Presentations.Add(OfficeCore.MsoTriState.msoFalse);

                var slide1 = presentation.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutTitle);
                slide1.Shapes[1].TextFrame.TextRange.Text = "Investigación: " + tema;
                slide1.Shapes[2].TextFrame.TextRange.Text = "Resumen generado por IA";

                var slide2 = presentation.Slides.Add(2, PowerPoint.PpSlideLayout.ppLayoutText);
                slide2.Shapes[1].TextFrame.TextRange.Text = "Contenido";
                slide2.Shapes[2].TextFrame.TextRange.Text = contenido;

                presentation.SaveAs(rutaSalida);
                Console.WriteLine("Presentación guardada en: " + rutaSalida);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la presentación: " + ex.Message);
            }
            finally
            {
                presentation?.Close();
                pptApp.Quit();
            }
        }
    }
}