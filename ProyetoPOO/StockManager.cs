using System;

public static class StockManager
{
    public static int CajasTotales { get; private set; }

    public static event Action<int> StockActualizado;

    public static void AgregarCajas(int cantidad)
    {
        CajasTotales += cantidad;
        StockActualizado?.Invoke(CajasTotales);
    }

    public static bool DescontarCajas(int cantidad)
    {
        if (CajasTotales >= cantidad)
        {
            CajasTotales -= cantidad;
            StockActualizado?.Invoke(CajasTotales);
            return true;
        }
        return false;
    }

    public static void InicializarStock(int cantidad)
    {
        CajasTotales = cantidad;
        StockActualizado?.Invoke(CajasTotales);
    }
}