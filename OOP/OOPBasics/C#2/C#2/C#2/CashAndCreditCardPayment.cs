using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2
{
    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[CreditCard] Processing payment of {amount}");
        }

        public void PrintReceipt()
        {
            Console.WriteLine("[CreditCard] Receipt Printed");
        }
    }

    public class CashPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[Cash] Payment of {amount} received");
        }

        public void PrintReceipt()
        {
            Console.WriteLine("[Cash] Receipt Printed");
        }
    }
}
