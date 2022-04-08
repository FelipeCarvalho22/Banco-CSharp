using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_CSharp.Classes;

namespace Banco_CSharp.Classes
{
    public class Gerente : Funcionario
    {
        public Gerente(string cpf, string nascimento) : base(cpf, nascimento)
        {
            //Nenhuma implantação!
        }

        public static bool CriarCliente(List<Cliente> listaCliente, string cpf, string dataNascimento)
        {
            listaCliente.Add(new Cliente(cpf, dataNascimento));
            return true;
        }
        public static bool CriarConta(List<ContaCorrente> listaContaCorrente, Cliente cliente, int numeroAgencia, bool criarPoupanca)
        {
            listaContaCorrente.Add(new ContaCorrente(cliente, numeroAgencia, criarPoupanca));
            return true;
        }
    }
}
