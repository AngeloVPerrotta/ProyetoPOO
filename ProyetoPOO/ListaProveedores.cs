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
        private void EliminarEnPos(NodoListaProv nuevonodo, int pos) 
        { 
            //if (dataGridViewProv.SelectedRows.Count > 0) 
            //{
            //    foreach (DataGridViewRow fila in dataGridViewProv.SelectedRows) 
            //    {
            //        dataGridViewProv.Rows.RemoveAt(fila.Index);
            //    }
            //}
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
