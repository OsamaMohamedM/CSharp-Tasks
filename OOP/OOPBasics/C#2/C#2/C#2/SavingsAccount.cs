using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2
{
    public class SavingsAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"[Savings] Deposited {amount}. New Balance = {Balance}");
        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"[Savings] Withdrew {amount}. New Balance = {Balance}");
            }
            else
            {
                Console.WriteLine("[Savings] Insufficient funds!");
            }
        }
    }
}
