using InvestigadorAI;
using System.Windows.Forms.Design;
using System.IO;
using System.Drawing;
namespace ProyectoFinal1
{
    public partial class MainForm : Form
    {
        private readonly ApiService _apiService;
        private readonly DatabaseService _dbService;
        private readonly WordGenerator _wordGen;
        private readonly PowerPointGenerator _pptGen;
        private readonly FileManager _fileManager;


        public MainForm()
        {
            InitializeComponent();

            _apiService = new ApiService("");
            _dbService = new DatabaseService("Server=DEIVIDGR\\SQLEXPRESS;Database=InvestigacionesAI;Integrated Security=True; TrustServerCertificate=True;");

            _wordGen = new WordGenerator(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plantilla.docx"));
            _pptGen = new PowerPointGenerator();
            _fileManager = new FileManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnInvestigar_Click(object sender, EventArgs e)
        {

            string tema = txtTema.Text.Trim();
            if (string.IsNullOrWhiteSpace(tema))
            {
                MessageBox.Show("Por favor, ingrese un tema.");
                return;
            }

            btnInvestigar.Enabled = false;
            lblEstado.Text = "Investigando...";

            try
            {
                string prompt = $"Investiga sobre: {tema}";
                string resultado = await _apiService.ConsultarTemaAsync(prompt);

                // Mostrar resultado en el formulario con formato
                txtResultado.Clear();
                txtResultado.SelectionColor = Color.DarkBlue;
                txtResultado.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
                txtResultado.AppendText("Tema: " + tema + Environment.NewLine + Environment.NewLine);

                txtResultado.SelectionColor = Color.Black;
                txtResultado.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
                txtResultado.AppendText(resultado);

                // Guardar en base de datos
                _dbService.GuardarResultado(tema, prompt, resultado);

                // Guardar documentos
                string carpeta = _fileManager.CrearCarpetaTema(tema);
                string rutaWord = _fileManager.ObtenerRutaWord(carpeta, tema);
                string rutaPpt = _fileManager.ObtenerRutaPpt(carpeta, tema);

                _wordGen.CrearDocumento(tema, resultado, rutaWord);
                _pptGen.CrearPresentacion(tema, resultado, rutaPpt);

                lblEstado.Text = "Documentos generados correctamente.";
                MessageBox.Show("Proceso completado.");
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error";
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            finally
            {
                btnInvestigar.Enabled = true;
            }

        }
    }
}
