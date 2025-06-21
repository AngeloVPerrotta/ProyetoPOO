using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class CuentaCorriente : Cuenta
    {
        public decimal LimiteDescubierto { get; set; }
        public List<string> Movimientos { get; set; }

        // Constructor
        public CuentaCorriente(int idCuenta, decimal saldo, Persona titular, decimal limiteDescubierto)
            : base(idCuenta, saldo, titular)
        {
            LimiteDescubierto = limiteDescubierto;
            Movimientos = new List<string>();
        }

        public override void Depositar(decimal monto) //falta verificar que funcione
        {
            Saldo += monto;
            Movimientos.Add($"Depósito: +${monto} | Nuevo saldo: ${Saldo}");
        }

        public override void Retirar(decimal monto) //falta verificar que funcione
        {
            if (Saldo - monto >= -LimiteDescubierto)
            {
                Saldo -= monto;
                Movimientos.Add($"Extracción: -${monto} | Nuevo saldo: ${Saldo}");
            }
            else
            {
                Movimientos.Add($"Intento de extracción fallido: -${monto} excede el límite.");
                throw new InvalidOperationException("Saldo insuficiente con límite de descubierto.");
            }
        }
    }

}
