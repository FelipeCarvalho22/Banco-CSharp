using Banco_CSharp.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listaClientes = new List<Cliente>();

            Gerente.CriarCliente(listaClientes, "399.800.288-07", "12/02/1993");

            Console.WriteLine(listaClientes[0].Id);
            Console.WriteLine(listaClientes[0].Idade);

            DateTime agora = DateTime.Now;
            Calendar calendario = CultureInfo.InvariantCulture.Calendar;
            int anoAtual = calendario.GetYear(agora);
            Console.WriteLine(anoAtual);

            Console.ReadLine();
        }
    }
}
