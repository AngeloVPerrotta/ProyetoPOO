<<<<<<< HEAD
﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

class Program
{
    // Función para hashear con MD5, copiada de tu código de login
    private static string HashMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }

    static void Main(string[] args)
    {
        // Asegúrate de que este archivo exista en la misma carpeta que el ejecutable
        string archivoCrudo = "usuarios.csv";
        string archivoHasheado = "usuario_encriptado.csv";

        try
        {
            if (!File.Exists(archivoCrudo))
            {
                Console.WriteLine($"Error: No se encontró el archivo '{archivoCrudo}'.");
                Console.ReadKey();
                return;
            }

            // Leemos todas las líneas del archivo, saltando la cabecera
            var lineasCrudas = File.ReadAllLines(archivoCrudo).Skip(1);

            StringBuilder sb = new StringBuilder();
            // Añadimos la cabecera al nuevo archivo
            sb.AppendLine("usuario,contraseña,rol");

            foreach (var linea in lineasCrudas)
            {
                var partes = linea.Split(',');
                if (partes.Length == 3)
                {
                    string usuario = partes[0].Trim();
                    string contraseñaCruda = partes[1].Trim();
                    string rol = partes[2].Trim();

                    // Hasheamos la contraseña
                    string contraseñaHasheada = HashMD5(contraseñaCruda);

                    // Construimos la nueva línea con el hash
                    sb.AppendLine($"{usuario},{contraseñaHasheada},{rol}");
                }
            }

            // Escribimos el contenido en el nuevo archivo
            File.WriteAllText(archivoHasheado, sb.ToString());

            Console.WriteLine($"Archivo '{archivoHasheado}' generado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        Console.ReadKey();
    }
=======
﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

class Program
{
    // Función para hashear con MD5, copiada de tu código de login
    private static string HashMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }

    static void Main(string[] args)
    {
        // Asegúrate de que este archivo exista en la misma carpeta que el ejecutable
        string archivoCrudo = "usuarios.csv";
        string archivoHasheado = "usuario_encriptado.csv";

        try
        {
            if (!File.Exists(archivoCrudo))
            {
                Console.WriteLine($"Error: No se encontró el archivo '{archivoCrudo}'.");
                Console.ReadKey();
                return;
            }

            // Leemos todas las líneas del archivo, saltando la cabecera
            var lineasCrudas = File.ReadAllLines(archivoCrudo).Skip(1);

            StringBuilder sb = new StringBuilder();
            // Añadimos la cabecera al nuevo archivo
            sb.AppendLine("usuario,contraseña,rol");

            foreach (var linea in lineasCrudas)
            {
                var partes = linea.Split(',');
                if (partes.Length == 3)
                {
                    string usuario = partes[0].Trim();
                    string contraseñaCruda = partes[1].Trim();
                    string rol = partes[2].Trim();

                    // Hasheamos la contraseña
                    string contraseñaHasheada = HashMD5(contraseñaCruda);

                    // Construimos la nueva línea con el hash
                    sb.AppendLine($"{usuario},{contraseñaHasheada},{rol}");
                }
            }

            // Escribimos el contenido en el nuevo archivo
            File.WriteAllText(archivoHasheado, sb.ToString());

            Console.WriteLine($"Archivo '{archivoHasheado}' generado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error: {ex.Message}");
        }

        Console.ReadKey();
    }
>>>>>>> 987af3b3741e1925632725c9f66613b7db2151aa
}