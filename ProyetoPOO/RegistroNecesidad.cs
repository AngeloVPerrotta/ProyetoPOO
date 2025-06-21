using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class RegistroNecesidad
    {
        public int IdRegistro { get; set; }
        public Producto Producto { get; set; }
        public int CantidadRequerida { get; set; }
        public DateTime FechaDeteccion { get; set; }
        public EstadoNecesidad Estado { get; set; }

        // Constructor
        public RegistroNecesidad(int idRegistro, Producto producto, int cantidadRequerida, DateTime fechaDeteccion, EstadoNecesidad estado)
        {
            IdRegistro = idRegistro;
            Producto = producto;
            CantidadRequerida = cantidadRequerida;
            FechaDeteccion = fechaDeteccion;
            Estado = estado;
        }

        // Enumeración para el estado de la necesidad
        public enum EstadoNecesidad
        {
            PendienteDePedido,
            PedidoRealizado
        }

    }
}
