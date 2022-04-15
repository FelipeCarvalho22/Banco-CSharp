using Banco_CSharp.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_CSharp
{
    class Program
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
                InicioSistemas:

                Console.WriteLine("Por favor nos informe quem esta acessando: 1-Gerente, 2-Caixa, 3-Cliente ou qualquer outro numero para sair.");
                try
                {
                    int opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Bem vindo ao sistema da gerencia!");
                            SitemaGerente(listaClientes, listaContasCorrentes);
                            goto InicioSistemas;
                        case 2:
                            Console.WriteLine("Bem vindo ao sistema do caixa!");
                            SistemaCaixa(listaClientes, listaContasCorrentes);
                            goto InicioSistemas;
                        case 3:
                            Console.WriteLine("Bem vindo a área do cliente!");
                            goto InicioSistemas;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Opa, digite um numero por favor!");
                }
            }

            Console.ReadLine();
        }

        public static void SitemaGerente(List<Cliente> clientes, List<ContaCorrente> contaCorrentes)
        {
            Inicio:

            Console.WriteLine("Por favor nos informe sua ação: 1-Criar Cliente, 2-Criar Conta ou qualquer outro numero para sair.");
            try
            {
                int opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Por favor informe o CPF do Cliente:");
                        string cpf = Console.ReadLine();
                        Console.WriteLine("Agora a data de nascimento do cliente:");
                        string dataNascimento = Console.ReadLine();

                        Gerente.CriarCliente(clientes, cpf, dataNascimento);

                        Console.WriteLine("Agora nos informe o nome do Cliente:");
                        string nome = Console.ReadLine();
                        int posicao = clientes.Count() - 1;

                        clientes[posicao].Nome = nome;

                        Console.WriteLine("Tecle enter para confirmarmos os dados");
                        Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine($"O Cliente {clientes[posicao].Nome} é o nosso {Cliente.TotalClientesCriados} cliente criado, seu CPF é {clientes[posicao].CPF}");
                        Console.WriteLine($"Sua idade é de {clientes[posicao].Idade} e seu ID é o numero {clientes[posicao].Id}");
                        Console.WriteLine();

                        goto Inicio;

                    case 2:
                        Console.WriteLine("Por favor, nos informe o numero da Agencia");
                        int agencia = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Agora, o cliente deseja ter uma conta poupança? Se não digite False, se sim True");
                        bool criarPoupanca = Boolean.Parse(Console.ReadLine());
                        Console.WriteLine("Por fim nos informe o ID do Cliente");
                        int idCliente = Int32.Parse(Console.ReadLine());

                        Gerente.CriarConta(contaCorrentes, clientes[idCliente], agencia, criarPoupanca);

                        Console.WriteLine("Tecle enter para confirmarmos os dados");
                        Console.ReadLine();
                        Console.Clear();

                        int posicaoConta = contaCorrentes.Count() - 1;

                        Console.WriteLine($"A Conta Corrente Numero {contaCorrentes[posicaoConta].Numero}-{contaCorrentes[posicaoConta].DigitoVerificador} da Agencia {contaCorrentes[posicaoConta].Agencia} foi criada");
                        Console.Write($"O cliente Titular é {contaCorrentes[posicaoConta].Titular.Nome} e");
                        if (criarPoupanca == true)
                        {
                            Console.WriteLine($"foi criada a Poupança {ContaPoupanca.TotalContasCriadas}");
                        }
                        else
                        {
                            Console.WriteLine("não foi criada nenhuma poupança");
                        }
                        Console.WriteLine();

                        goto Inicio;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Opa, digite um numero por favor");
            }
        }
        public static void SistemaCaixa(List<Cliente> clientes, List<ContaCorrente> contaCorrentes)
        {
            Console.WriteLine("Deseja listar todos os clientes e contas correntes?");
            bool listar = bool.Parse(Console.ReadLine());
            if (listar)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"Nome: {cliente.Nome} - CPF: {cliente.CPF} - ID: {cliente.Id}");
                }
                Console.WriteLine();
                foreach (var conta in contaCorrentes)
                {
                    Console.WriteLine($"Agencia: {conta.Agencia} - Conta: {conta.Numero}-{conta.DigitoVerificador} - Saldo: {conta.Saldo} - Titular: {conta.Titular.Nome}");
                }
            }

            Inicio:

            Console.WriteLine("Informe o numero da conta corrente:");
            try
            {
                string numeroContaString = Console.ReadLine();
                string numeroContaSubstring = numeroContaString.Substring(5);
                int numeroConta = Convert.ToInt32(numeroContaSubstring);
                ContaCorrente contaPrincipal = contaCorrentes[numeroConta];

                Console.Clear();
                Console.WriteLine($"Estamos na Conta Corrente numero: {contaPrincipal.Numero}-{contaPrincipal.DigitoVerificador}");
                Console.WriteLine($"O Titular da conta é: {contaPrincipal.Titular.Nome}");

                Console.WriteLine("Escolha a operação: 1-Verificar Saque, 2-Realizar Transferencia");
                try
                {
                    int opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Digite o valor do saque: ");
                            float valor = float.Parse(Console.ReadLine());
                            bool transacaoOK = Caixa.Saque(contaPrincipal, valor);
                            if (transacaoOK)
                            {
                                Console.WriteLine($"Operação de saque foi realizada com sucesso no valor de: {valor}, o saldo da conta ficou no valor de: {contaPrincipal.Saldo}");
                            }
                            else
                            {
                                Console.WriteLine("Falha na operação");
                            }
                            goto Inicio;

                        case 2:
                            Console.WriteLine("Digite o numero da Conta Corrente a ser transferido o valor");
                            try
                            {
                                string numeroContaTransferString = Console.ReadLine();
                                string numeroContaTransferSubstring = numeroContaTransferString.Substring(5);
                                int numeroContaTransfer = Convert.ToInt32(numeroContaTransferSubstring);
                                ContaCorrente contaTransfer = contaCorrentes[numeroContaTransfer];

                                Console.Clear();
                                Console.Write($"O Cliente {contaPrincipal.Titular.Nome} deseja transferir para a conta corrente {contaTransfer.Numero}-{contaTransfer.DigitoVerificador} o valor de:");
                                float valorTransfer = float.Parse(Console.ReadLine());
                                bool transacaoTransferOK = Caixa.Transferencia(contaPrincipal, contaTransfer, valorTransfer);

                                if (transacaoTransferOK)
                                {
                                    Console.WriteLine($"A operação de transferencia da Conta {contaPrincipal.Numero}-{contaPrincipal.DigitoVerificador} para a " +
                                        $"Conta {contaTransfer.Numero}-{contaTransfer.DigitoVerificador} no valor de {valorTransfer} foi realizada com sucesso.");
                                }
                                else
                                {
                                    Console.WriteLine("Falha na operação");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Opa, vamos tentar novamente!");
                            }
                            goto Inicio;
                    }
                }
                catch (Exception)
                {
                Console.WriteLine("Opa, vamos tentar novamente!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Opa, vamos tentar novamente! O formato é XXXX-XX");
            }
        }
    }
}
