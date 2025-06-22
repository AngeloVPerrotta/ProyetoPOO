using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DatosContacto { get; set; }

        // Constructor
        public Persona(int id, string nombre, string apellidos, string datosContacto)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            DatosContacto = datosContacto;
        }

        // Método opcional para mostrar nombre completo
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
}

