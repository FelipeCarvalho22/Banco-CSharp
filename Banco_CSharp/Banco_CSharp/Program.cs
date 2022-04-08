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
            var listaContasCorrentes = new List<ContaCorrente>();

            Console.WriteLine("Bem vindo ao Banco C# - Seu banco no prompt de comando");

            if (Funcionario.TotalFuncionariosCriados == 0)
            {
                Console.WriteLine("Este é o primeiro acesso ao sistema, não temos nenhum funcionario nem cliente, vamos criar seu usuario!");
                Console.WriteLine();

                Console.WriteLine("Por favor digite seu CPF");
                string cpf = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Agora nos diga sua data de nascimento no formato DD/MM/AAAA");
                string dataNascimento = Console.ReadLine();
                var gerenteGeral = new Gerente(cpf, dataNascimento);

                Console.WriteLine("Otimo, nos fale mais sobre você");
                Console.WriteLine("Por favor digite seu nome:");
                gerenteGeral.Nome = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Vamos confirmar sua ficha");
                Console.WriteLine($"{gerenteGeral.Nome} você é o Gerente Geral do Banco C#");
                Console.WriteLine($"Sua idade é de {gerenteGeral.Idade} e seu CPF é o numero {gerenteGeral.CPF}");
                Console.WriteLine($"Anote seu numero de matricula: {gerenteGeral.Matricula}");

            }

            Console.ReadLine();
        }
    }
}
