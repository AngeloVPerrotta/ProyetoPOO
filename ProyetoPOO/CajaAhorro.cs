using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyetoPOO
{
    public class CajaAhorro : Cuenta
    {
        public decimal TipoInteres { get; set; } // Porcentaje anual, ej: 0.03 para 3%
        public List<string> Movimientos { get; set; }


        // Constructor
        public CajaAhorro(int idCuenta, decimal saldo, Persona titular, decimal tipoInteres)
            : base(idCuenta, saldo, titular)
        {
            TipoInteres = tipoInteres;
            Movimientos = new List<string>();
        }

        //METODOS HEREDADOS DE LA CLASE CUENTE
        //NOSE SI ESTAN BIEN PERO LOS TENEMOS QUE IMPLEMENTAR OBLIGATORIAMENTE POR LA HERENCIA
        public override void Depositar(decimal monto)
        {
            Saldo += monto;
            Movimientos.Add($"Depósito: +${monto} | Nuevo saldo: ${Saldo}");
        }

        public override void Retirar(decimal monto)
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                Movimientos.Add($"Extracción: -${monto} | Nuevo saldo: ${Saldo}");
            }
            else
            {
                Movimientos.Add($"Intento de extracción fallido: saldo insuficiente.");
                throw new InvalidOperationException("Saldo insuficiente.");
            }
        }


        // Método adicional: aplicar interés (simulación)
        public void AplicarInteresMensual()
        {
            decimal interes = Saldo * (TipoInteres / 12); // interés mensual simple
            Saldo += interes;
            Movimientos.Add($"Interés aplicado: +${Math.Round(interes, 2)} | Nuevo saldo: ${Math.Round(Saldo, 2)}");
        }

    }
}
