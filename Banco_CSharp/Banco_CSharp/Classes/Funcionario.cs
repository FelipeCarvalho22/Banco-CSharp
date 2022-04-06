using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    public abstract class Funcionario : Usuario
    {
        public static int TotalFuncionariosCriados { get; private set; }

        private int _matricula = 1000;
        public int Matricula { get; private set; }

        public Funcionario(string cpf, string nascimento) : base(cpf, nascimento)
        {
            Matricula = _matricula + TotalFuncionariosCriados;
            TotalFuncionariosCriados++;
        }
    }
}
