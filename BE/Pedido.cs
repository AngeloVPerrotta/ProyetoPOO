using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Pedido
    {
        //Atributos: idPedido, producto(o código), cantidad, fechaPedido, fechaProbableEntrega, costoUnitario o costoTotal, proveedor, empleadoResponsable, estado(pendiente, recibido, cancelado).
        //Métodos: calcularCostoTotal(), cambiarEstado(...).

        public int idPedido { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public int FechaPedido { get; set; }
        public int FechaProbableEntrega { get; set; }
        public int CostoTotal { get; set; }
        public string Proveedor { get; set; }
        public string EmpleadoResponsable { get; set; }
        public string Estado { get; set; }

        public Pedido(int idpedido, int producto, int cantidad, int fechapedido, int fechaprobableentrega, int costototal, string proveedor, string empleadoresponsable, string estado)
        {
            idPedido = idpedido;
            Producto = producto;
            Cantidad = cantidad;
            FechaPedido = fechapedido;
            FechaProbableEntrega = fechaprobableentrega;
            CostoTotal = costototal;
            Proveedor = proveedor;
            EmpleadoResponsable = empleadoresponsable;
            Estado = estado;
        }

        //Metodo 
        //public string CalcularCostoTotal()
        //{
        //  return $"Id pedido: {idPedido}, Producto: {Producto}, Cantidad: {Cantidad}, Fecha de pedido: {FechaPedido}, Fecha probable de entrega: {FechaProbableEntrega}, Costo: {CostoTotal}"; 
        //}

    }
}
