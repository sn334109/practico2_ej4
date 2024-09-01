﻿namespace practico2_ej4
{
    using Dominio;
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaCliente cuentaSanti = new ("Santiago Neira", 0, TCuenta.CajaAhorro, TMoneda.UY, 533333);
            CuentaCliente cuentaFernando = new ("Fernando Caram", 5000, TCuenta.CajaAhorro, TMoneda.USD, 355555);
            
            Console.WriteLine("Cuenta Santiago Neira: ", cuentaSanti);
            
            Console.WriteLine("Cuenta Fernando Caram: ", cuentaFernando);

            //Pruebas de movimientos
            cuentaSanti.depositarDinero(40000, TMoneda.UY);
            //cuentaSanti.depositarDinero(50000, TMoneda.UY);

            cuentaFernando.depositarDinero(2000, TMoneda.USD);
            //cuentaSanti.retirarDinero(10000, TMoneda.USD);


            Console.WriteLine("Cuenta Santiago Neira: ", cuentaSanti);

            Console.WriteLine("Cuenta Fernando Caram: ", cuentaFernando);

        }
    }
}
