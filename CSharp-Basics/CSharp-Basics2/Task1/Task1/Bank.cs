using System;



   
    public class BankAccount
    {
        public string AccountHolderName { get; set; }
        public double Balance { get; private set; }

        public BankAccount(string name, double initialBalance)
        {
            AccountHolderName = name;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Successfully deposited ${amount}.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Successfully withdrew ${amount}.");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current balance for {AccountHolderName} is ${Balance:F2}.");
        }
    }

    public class BankSimulator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mini Bank!");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            double initialBalance = Convert.ToDouble(Console.ReadLine());

            BankAccount account = new BankAccount(name, initialBalance);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;
                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        break;
                    case "3":
                        account.ShowBalance();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Thank you for using Mini Bank!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

