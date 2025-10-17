namespace C_2
{
    internal class Program
    {
      
            static void Main(string[] args)
            {
              
                BankAccount savings = new SavingsAccount();
                savings.Deposit(1000);
                savings.Withdraw(800);

                BankAccount checking = new CheckingAccount();
                checking.Deposit(520);
                checking.Withdraw(300);

                Console.WriteLine("\n--- Interfaces ---");
                IPayment payment1 = new CreditCardPayment();
                IPayment payment2 = new CashPayment();

                payment1.ProcessPayment(300);
                payment1.PrintReceipt();

                payment2.ProcessPayment(150);
                payment2.PrintReceipt();

                Console.WriteLine("\n--- Structs ---");
                Point p = new Point(2, 3);
                Console.WriteLine(p);
                p.Move(5, -2);
                Console.WriteLine(p);

                Console.WriteLine("\n--- Enums ---");
                DayPrinter.PrintDayMessage(Days.Thursday);
                DayPrinter.PrintDayMessage(Days.Friday);
                DayPrinter.PrintDayMessage(Days.Tuesday);

                Console.WriteLine("\n--- Static Class ---");
                int num = 6;
                Console.WriteLine($"Square of {num} = {MathUtilities.Square(num)}");
              }
        
    }
}