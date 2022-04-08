using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    public class ContaPoupanca : Conta
    {
        public int DigitoPoupanca { get; private set; }

        public ContaPoupanca(Cliente titular, int numeroAgencia, bool criarPoupanca, ContaCorrente contaCorrente) : base(titular, numeroAgencia, criarPoupanca)
        {
            this.DigitoPoupanca = contaCorrente.DigitoVerificador;
        }
    }
}
