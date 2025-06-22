using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Recepcion
    {
        public int IdRecepcion { get; set; }
        public Pedido PedidoAsociado { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int CantidadRecibida { get; set; }
        public Empleado EmpleadoResponsable { get; set; }

        public Recepcion(int idRecepcion, Pedido pedidoAsociado, DateTime fechaRecepcion, int cantidadRecibida, Empleado empleadoResponsable)
        {
            IdRecepcion = idRecepcion;
            PedidoAsociado = pedidoAsociado;
            FechaRecepcion = fechaRecepcion;
            CantidadRecibida = cantidadRecibida;
            EmpleadoResponsable = empleadoResponsable;
        }


        //revisar metodos en el drive de tasklist :)
    }
}
