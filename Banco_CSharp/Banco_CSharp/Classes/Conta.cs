using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco_CSharp.Classes;

namespace Banco_CSharp.Classes
{
    public abstract class Conta
    {
        public Cliente Titular { get; private set; } 
        public int Agencia { get; private set; }
        public int Numero { get; private set; }

        private float _saldo = 50;
        public float Saldo
        {
            get
            {
                return _saldo;
            }
        }
        public static int TotalContasCriadas { get; private set; }

        public Conta(Cliente titular, int numeroAgencia, bool criarPoupanca)
        {
            Titular = titular;
            Agencia = numeroAgencia;

            Numero = 1000 + TotalContasCriadas;
            TotalContasCriadas++;
        }

        public bool Saque(float valor)
        {
            if (valor > this._saldo || valor < 0)
            {
                return false;
            }
            this._saldo -= valor;
            return true;
        }
        public bool Deposito(float valor)
        {
            if (valor < 0)
            {
                return false;
            }
            this._saldo += valor;
            return true;
        }
        public bool Transferencia(Conta contaComIdArray, float valor)
        {
            if (valor > this.Saldo || valor < 0)
            {
                return false;
            }
            this.Saque(valor);
            contaComIdArray.Deposito(valor);
            return true;
        }
    }
}
