using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2
{
    public interface IPayment
    {
        void ProcessPayment(decimal amount);
        void PrintReceipt();
    }
}
