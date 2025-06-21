using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Producto(string codigo, string nombre, int stockActual, int stockMinimo, decimal precioUnitario)
        {
            Codigo = codigo;
            Nombre = nombre;
            StockActual = stockActual;
            StockMinimo = stockMinimo;
            PrecioUnitario = precioUnitario;
        } 
        
        //Métodos: reducirStock(cantidad), aumentarStock(cantidad), verificarBajoStock(), etc.
    }
}
