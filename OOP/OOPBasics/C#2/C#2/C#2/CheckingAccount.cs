using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2
{   
    public class CheckingAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"[Checking] Deposited {amount}. New Balance = {Balance}");
        }

        public override void Withdraw(decimal amount)
        {
            Balance -= amount;
            Console.WriteLine($"[Checking] Withdrew {amount}. New Balance = {Balance}");
        }
    }

}
