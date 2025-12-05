using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Assignment
{


    public class BankAccount
    {
        public decimal Balance { get; private set; }
        public List<string> History { get; } = new List<string>();
        public BankAccount(decimal openingBalance) => Balance = openingBalance;
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            Balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
            Balance -= amount;

        }


    }
}
