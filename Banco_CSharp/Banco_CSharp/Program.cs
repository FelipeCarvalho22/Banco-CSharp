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
            var listaGerentes = new List<Gerente>();
            var listaCaixa = new List<Caixa>();

            Console.WriteLine("Bem vindo ao Banco C# - Seu banco no prompt de comando");

            Inicio:

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
                Console.WriteLine("Aperte qualquer tecla para continuar!");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Dando continuidade, você precissa de no minimo mais um funcinario para ser o caixa, vamos adiciona-lo ao sistema!");
                Console.WriteLine("Por favor digite o CPF do colaborador");
                string cpfCaixa = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Agora nos diga a data de nascimento no formato DD/MM/AAAA");
                string dataNascimentoCaixa = Console.ReadLine();
                listaCaixa.Add(new Caixa(cpfCaixa, dataNascimentoCaixa));
                Console.WriteLine("Por favor, nos informe o nome deste colaborador:");
                listaCaixa[0].Nome = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Vamos confirmar a ficha do colaborador Caixa!");
                Console.WriteLine($"{listaCaixa[0].Nome} você é o primeiro colaborador do Banco C#");
                Console.WriteLine($"Sua idade é de {listaCaixa[0].Idade} e seu CPF é o numero {listaCaixa[0].CPF}");
                Console.WriteLine($"Por favor anote a sua matricula: {listaCaixa[0].Matricula}");

                Console.WriteLine();
                Console.WriteLine("Obrigado, reinicie o sistema para finalizar, aperte qualquer tecla");
                Console.ReadLine();
                Console.Clear();

                goto Inicio;
            }
            else
            {
                Console.WriteLine("Por favor nos informe quem esta acessando: 1-Gerente, 2-Caixa, 3-Cliente ou qualquer outro numero para sair.");
                int opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Bem vindo ao sistema da gerencia!");
                        goto Fim;
                    case 2:
                        Console.WriteLine("Bem vindo ao sistema do caixa!");
                        goto Fim;
                    case 3:
                        Console.WriteLine("Bem vindo a área do cliente!");
                        goto Fim;
                }
            }

            Fim:
            Console.ReadLine();
        }
    }
}
