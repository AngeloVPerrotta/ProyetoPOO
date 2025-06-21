using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Empleado : Persona
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }  // Se puede encriptar más adelante para mas seguridad
        public string Rol { get; set; }    // Ejemplo: "Administrador" FALTA CREAR LOS ROLES

        // Constructor
        public Empleado(int idEmpleado, string nombre, string usuario, string clave, string rol)
        {
            IdEmpleado = idEmpleado;
            Nombre = nombre;
            Usuario = usuario;
            Clave = clave;
            Rol = rol;
        }

        // Métodos adicionales pueden incluir validaciones, autenticación, etc.
    }
}
