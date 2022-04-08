using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    public class Caixa : Funcionario
    {
        public Caixa(string cpf, string nascimento) : base(cpf, nascimento)
        {
            //Nenhuma Implementação
        }
        public static bool Saque(ContaCorrente contaCorrente, float valor)
        {
            contaCorrente.Saque(valor);
            return true;
        }
        public static bool Transferencia(ContaCorrente contaCorrenteOrigem, ContaCorrente contaCorrenteDestino, float valor)
        {
            contaCorrenteOrigem.Transferencia(contaCorrenteDestino, valor);
            return true;
        }
    }
}
