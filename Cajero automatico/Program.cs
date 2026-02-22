using System;
using System.Threading.Tasks;

namespace ISW123_2023_0715
{
    public class SaldoInsuficienteException_0715 : Exception
    {
        public SaldoInsuficienteException_0715(string mensaje) : base(mensaje) { }
    }

    class Program
    {
        public static event Action<string> OnTransaccionCompletada;

        static async Task Main(string[] args)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("Julian Vazquez - Matrícula: 2023-0715");
            Console.WriteLine("Sistema ATM Banco Popular - Iniciado");
            Console.WriteLine("=======================================");

            OnTransaccionCompletada += (mensaje) => Console.WriteLine($"[NOTIFICACIÓN]: {mensaje}");

            try
            {
                // Llamadas asíncronas
                await ProcesarTransaccionAsync("Consulta de Balance");
                await ProcesarTransaccionAsync("Transferencia ACH");

                Console.WriteLine("\nVerificando fondos para retiro...");
                throw new SaldoInsuficienteException_0715("Fondos insuficientes en la cuenta.");
            }
            catch (SaldoInsuficienteException_0715 ex)
            {
                Console.WriteLine($"\n[ERROR]: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }

        static async Task ProcesarTransaccionAsync(string tipo)
        {
            await Task.Delay(750); // El tiempo exacto que pide el Banco Popular
            OnTransaccionCompletada?.Invoke($"{tipo} finalizada con éxito.");
        }


    }

}