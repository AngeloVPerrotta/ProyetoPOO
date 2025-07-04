using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Mensaje
    {
        public int IdMensaje { get; set; }
        public string Remitente { get; set; }       // Usuario o rol del que envía
        public string Destinatario { get; set; }     // Usuario o rol del que recibe
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public bool Leido { get; set; }

        public Mensaje(int id, string remitente, string destinatario, string contenido, DateTime fecha, bool leido)
        {
            IdMensaje = id;
            Remitente = remitente;
            Destinatario = destinatario;
            Contenido = contenido;
            Fecha = fecha;
            Leido = leido;
        }

        public override string ToString()
        {
            return $"{IdMensaje};{Remitente};{Destinatario};{Contenido};{Fecha};{Leido}";
        }
        //random
        public static Mensaje DesdeLinea(string linea)
        {
            var partes = linea.Split(';');
            return new Mensaje(
                int.Parse(partes[0]),
                partes[1],
                partes[2],
                partes[3],
                DateTime.Parse(partes[4]),
                bool.Parse(partes[5])
            );
        }
    }

}
