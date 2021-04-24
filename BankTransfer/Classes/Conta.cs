using System;
namespace DotNet.BankTransfer
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}
        
        //Criação do metodo construtor: metodo que é chamado na criação do objecto (instancia da class)
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar (double valorSaque)
        {
            //Validação de saldo do cliente
            if(this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente !!!!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo); //formatação composta
            return true;
        }

        public void Depositar (double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine ("Saldo atual da Conta do {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir (double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar (valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno ="";
            retorno += "Tipo Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}