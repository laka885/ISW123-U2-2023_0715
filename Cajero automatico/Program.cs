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
        static async Task Main(string[] args)
        {
            Console.WriteLine("Julian Vazquez - Matrícula: 2023-0715");
            Console.WriteLine("Sistema ATM Banco Popular - Iniciado");
        }


    }

}