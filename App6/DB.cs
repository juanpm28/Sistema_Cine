using System;
using System.Threading.Tasks;
using MySqlConnector;

namespace DB
{
    public class Consultas
    {
        static string connStr = "Server=136.115.174.9;Port=3306;Database=Venta_cine;User=equipodin;Password='R24uZ2aa:';";

        public static async Task ObtenerPeliculasAsync()
        {
            try
            {
                using var conn = new MySqlConnection(connStr);
                await conn.OpenAsync();

                using var cmd = new MySqlCommand("SELECT * FROM Pelicula;", conn);
                using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"{reader["idPelicula"]} - {reader["nombre"]}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}