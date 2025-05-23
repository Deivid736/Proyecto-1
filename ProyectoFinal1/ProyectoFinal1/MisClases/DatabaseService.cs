using System;
using System.Data.SqlClient;
using Dapper;

namespace InvestigadorAI
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
            Console.WriteLine("DatabaseService inicializado con la cadena de conexión proporcionada.");
        }

        public void GuardarResultado(string tema, string prompt, string resultado)
        {
            Console.WriteLine("Iniciando la operación de guardado en la base de datos...");
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"
                    INSERT INTO Resultados (Tema, Prompt, Resultado, Fecha)
                    VALUES (@Tema, @Prompt, @Resultado, GETDATE())";

                Console.WriteLine("Ejecutando consulta SQL para insertar datos...");
                connection.Execute(sql, new
                {
                    Tema = tema,
                    Prompt = prompt,
                    Resultado = resultado
                });
                Console.WriteLine("Datos insertados correctamente en la base de datos.");
            }
        }
    }
}