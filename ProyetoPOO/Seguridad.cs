using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyetoPOO
{
    public class Seguridad
    {
        public string PoliticaContrasenas { get; set; } // Ejemplo: "Mínimo 6 caracteres, una mayúscula, un número"
        public int IntentosPermitidos { get; set; }
        private Dictionary<string, int> intentosFallidos; // clave: usuario, valor: intentos

        // Constructor
        public Seguridad(string politica, int intentosPermitidos)
        {
            PoliticaContrasenas = politica;
            IntentosPermitidos = intentosPermitidos;
            intentosFallidos = new Dictionary<string, int>();
        }

        //faltarían los metodos

        public static string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // devuelve en minúsculas
            }
        }
    }

    

    public static class EncriptadorUsuarios
    {


        public static void EncriptarArchivoUsuarios(string rutaOriginal, string rutaDestino)
        {
            if (!File.Exists(rutaOriginal))
            {
                MessageBox.Show("No se encontró el archivo de usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lineas = File.ReadAllLines(rutaOriginal);
            if (lineas.Length == 0)
            {
                MessageBox.Show("El archivo de usuarios está vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (StreamWriter writer = new StreamWriter(rutaDestino, false))
            {
                writer.WriteLine(lineas[0]); // Escribe el encabezado

                foreach (var linea in lineas.Skip(1))
                {
                    var partes = linea.Split(',');
                    if (partes.Length == 3)
                    {
                        string usuario = partes[0].Trim();
                        string clavePlano = partes[1].Trim();
                        string rol = partes[2].Trim();

                        string claveEncriptada = Seguridad.EncriptarSHA256(clavePlano);
                        writer.WriteLine($"{usuario},{claveEncriptada},{rol}");
                    }
                }
            }

            MessageBox.Show("Archivo encriptado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
