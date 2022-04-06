using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp.Classes
{
    public class Cliente : Usuario
    {
        public static int TotalClientesCriados { get; private set; }
        public int Id { get; private set; }

        public Cliente(string cpf, string nascimento) : base(cpf, nascimento)
        {
            Id = TotalClientesCriados;
            TotalClientesCriados++;
        }
    }
}
