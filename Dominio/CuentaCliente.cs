namespace Dominio
{
    public enum TCuenta
    { 
        CuentaCorriente,
        CajaAhorro
    }

    public enum TMoneda {
        USD,
        UY
    }
    public class CuentaCliente
    {
        string titular;
        decimal saldoActual;
        TCuenta tipo;
        TMoneda moneda;
        int nroCuenta;

        //get && set
        public string Titular { get => titular; set => titular = value; }
        public decimal SaldoActual { get => saldoActual; set => saldoActual = value; }
        public TCuenta Tipo { get => tipo; set => tipo = value; }
        public TMoneda Moneda { get => moneda; set => moneda = value; }
        public int NroCuenta { get => nroCuenta; set => nroCuenta = value; }

        //constructor vacio
        public CuentaCliente ()
        {
        }

        //constructor de asignación
        public CuentaCliente(string titular, decimal saldoActual, TCuenta tipo, TMoneda moneda, int nroCuenta)
        {
            this.titular = titular;
            this.saldoActual = saldoActual;
            this.tipo = tipo;
            this.moneda = moneda;
            this.nroCuenta = nroCuenta;
        }


        public bool depositarDinero(decimal montoDeposito, TMoneda tipoMoneda) 
        {
            decimal topeDeposito = -1;
            bool estadoDeposito = false;
            //TODO: validar que sea la misma moneda
            //TODO: validar que no supere el tope del tipo de moneda USD/UY
            if (topeDeposito >= montoDeposito)
            {
                //misma moneda ?
                if (tipoMoneda == moneda)
                {
                    if (tipoMoneda == TMoneda.UY)
                    {
                        topeDeposito = 50000;
                    }
                    else if (tipoMoneda == TMoneda.USD)
                    {
                        topeDeposito = 1000;
                    }

                    //validamos tope
                    if (montoDeposito <= topeDeposito && topeDeposito != -1)
                    {
                        saldoActual = saldoActual + montoDeposito;
                        estadoDeposito = true;
                        Console.WriteLine($"{titular.ToUpper()} deposito de {montoDeposito} Exitoso! \n");
                    }
                    else
                    {
                        Console.WriteLine("Error (deposito): el monto supera el tope de 50000 \n");
                    }
                }
                else
                {
                    Console.WriteLine("Error (deposito): Tipo de moneda invalido");
                }
                //exception
            }

            return estadoDeposito;
        }

        public bool retirarDinero(decimal montoRetiro, TMoneda tipoMoneda)
        {
            bool estadoRetiro = false;
            //TODO: validar que sea de la misma moneda
            //TODO: validar que no supere el tope
            //TODO: validar que exista ese saldo en la cuenta.

            //misma moneda ?
            if (tipoMoneda == moneda)
            {
                if (montoRetiro <= saldoActual)
                {
                    saldoActual = saldoActual - montoRetiro;
                    estadoRetiro = true;
                    Console.WriteLine($"{titular.ToUpper()} retiro de {montoRetiro} Exitoso! \n");
                }
                else 
                {
                    Console.WriteLine("Error (retiro): Tipo de moneda invalido");
                }
            }
            else
            { 
                    Console.WriteLine("Error (retiro): Tipo de moneda invalido");
            }


            return estadoRetiro;
        }


        // Mensaje de prueba
        public override string ToString()
        {
            return $"Titular Cuenta: {titular.ToString()} \n" +
                   $"{(tipo == TCuenta.CajaAhorro ? "[ CAJA AHORRO PESOS ]" : "[ CUENTA CORRIENTE ]")} \n" +
                   $"Saldo Disponible: {(moneda == TMoneda.USD ? "DOLARES" : "PESOS" )} {saldoActual} \n" +
                   $"Cuenta en: {(moneda == TMoneda.USD ? "DOLARES" : "PESOS")} \n" +
                   $"Número de cuenta: {nroCuenta} \n";
        }
    }
}
