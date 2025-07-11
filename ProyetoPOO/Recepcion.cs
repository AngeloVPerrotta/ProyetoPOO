using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    internal class Recepcion
    {
        public string Proveedor { get; set; }
        public string Remito { get; set; }
        public string Empleado { get; set; }
        public int Cajas { get; set; }
        public DateTime HoraLlegada { get; set; }

        public string ToCsv()
        {
            return $"{Proveedor},{Remito},{Empleado},{Cajas},{HoraLlegada}";
        }

        public static Recepcion FromCsv(string linea)
        {
            var partes = linea.Split(',');
            return new Recepcion
            {
                Proveedor = partes[0],
                Remito = partes[1],
                Empleado = partes[2],
                Cajas = int.Parse(partes[3]),
                HoraLlegada = DateTime.Parse(partes[4])
            };
        }
    }
}
