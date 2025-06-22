using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class RRHH : Persona
    {
        public string Departamento { get; set; }
        public bool PermisoGestionEmpleados { get; set; }

        public RRHH(int id, string nombre, string apellidos, string datosContacto,
                    string departamento, bool permisoGestionEmpleados)
            : base(id, nombre, apellidos, datosContacto)
        {
            Departamento = departamento;
            PermisoGestionEmpleados = permisoGestionEmpleados;
        }
    
        //falta crear metodos

    }
}
