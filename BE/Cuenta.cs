using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public abstract class Cuenta
    {
        public int IdCuenta { get; set; }
        public decimal Saldo { get; set; }
        public Persona Titular { get; set; }  

     
        public Cuenta(int idCuenta, decimal saldo, Persona titular)
        {
            IdCuenta = idCuenta;
            Saldo = saldo;
            Titular = titular;
        }

        // Métodos abstractos que deben implementarse en las clases hijas
        public abstract void Depositar(decimal monto); //FALTA COMPLETAR
        public abstract void Retirar(decimal monto); //FALTA COMPLETAR

        // Método opcional común a todas las cuentas
        public virtual string VerEstado() //FALTA COMPLETAR Y VERIFICAR
        {
            return $"Cuenta N° {IdCuenta} - Titular: {Titular.NombreCompleto()} - Saldo: ${Saldo}";
        }
    }

}
