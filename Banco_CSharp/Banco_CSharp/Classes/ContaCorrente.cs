using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    public class ContaCorrente : Conta
    {
        private int _digitoVerificador = Conta.TotalContasCriadas;
        public int DigitoVerificador 
        {
            get 
            { 
                return _digitoVerificador; 
            }
        }

        public ContaCorrente(Cliente titular, int numeroAgencia, bool criarPoupanca) : base(titular, numeroAgencia, criarPoupanca)
        {
            if (criarPoupanca == true)
            {
                ContaPoupanca contaPoupanca = new ContaPoupanca(titular, numeroAgencia, false, this);
            }
        }
    }
}
