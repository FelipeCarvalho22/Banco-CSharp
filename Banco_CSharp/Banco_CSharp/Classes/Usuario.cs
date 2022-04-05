using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    abstract class Usuario
    {
        public string Nome { get; set; }
        public string CPF { get; }
        public string DataNascimento { get; private set; }
        public int Idade { get; private set; }

        public Usuario(string cpf, string nascimento)
        {
            CPF = cpf;

            DataNascimento = nascimento;
            Idade = CalculoIdade(this.DataNascimento);
        }

        private int CalculoIdade(string nascimento)
        {
            DateTime dataHora = new DateTime();
            int anoAtual = dataHora.Year;

            string anoNascimentoString = nascimento.Remove(6);
            int anoNascimento = Int32.Parse(anoNascimentoString);

            int idade = anoNascimento - anoAtual;
            return idade;
        }
    }
}
