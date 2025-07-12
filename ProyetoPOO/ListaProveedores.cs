using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyetoPOO
{
    internal class ListaProveedores
    {
        NodoListaProv primero;
        int cuantosnodos;
        private void Mostrar() 
        {
            
        }

        private void AgregarUltimo(NodoListaProv nuevonodo) 
        {
            if (primero == null)
            {
                primero = nuevonodo;
            }
            else 
            {
                NodoListaProv actual = primero;
                while (actual.Siguiente != null) 
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevonodo;
            }
            cuantosnodos++;
        }
        
    }
}
