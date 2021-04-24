using System;
using System.Collections.Generic;

namespace DotNet.BankTransfer
{

    class Program
    {

        static List<Conta> listaContas = new List<Conta>();

        static void Main(string [] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario!= "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarContas();
                    break;                
                    case "2":
                    InserirConta();
                    break;
                    case "3":
                    Transferir();
                    break;
                    case "4":
                    SacarConta(); break;
                    case "5":
                    Depositar(); break;
                    case "L":
                    Console.Clear(); break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

             Console.WriteLine("Obrigado por utilizar os nossos Serviços ....");
             Console.ReadLine();
            
        }

        private static void Transferir()
        {
            Console.Write("Digite o Nº da Conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nº da Conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o Nº da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void SacarConta()
        {
            Console.Write("Digite o Nº da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Levantado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.WriteLine(" Inserir Nova Conta ");
            Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                        saldo: entradaSaldo, 
                                        credito: entradaCredito, 
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada !!");
                return;
            }

            for(int i = 0; i< listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);

            }
        }
        

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine("== Seja Bem-vindo ao BANKTRANSFER !!! ==");
            Console.WriteLine("========================================");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 ------- Listar Contas");
            Console.WriteLine("2 ------- Inserir Nova Conta");
            Console.WriteLine("3 ------- Tranferir");
            Console.WriteLine("4 ------- Sacar");
            Console.WriteLine("5 ------- Depositar");
            Console.WriteLine("L ------- Limpar Tela");
            Console.WriteLine("X ------- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }    
    }

}
    
