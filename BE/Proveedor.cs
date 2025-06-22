using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Rubro { get; set; }
        public string DatosContacto { get; set; }

        public Proveedor(int idProveedor, string nombre, string rubro, string datosContacto)
        {
            IdProveedor = idProveedor;
            Nombre = nombre;
            Rubro = rubro;
            DatosContacto = datosContacto;
        }

        //Métodos: quizá validar datos, toString().

    }
}
