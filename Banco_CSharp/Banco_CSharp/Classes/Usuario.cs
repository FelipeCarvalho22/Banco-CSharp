using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    public abstract class Usuario
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
            DateTime agora = DateTime.Now;
            Calendar calendario = CultureInfo.InvariantCulture.Calendar;
            int anoAtual = calendario.GetYear(agora);

            string anoNascimentoSubString = nascimento.Substring(6);
            int anoNascimento = Convert.ToInt32(anoNascimentoSubString);

            int idade = anoAtual - anoNascimento;
            return idade;
        }
    }
}
